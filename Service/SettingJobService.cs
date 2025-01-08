using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VP_QM_winform.DAO;
using VP_QM_winform.VO;

namespace VP_QM_winform.Service
{
    public class SettingJobService
    {
        private LotDao lotDao;

        public List<LotVO> GetLotList()
        {
            lotDao = new LotDao();

            try
            {
                return lotDao.GetCompletedLotList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        
    }
}
