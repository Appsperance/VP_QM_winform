using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VP_QM_winform.VO;

namespace VP_QM_winform.DAO
{
    internal interface ILotDAO
    {
        List<LotVO> GetCompletedLotList();
    }
}
