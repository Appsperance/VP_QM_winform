using Microsoft.ML.OnnxRuntime;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.IO;
using VP_QM_winform.DTO;
using VP_QM_winform.Service;

namespace VP_QM_winform.Controller
{
    //비전 반환 값
    public enum ImageProcessingResult
    {
        Success, // "good" 클래스가 발견된 경우
        Failure, // "good"이 아닌 다른 클래스가 발견된 경우
        PreprocessingError, // 전처리 중 오류 발생
        ModelError, // 모델 실행 중 오류 발생
        NoImg //이미지가 없음W
    }
    public class VisionController
    {
        private static string s_ONNX_MODEL_PATH = "best.onnx";
        private InferenceSession session;

        public VisionController()
        {
            session = new InferenceSession(s_ONNX_MODEL_PATH);
            ProcessState.State["VisionModelLoaded"] = true;
            Console.WriteLine("ONNX 모델 로드 완료");
        }

        private float[] PreprocessImage(Mat img)
        {
            if (img.Empty())
            {
                Console.WriteLine($"이미지가 없습니다.");
                return null;
            }

            // 이미지 크기 변경
            int targetHeight = 640;
            int targetWidth = 640;
            Mat resizedImg = new Mat();
            Cv2.Resize(img, resizedImg, new OpenCvSharp.Size(targetWidth, targetHeight));

            // BGR -> RGB 변환
            Cv2.CvtColor(resizedImg, resizedImg, ColorConversionCodes.BGR2RGB);

            // float[] 형식으로 변환 (HWC -> CHW)
            float[] imageArray = new float[3 * targetHeight * targetWidth];
            int index = 0;

            for (int c = 0; c < 3; c++) // 채널 순회
            {
                for (int h = 0; h < targetHeight; h++) // 높이 순회
                {
                    for (int w = 0; w < targetWidth; w++) // 너비 순회
                    {
                        imageArray[index++] = resizedImg.At<Vec3b>(h, w)[c] / 255.0f; // 정규화
                    }
                }
            }

            return imageArray;
        }

        public void ProcessImage(Mat img, MQTTDTO mqttDTO)
        {
            // 1. 입력 데이터 준비
            float[] inputData = PreprocessImage(img);
            long[] dimensions = { 1, 3, 640, 640 };

            if (inputData == null)
            {
                Console.WriteLine("이미지 전처리 중 문제가 발생했습니다.");
            }

            // 2. OrtValue 생성
            using (var inputOrtValue = OrtValue.CreateTensorValueFromMemory(inputData, dimensions))
            {
                var inputs = new Dictionary<string, OrtValue>
                {
                    { "images", inputOrtValue }
                };

                // 3. 모델 실행
                using (var runOptions = new RunOptions())
                using (var output = session.Run(runOptions, inputs, session.OutputNames))
                {
                    try
                    {
                        // 출력 데이터 가져오기
                        var output_0 = output[0]; // Bounding boxes
                        var outputData = output_0.GetTensorDataAsSpan<float>();

                        // 출력 데이터 Shape 확인
                        var outputShape = output_0.GetTensorTypeAndShape().Shape;
                        Console.WriteLine($"output_0 Shape: [{string.Join(", ", outputShape)}]");

                        //이미지 후처리
                        ProcessOutput(outputData, outputShape, img, mqttDTO);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"모델 실행 중 오류 발생: {ex.Message}");
                    }
                }
            }
        }

        private void ProcessOutput(ReadOnlySpan<float> outputData, IReadOnlyList<long> outputShape, Mat img, MQTTDTO mqttDTO)
        {
            if (img.Empty())
            {
                Console.WriteLine("ProcessOutput : 입력받은 이미지가 없습니다.");
            }

            string[] labels = { "crack", "dirty", "good", "hole", "scratch" };
            float confidenceThreshold = 0.5f;

            int numDetections = (int)outputShape[1];
            int originalHeight = img.Height;
            int originalWidth = img.Width;

            int inputHeight = 640;
            int inputWidth = 640;

            float scaleX = (float)originalWidth / inputWidth;
            float scaleY = (float)originalHeight / inputHeight;
            bool isGood = false;
            Console.WriteLine("\n[Detection Results]");

            Dictionary<int, (float confidence, float x1, float y1, float x2, float y2)> bestBoxes = new Dictionary<int, (float, float, float, float, float)>();
            List<(int classId, float confidence, float x1, float y1, float x2, float y2)> allBoxes = new List<(int, float, float, float, float, float)>();

            for (int i = 0; i < numDetections; i++)
            {
                float confidence = outputData[i * 10 + 4];
                if (confidence < confidenceThreshold) continue;

                float cx = outputData[i * 10 + 0] * scaleX;
                float cy = outputData[i * 10 + 1] * scaleY;
                float w = outputData[i * 10 + 2] * scaleX;
                float h = outputData[i * 10 + 3] * scaleY;

                float x1 = cx - (w / 2);
                float y1 = cy - (h / 2);
                float x2 = cx + (w / 2);
                float y2 = cy + (h / 2);

                int classId = ArgMax(outputData.Slice(i * 10 + 5, 5));

                if (!bestBoxes.ContainsKey(classId) || bestBoxes[classId].confidence < confidence)
                {
                    bestBoxes[classId] = (confidence, x1, y1, x2, y2);
                }
                allBoxes.Add((classId, confidence, x1, y1, x2, y2));
            }

            if (bestBoxes.Count == 0)
            {
                // bestBoxes가 비어 있을 경우 양품으로 판정
                ProcessState.State["InspectionResult"] = true;
            }

            foreach (var kvp in bestBoxes)
            {
                int classId = kvp.Key;
                var (confidence, x1, y1, x2, y2) = kvp.Value;
                string label = labels[classId];
                

                Console.WriteLine($"Label: {label}, Confidence: {confidence:F4}, BBox: [{x1:F2}, {y1:F2}, {x2:F2}, {y2:F2}]");

                Point topLeft = new Point((int)x1, (int)y1);
                Point bottomRight = new Point((int)x2, (int)y2);
                Scalar color = label == "good" ? new Scalar(0, 255, 0) : new Scalar(0, 0, 255);

                Cv2.Rectangle(img, topLeft, bottomRight, color, 2);
                string displayText = $"{label}: {confidence:F2}";
                Cv2.PutText(img, displayText, new Point((int)x1, (int)y1 - 10), HersheyFonts.HersheySimplex, 0.5, color, 1);
                //상태 업데이트
                ProcessState.UpdateState("InspectionResult",false);
            }

            //지정 디렉토리에 결과 값 저장
            string outputDir = @"C:\VP_Vision\processed";
            Directory.CreateDirectory(outputDir);

            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string outputFileName = Path.Combine(outputDir, $"output_{timestamp}.png");
            Cv2.ImWrite(outputFileName, img);
            Console.WriteLine($"결과 이미지 저장됨: {outputFileName}");

            using (var memoryStream = new MemoryStream())
            {
                Cv2.ImEncode(".png", img, out byte[] imageBytes);
                memoryStream.Write(imageBytes, 0, imageBytes.Length);
                mqttDTO.NGImg = memoryStream.ToArray(); // DTO에 이미지 바이트 배열 저장
            }
        }

        private int ArgMax(ReadOnlySpan<float> data)
        {
            int maxIndex = 0;
            float maxValue = data[0];
            for (int i = 1; i < data.Length; i++)
            {
                if (data[i] > maxValue)
                {
                    maxValue = data[i];
                    maxIndex = i;
                }
            }
            return maxIndex;
        }

        public void Dispose()
        {
            session.Dispose();
            ProcessState.State["VisionModelLoaded"] = false;
            Console.WriteLine("ONNX 모델 자원 해제");
        }

    }
}
