using System;

namespace BrickGame
{
    public class Bar
    {
        public BARDATA m_tBar = new BARDATA();
        private int _isBallCaught;

        private const int LEFT_ARROW_KEY = 75;
        private const int RIGHT_ARROW_KEY = 77;
        private const char RELEASE_BALL_KEY = 'a';
        private const char CATCH_BALL_KEY = 's';

        public void Initialize()
        {
            _isBallCaught = 0;
            InitializeBarPosition();
        }

        private void InitializeBarPosition()
        {
            m_tBar.nY = 18;
            m_tBar.nX[0] = 12;
            m_tBar.nX[1] = 14;
            m_tBar.nX[2] = 16;
        }

        public void Progress( Ball ball)
        {
            if (!Console.KeyAvailable) return;

            int keyPressed = Program._getch();
            HandleKeyPress(keyPressed, ref ball);
        }

        private void HandleKeyPress(int keyPressed, ref Ball ball)
        {
            switch (keyPressed)
            {
                case LEFT_ARROW_KEY:
                    MoveBar(-1, ref ball);
                    break;
                case RIGHT_ARROW_KEY:
                    MoveBar(1, ref ball);
                    break;
                case RELEASE_BALL_KEY:
                    ReleaseBall(ref ball);
                    break;
                case CATCH_BALL_KEY:
                    TryCatchBall(ref ball);
                    break;
            }
        }

        private void MoveBar(int direction, ref Ball ball)
        {
            for (int i = 0; i < 3; i++)
            {
                m_tBar.nX[i] += direction;
            }

            if (IsBallCaught(ball))
            {
                ball.SetX(direction);
            }
        }

        private bool IsBallCaught(Ball ball)
        {
            return ball.GetBall().nReady == 1 && _isBallCaught == 1;
        }

        private void ReleaseBall(ref Ball ball)
        {
            ball.SetReady(0);
            _isBallCaught = 0;
        }

        private void TryCatchBall(ref Ball ball)
        {
            var ballData = ball.GetBall();
            bool isBallAboveBar = ballData.nX >= m_tBar.nX[0] &&
                                ballData.nX <= m_tBar.nX[2] + 1 &&
                                ballData.nY == (m_tBar.nY - 1);

            if (isBallAboveBar)
            {
                ball.SetReady(1);
                _isBallCaught = 1;
            }
        }

        public void Render()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(m_tBar.nX[i], m_tBar.nY);
                Console.Write("▥");
            }
        }

        public void Release() { }
    }
}
