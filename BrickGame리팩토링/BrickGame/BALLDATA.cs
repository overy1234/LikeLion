using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickGame
{
    public class BALLDATA
    {
        public int nReady { get; set; }  // 0: 움직임, 1: 정지
        public int nDirect { get; set; } // 0: 위, 1: 오른쪽 위, 2: 오른쪽 아래, 3: 아래, 4: 왼쪽 아래, 5: 왼쪽 위
        public int nX { get; set; }      // X 좌표
        public int nY { get; set; }      // Y 좌표
    }
}
