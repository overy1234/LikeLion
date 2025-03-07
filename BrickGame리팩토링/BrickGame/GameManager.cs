using System;

namespace BrickGame
{
    public class GameManager
    {
        private readonly Ball _ball;
        private readonly Block _block;
        private readonly Bar _bar;

        public GameManager()
        {
            _ball = new Ball();
            _block = new Block();
            _bar = new Bar();
        }

        public void Initialize()
        {
            InitializeGameObjects();
            SetupDependencies();
        }

        private void InitializeGameObjects()
        {
            _ball.Initialize();
            _bar.Initialize();
            _block.Initialize();
        }

        private void SetupDependencies()
        {
            _ball.SetBar(_bar);
            _ball.SetBlock( _block);
        }

        public void Progress()
        {
            _ball.Progress();
            _bar.Progress( _ball);
            _block.Progress();
        }

        public void Render()
        {
            Console.Clear();
            RenderGameObjects();
        }

        private void RenderGameObjects()
        {
            _ball.Render();
            _bar.Render();
            _block.Render();
        }

        public void Release()
        {
            _ball.Release();
            _block.Release();
            _bar.Release();
        }
    }
}
