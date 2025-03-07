using System;

namespace BrickGame
{
    public class Block
    {
        private const int MAX_BLOCKS = 50;
        private const int MIN_X = 2;
        private const int MAX_X = 65;
        private const int MIN_Y = 2;
        private const int MAX_Y = 15;
        private const int DEFAULT_BLOCK_COUNT = 20;

        public BLOCKDATA[] tBlock = new BLOCKDATA[MAX_BLOCKS];

        public Block()
        {
            InitializeBlocks();
        }

        private void InitializeBlocks()
        {
            for (int i = 0; i < tBlock.Length; i++)
            {
                tBlock[i] = new BLOCKDATA
                {
                    nLife = 0,
                    nX = 0,
                    nY = 0
                };
            }
        }

        private bool IsBlockOverlapping(int blockIndex, int x, int y)
        {
            for (int i = 0; i < blockIndex; i++)
            {
                if (tBlock[i].nY == y && 
                    (tBlock[i].nX == x || tBlock[i].nX + 1 == x))
                {
                    return true;
                }
            }
            return false;
        }

        private void GenerateRandomBlocks(int blockCount)
        {
            var random = new Random();

            for (int i = 0; i < blockCount; i++)
            {
                tBlock[i].nLife = 1;
                SetRandomPosition(random, i);
            }
        }

        private void SetRandomPosition(Random random, int blockIndex)
        {
            int x, y;
            do
            {
                x = random.Next(MIN_X, MAX_X + 1);
                y = random.Next(MIN_Y, MAX_Y + 1);
            } while (IsBlockOverlapping(blockIndex, x, y));

            tBlock[blockIndex].nX = x;
            tBlock[blockIndex].nY = y;
        }

        public void Initialize()
        {
            GenerateRandomBlocks(DEFAULT_BLOCK_COUNT);
        }

        public void Progress()
        {
            // 향후 블록 동작 로직이 필요한 경우 여기에 구현
        }

        public void Render()
        {
            RenderActiveBlocks();
        }

        private void RenderActiveBlocks()
        {
            for (int i = 0; i < DEFAULT_BLOCK_COUNT; i++)
            {
                if (tBlock[i].nLife == 1)
                {
                    Console.SetCursorPosition(tBlock[i].nX, tBlock[i].nY);
                    Console.Write("■");
                }
            }
        }

        public void Release() { }
    }
}

