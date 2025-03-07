using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickGame
{
    public class BARDATA
    {
        private const int BAR_WIDTH = 3;
        public int[] nX { get; set; } = new int[BAR_WIDTH];  // 바의 X 좌표 배열 (3개의 세그먼트)
        public int nY { get; set; }                          // 바의 Y 좌표
    }
}
