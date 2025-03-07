using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickGame
{
    public class BLOCKDATA
    {
        public int nLife { get; set; }  // 0: 파괴됨, 1: 살아있음
        public int nX { get; set; }     // 블록의 X 좌표
        public int nY { get; set; }     // 블록의 Y 좌표
    }
}
