using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VP_QM_winform.ComManager;
using VP_QM_winform.VO;

namespace VP_QM_winform.DAO
{
    public class VisionCumDAO : IVisionCumDAO
    {
        private SQLManager sqlManager = new SQLManager();

        public int InsertVisionCum(VisionCumVO visionCumVO)
        {
            try
            {
                var connection = sqlManager.GetConnection();
                var query = @"
                INSERT INTO vision_cum (
                    line_id, time, lot_id, shift, employee_number, total
                ) VALUES (
                    @LineId, @Time, @LotId, @Shift, @EmployeeNumber, @Total
                );";

                return connection.Execute(query, visionCumVO);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during InsertVisionCum execution: {ex.Message}");
                return 0;
            }
        }
    }
}
