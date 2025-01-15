using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VP_QM_winform.DTO
{
    public class VisionNgReqDTO
    {
        public string LotId { get; set; }
        public string LineId { get; set; }
        public DateTime DateTime { get; set; }
        /// <summary>
        /// 불량 타입 (AI 트레이닝 Label)
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public NgType NgLabel { get; set; }
        /// <summary>
        ///  바이트 배열 이미지 데이터
        /// </summary>
        public byte[] Img { get; set; }

        new public void ToString()
        {
            Console.WriteLine($"########NgReqDTO######### : LotId: {LotId}, LineId: {LineId}, DateTime: {DateTime:yyyy-MM-dd HH:mm:ss}, " +
                   $"NgLabel: {NgLabel}, Img: {Img?.Length ?? 0} bytes");
        }

        public static NgType MapLabelToNgType(List<string> labels)
        {
            if (labels == null || labels.Count == 0)
            {
                // Labels 리스트가 비어있는 경우
                return NgType.NotClassified;
            }
            else if (labels.Count == 1)
            {
                // 문자열 값에 따라 NgType 매핑
                switch (labels[0])
                {
                    case "hole":
                        return NgType.Hole;
                    case "crack":
                        return NgType.Crack;
                    case "scratch":
                        return NgType.Scratch;
                    case "dirty":
                        return NgType.Dirty;
                    default:
                        return NgType.NotClassified; // 예상치 못한 값
                }
            } 
            else
            {
                // Labels 리스트에 2개 이상의 값이 있는 경우
                return NgType.Mixed;
            }   
        }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum NgType
    {
        Hole,
        Crack,
        Scratch,
        Dirty,
        Mixed,
        NotClassified
    }

    
}
