using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ShootingGame
{
    public class Bullet
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsFired { get; set; } = false;
    }

    public class Player
    {
        [DllImport("msvcrt.dll")]
        static extern int _getch();

        public int X { get; private set; }
        public int Y { get; private set; }
        public List<Bullet> Bullets { get; } = new List<Bullet>();
        public int Score { get; private set; } = 100;
        public Item Item { get; } = new Item();
        public int ItemCount { get; private set; } = 0;

        public Player()
        {
            X = 0;
            Y = 12;
            for (int i = 0; i < 20; i++) Bullets.Add(new Bullet());
        }

        public void UpdateGame()
        {
            HandleInput();
            Draw();
            DrawScore();
            UpdateItem();
        }

        public void ClashEnemyAndBullet(Enemy enemy)
        {
            foreach (var bullet in Bullets)
            {
                if (bullet.IsFired && bullet.Y == enemy.Y && bullet.X >= (enemy.X - 1) && bullet.X <= (enemy.X + 1))
                {
                    Item.IsActive = true;
                    Item.X = enemy.X;
                    Item.Y = enemy.Y;

                    Random rand = new Random();
                    enemy.X = 75;
                    enemy.Y = rand.Next(2, 22);

                    bullet.IsFired = false;
                    Score += 100;
                }
            }
        }

        private void HandleInput()
        {
            if (!Console.KeyAvailable) return;
            int key = _getch();

            switch (key)
            {
                case 72: Y = Math.Max(1, Y - 1); break;
                case 75: X = Math.Max(0, X - 1); break;
                case 77: X = Math.Min(75, X + 1); break;
                case 80: Y = Math.Min(21, Y + 1); break;
                case 32: FireBullet(); break;
            }
        }

        private void FireBullet()
        {
             Bullets.Add(new Bullet { X = X + 5, Y = Y+1, IsFired = true });
            if (ItemCount >= 1) Bullets.Add(new Bullet { X = X + 5, Y = Y , IsFired = true });
            if (ItemCount >= 2) Bullets.Add(new Bullet { X = X + 5, Y = Y +2, IsFired = true });
        }

        public void DrawBullets()
        {
            string bulletSymbol = "->";
            foreach (var bullet in Bullets)
            {
                if (bullet.IsFired)
                {
                    Console.SetCursorPosition(bullet.X - 1, bullet.Y);
                    Console.Write(bulletSymbol);
                    bullet.X++;
                    if (bullet.X > 78) bullet.IsFired = false;
                }
            }
        }

        private void Draw()
        {
            string[] playerShape = { "->", ">>>", "->" };
            for (int i = 0; i < playerShape.Length; i++)
            {
                Console.SetCursorPosition(X, Y + i);
                Console.WriteLine(playerShape[i]);
            }
        }

        private void DrawScore()
        {
            Console.SetCursorPosition(63, 0);
            Console.Write("┏━━━━━━━━━━━━━━┓");
            Console.SetCursorPosition(63, 1);
            Console.Write("┃ Score : " + Score + "  ┃");
            Console.SetCursorPosition(63, 2);
            Console.Write("┗━━━━━━━━━━━━━━┛");
        }

        private void UpdateItem()
        {
            if (Item.IsActive)
            {
                Item.Move();
                Item.Draw();
                CheckItemCollision();
            }
        }

        private void CheckItemCollision()
        {
            if (Y + 1 == Item.Y && X >= Item.X - 2 && X <= Item.X + 2)
            {
                Item.IsActive = false;
                ItemCount = Math.Min(3, ItemCount + 1);
            }
        }
    }

    public class Enemy
    {
        public int X { get;  set; }
        public int Y { get;  set; }
        private Random _rand = new Random();

        public Enemy()
        {
            X = 77;
            Y = 12;
        }

        public void Move()
        {
            X--;
            if (X < 2)
            {
                X = 75;
                Y = _rand.Next(2, 22);
            }
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write("<-0->");
        }
    }

    public class Item
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsActive { get; set; } = false;

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write("★");
        }

        public void Move()
        {
        }
    }

    class Program
    {
        static void Main()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);

            Player player = new Player();
            Enemy enemy = new Enemy();
            int lastUpdateTime = Environment.TickCount;

            while (true)
            {
                if (lastUpdateTime + 50 < Environment.TickCount)
                {
                    lastUpdateTime = Environment.TickCount;
                    Console.Clear();

                    player.UpdateGame();
                    player.DrawBullets();
                    enemy.Move();
                    enemy.Draw();
                    player.ClashEnemyAndBullet(enemy);
                }
            }
        }
    }
}
