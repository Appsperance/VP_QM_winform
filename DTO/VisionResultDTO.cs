using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_QM_winform.DTO
{
    public class VisionResultDTO
    {
        public byte[] Img { get; set; }
        public List<string> Labels { get; set; } = new List<string>();

    }
}
