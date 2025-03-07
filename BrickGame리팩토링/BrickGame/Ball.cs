using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickGame
{
    public class Ball
    {
        private BALLDATA _ballData = new BALLDATA();
        private readonly int[,] _wallCollisionDirections = new int[4, 6]
        {
            {  3,  2, -1, -1, -1,  4 },
            { -1, -1, -1, -1,  2,  1 },
            { -1,  5,  4, -1, -1, -1 },
            { -1, -1,  1,  0,  5, -1 }
        };

        private Bar _bar;
        private Block _block;

        public void SetBar(Bar bar) => _bar = bar;
        public void SetBlock( Block block) => _block = block;

        public void DrawScreenWall()
        {
            for (int y = 0; y <= 23; y++)
            {
                Console.SetCursorPosition(0, y);
                if (y == 0)
                    Console.Write("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
                else if (y == 23)
                    Console.Write("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
                else
                    Console.Write("┃                                                                             ┃");
            }
        }

        private int HandleCollision(int x, int y)
        {
            if (CheckWallCollision(x, y)) return 1;
            if (CheckBarCollision(x, y)) return 1;
            if (CheckBlockCollision(x, y)) return 1;
            return 0;
        }

        private bool CheckWallCollision(int x, int y)
        {
            if (y == 0)
            {
                _ballData.nDirect = _wallCollisionDirections[0, _ballData.nDirect];
                return true;
            }
            if (x == 1)
            {
                _ballData.nDirect = _wallCollisionDirections[1, _ballData.nDirect];
                return true;
            }
            if (x == 77)
            {
                _ballData.nDirect = _wallCollisionDirections[2, _ballData.nDirect];
                return true;
            }
            if (y == 23)
            {
                _ballData.nDirect = _wallCollisionDirections[3, _ballData.nDirect];
                return true;
            }
            return false;
        }

        private bool CheckBarCollision(int x, int y)
        {
            bool isColliding = x >= _bar.m_tBar.nX[0] && x <= _bar.m_tBar.nX[2] + 1 &&
                             (y == _bar.m_tBar.nY || y == _bar.m_tBar.nY + 1);

            if (isColliding)
            {
                UpdateBallDirection();
                return true;
            }
            return false;
        }

        private void UpdateBallDirection()
        {
            switch (_ballData.nDirect)
            {
                case 1: _ballData.nDirect = 2; break;
                case 2: _ballData.nDirect = 1; break;
                case 5: _ballData.nDirect = 4; break;
                case 4: _ballData.nDirect = 5; break;
            }
        }

        private bool CheckBlockCollision(int x, int y)
        {
            for (int i = 0; i < 20; i++)
            {
                if (_block.tBlock[i].nLife != 1) continue;

                bool isColliding = x >= _block.tBlock[i].nX && x <= _block.tBlock[i].nX + 1 &&
                                 (y == _block.tBlock[i].nY || y == _block.tBlock[i].nY + 1);

                if (isColliding)
                {
                    UpdateBallDirection();
                    _block.tBlock[i].nLife = 0;
                    return true;
                }
            }
            return false;
        }

        public BALLDATA GetBall() => _ballData;
        public void SetX(int x) => _ballData.nX += x;
        public void SetY(int y) => _ballData.nY += y;
        public void SetBall(BALLDATA ballData) => _ballData = ballData;
        public void SetReady(int ready) => _ballData.nReady = ready;

        public void Initialize()
        {
            _ballData.nReady = 0;
            _ballData.nDirect = 1;
            _ballData.nX = 30;
            _ballData.nY = 10;
            Console.CursorVisible = false;
        }

        public void Progress()
        {
            if (_ballData.nReady != 0) return;

            int nextX = _ballData.nX;
            int nextY = _ballData.nY;

            switch (_ballData.nDirect)
            {
                case 0: // 위
                    nextY--;
                    break;
                case 1: // 오른쪽 위
                    nextX++;
                    nextY--;
                    break;
                case 2: // 오른쪽 아래
                    nextX++;
                    nextY++;
                    break;
                case 3: // 아래
                    nextY++;
                    break;
                case 4: // 왼쪽 아래
                    nextX--;
                    nextY++;
                    break;
                case 5: // 왼쪽 위
                    nextX--;
                    nextY--;
                    break;
            }

            if (HandleCollision(nextX, nextY) == 0)
            {
                _ballData.nX = nextX;
                _ballData.nY = nextY;
            }
        }

        public void Render()
        {
            Console.SetCursorPosition(_ballData.nX, _ballData.nY);
            Console.Write("●");
        }

        public void Release() { }
    }
}
