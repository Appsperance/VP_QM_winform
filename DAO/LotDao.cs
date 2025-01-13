using Dapper;
using System;
using System.Collections.Generic;
using VP_QM_winform.ComManager;
using VP_QM_winform.VO;

namespace VP_QM_winform.DAO
{
    public class LotDao : ILotDAO
    {
        private SQLManager sqlManager = new SQLManager();

        public List<LotVO> GetCompletedLotList()
        {
            try
            {
                var connection = sqlManager.GetConnection();
                var query = "SELECT id FROM lot WHERE injection_end IS NOT NULL;";
                return connection.Query<LotVO>(query).AsList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during login: {ex.Message}");
                return null;
            }
        }
    }
}
