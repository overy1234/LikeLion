using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ShootingGame
{
    //미사일 클래스
    public class BULLET
    {
        public int x;
        public int y;
        public bool fire;
    }
    //플레이어 클래스
    public class Player
    {
        [DllImport("msvcrt.dll")]
        static extern int _getch();  //c언어 함수 가져옴

        public int playerX;   //플레이어 X좌표
        public int playerY;   //플레이어 Y좌표
        public BULLET[] playerBullet = new BULLET[20];
        public BULLET[] playerBullet2 = new BULLET[20];
        public BULLET[] playerBullet3 = new BULLET[20];
        public int Score = 100;
        public Item item = new Item();
        public int itemCount = 0;


        public Player() //생성자
        {
            //플레이어 좌표위치 초기화
            playerX = 0;
            playerY = 12;

            for(int i =0; i<20; i++) //총알 초기화
            {
                playerBullet[i] = new BULLET();
                playerBullet[i].x = 0;
                playerBullet[i].y = 0;
                playerBullet[i].fire = false;

                playerBullet2[i] = new BULLET();
                playerBullet2[i].x = 0;
                playerBullet2[i].y = 0;
                playerBullet2[i].fire = false;


                playerBullet3[i] = new BULLET();
                playerBullet3[i].x = 0;
                playerBullet3[i].y = 0;
                playerBullet3[i].fire = false;
            }

            
        }

        public void GameMain()
        {
            //키를 입력하는 부분
            KeyControl();
            //플레이얼를 그려준다.
            PlayerDraw();

            //UI점수
            UIscore();

            if(item.ItemLife)
            {
                item.ItemMove();
                item.ItemDraw();
                CrashItem();
            }


        }

        public void KeyControl()
        {
            int pressKey;  //정수형 변수선언 키값 받을거임 

            if(Console.KeyAvailable) //키가 눌렸을때 true
            {
                pressKey = _getch(); //아스키값 왼쪽 오른쪽

               
                switch(pressKey)
                {
                    case 72:  //위쪽방향 아스키코드                    
                        playerY--;
                        if (playerY < 1)
                            playerY = 1;
                        break;     
                    case 75:
                        //왼쪽 화살표키
                        playerX--;
                        if (playerX < 0)  
                            playerX = 0;
                        break;
                    case 77:
                        //오른쪽
                        playerX++;
                        if (playerX > 75)
                            playerX = 75;
                        break;
                    case 80: //아래
                        playerY++;
                        if (playerY > 21)
                            playerY = 21;
                        break;
                    case 32: //스페이스바
                        //총알 발사
                        for(int i=0; i<20; i++)
                        {
                            //미사일이 false 발사가능
                            if (playerBullet[i].fire == false)
                            {
                                playerBullet[i].fire = true;
                                //플레이어 앞에서 미사일 쏘기 + 5
                                playerBullet[i].x = playerX + 5;
                                playerBullet[i].y = playerY +1;
                                //한발씩 쏘겠다.
                                break;
                            }
                        }

                        //총알2 발사
                        for (int i = 0; i < 20; i++)
                        {
                            //미사일이 false 발사가능
                            if (playerBullet2[i].fire == false)
                            {
                                playerBullet2[i].fire = true;
                                //플레이어 앞에서 미사일 쏘기 + 5
                                playerBullet2[i].x = playerX + 5;
                                playerBullet2[i].y = playerY ;
                                //한발씩 쏘겠다.
                                break;
                            }
                        }

                        //총알3 발사
                        for (int i = 0; i < 20; i++)
                        {
                            //미사일이 false 발사가능
                            if (playerBullet3[i].fire == false)
                            {
                                playerBullet3[i].fire = true;
                                //플레이어 앞에서 미사일 쏘기 + 5
                                playerBullet3[i].x = playerX + 5;
                                playerBullet3[i].y = playerY + 2;
                                //한발씩 쏘겠다.
                                break;
                            }
                        }
                        break;
                }


            }





        }

        //미사일 그리기
        public void BulletDraw()
        {
            string bullet = "->"; //미사일모습

            //20개
            for(int i =0; i<20; i++)
            {
                //미사일이 살아있는 상태
                if (playerBullet[i].fire == true)
                {
                    //좌표설정 -> 중간위치를 위해 보정을 위해 x-1
                    Console.SetCursorPosition(playerBullet[i].x-1, playerBullet[i].y);
                    //총알 출력
                    Console.Write(bullet);

                    playerBullet[i].x++; //미사일 오른쪽으로 날라가기

                    if (playerBullet[i].x >78)
                    {
                        playerBullet[i].fire = false;  //미사일 false 다시 준비상태
                    }
                }
            }
        }


        //미사일 그리기2
        public void BulletDraw2()
        {
            string bullet = "->"; //미사일모습

            //20개
            for (int i = 0; i < 20; i++)
            {
                //미사일이 살아있는 상태
                if (playerBullet2[i].fire == true)
                {
                    //좌표설정 -> 중간위치를 위해 보정을 위해 x-1
                    Console.SetCursorPosition(playerBullet2[i].x - 1, playerBullet2[i].y);
                    //총알 출력
                    Console.Write(bullet);

                    playerBullet2[i].x++; //미사일 오른쪽으로 날라가기

                    if (playerBullet2[i].x > 78 )
                    {
                        playerBullet2[i].fire = false;  //미사일 false 다시 준비상태
                    }
                }
            }
        }

        public void BulletDraw3()
        {
            string bullet = "->"; //미사일모습

            //20개
            for (int i = 0; i < 20; i++)
            {
                //미사일이 살아있는 상태
                if (playerBullet3[i].fire == true)
                {
                    //좌표설정 -> 중간위치를 위해 보정을 위해 x-1
                    Console.SetCursorPosition(playerBullet3[i].x - 1, playerBullet3[i].y);
                    //총알 출력
                    Console.Write(bullet);

                    playerBullet3[i].x++; //미사일 오른쪽으로 날라가기

                    if (playerBullet3[i].x > 78)
                    {
                        playerBullet3[i].fire = false;  //미사일 false 다시 준비상태
                    }
                }
            }
        }
        public void PlayerDraw()
        {
            String[] player = new string[]
            {
                "->",
                ">>>",
                "->"
            };//배열 문자열로 그리기


            for(int i=0; i<player.Length; i++)
            {
                //콘솔좌표 설정 플레이어X 플레이어Y
                Console.SetCursorPosition(playerX, playerY + i);
                //문자열배열 출력
                Console.WriteLine(player[i]);
            }
        }

        //충돌처리
        public void ClashEnemyAndBullet(Enemy enemy)
        {

            //미사일20
            for(int i =0; i<20; i++)
            {
                //살아있는 미사일
                if (playerBullet[i].fire == true)
                {
                    //미사일과 적의 y값이 같을때 
                    if (playerBullet[i].y == enemy.enemyY)
                    {
                        if (playerBullet[i].x >= (enemy.enemyX -1)
                            && playerBullet[i].x <= (enemy.enemyX+1)) //충돌
                        {
                            //충돌

                            item.ItemLife = true;
                            item.itemX = enemy.enemyX;
                            item.itemY = enemy.enemyY;


                            Random rand = new Random();
                            enemy.enemyX = 75;
                            enemy.enemyY = rand.Next(2, 22);

                            playerBullet[i].fire = false; //미사일도 준비상태로 만들어주기

                            //스코어
                            Score += 100;

                        }
                    }

                }
            }

            //미사일2 20
            for (int i = 0; i < 20; i++)
            {
                //살아있는 미사일
                if (playerBullet2[i].fire == true)
                {
                    //미사일과 적의 y값이 같을때 
                    if (playerBullet2[i].y == enemy.enemyY)
                    {
                        if (playerBullet2[i].x >= (enemy.enemyX - 1)
                            && playerBullet2[i].x <= (enemy.enemyX + 1)) //충돌
                        {
                            //충돌

                            Random rand = new Random();
                            enemy.enemyX = 75;
                            enemy.enemyY = rand.Next(2, 22);

                            playerBullet2[i].fire = false; //미사일도 준비상태로 만들어주기

                            //스코어
                            Score += 100;

                        }
                    }

                }
            }


            //미사일3 20
            for (int i = 0; i < 20; i++)
            {
                //살아있는 미사일
                if (playerBullet3[i].fire == true)
                {
                    //미사일과 적의 y값이 같을때 
                    if (playerBullet3[i].y == enemy.enemyY)
                    {
                        if (playerBullet3[i].x >= (enemy.enemyX - 1)
                            && playerBullet3[i].x <= (enemy.enemyX + 1)) //충돌
                        {
                            //충돌

                            Random rand = new Random();
                            enemy.enemyX = 75;
                            enemy.enemyY = rand.Next(2, 22);

                            playerBullet3[i].fire = false; //미사일도 준비상태로 만들어주기

                            //스코어
                            Score += 100;

                        }
                    }

                }
            }
        }

        public void UIscore()
        {
            Console.SetCursorPosition(63, 0);
            Console.Write("┏━━━━━━━━━━━━━━┓");
            Console.SetCursorPosition(63, 1);
            Console.Write("┃              ┃");
            Console.SetCursorPosition(65, 1);
            Console.Write("Score : " + Score);
            Console.SetCursorPosition(63, 2);
            Console.Write("┗━━━━━━━━━━━━━━┛");
        }

        //아이템 충돌이 일어나면 양쪽미사일 발사
        public void CrashItem()
        {

            if(playerY+1 == item.itemY)
            {
                if(playerX >= item.itemX-2 && playerX <= item.itemX +2)
                {
                    item.ItemLife = false;

                    if (itemCount < 3)
                        itemCount++;

                    for(int i =0; i<20; i++) //총알 초기화
                    {
                        playerBullet[i] = new BULLET();
                        playerBullet[i].x = 0;
                        playerBullet[i].y = 0;
                        playerBullet[i].fire = false;

                        playerBullet2[i] = new BULLET();
                        playerBullet2[i].x = 0;
                        playerBullet2[i].y = 0;
                        playerBullet2[i].fire = false;


                        playerBullet3[i] = new BULLET();
                        playerBullet3[i].x = 0;
                        playerBullet3[i].y = 0;
                        playerBullet3[i].fire = false;
                    }

                }
            }


        }







    }

    public class Enemy //적 클래스
    {
        public int enemyX;  //X좌표
        public int enemyY;  //Y좌표

        public Enemy()
        {
            //적 좌표 초기화
            enemyX = 77;
            enemyY = 12;

        }

        public void EnemyDraw()//적그리기
        {
            string enemy = "<-0->"; //문자열로 표현
            Console.SetCursorPosition(enemyX, enemyY); //좌표설정
            Console.Write(enemy);//출력
        }

        public void EnmeyMove()
        {
            Random rand = new Random(); //랜덤
            enemyX--; //왼쪽으로 움직임

            if(enemyX <2) //화면 왼쪽넘어가면 새로 좌표잡아라
            {
                enemyX = 75; //좌표 77
                enemyY = rand.Next(2, 22); //2~21 
            }

        }

    }


    //아이템 클래스
    public class Item
    {
        public string ItemName;
        public string ItemSprite;
        public int itemX = 0;
        public int itemY = 0;
        public bool ItemLife = false;

        public void ItemDraw()
        {
            Console.SetCursorPosition(itemX, itemY);
            ItemSprite = "Item★";
            Console.Write(ItemSprite);
        }

        public void ItemMove()
        {
            //if(itemX <=1 || itemY <=1)
            //{
            //    ItemLife = false;
            //}


        }




    }













    class Program
    {
        static void Main(string[] args)
        {

            Console.CursorVisible = false;

            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);



            //플레이어 생성
            Player player = new Player();
            Enemy enemy = new Enemy(); //적생성

            //유니티처럼 속도 프레임속도
            int dwTime = Environment.TickCount;  // 1/1000 초가 흐른다.

            while(true) //무한반복
            {
                //0.05초 지연
                if(dwTime + 50 < Environment.TickCount)
                {
                    //현재시간 세팅
                    dwTime = Environment.TickCount;
                    Console.Clear();

                    //플레이어
                    player.GameMain();

                    //총알

                    if(player.itemCount == 0)
                    {
                        player.BulletDraw();
                    }
                    else if(player.itemCount == 1)
                    {
                        player.BulletDraw();
                        player.BulletDraw2();
                    }
                    else  
                    {
                        player.BulletDraw();
                        player.BulletDraw2();
                        player.BulletDraw3();
                    }


                    enemy.EnmeyMove();//적이동
                    enemy.EnemyDraw();//적그리기


                    //충돌처리
                    player.ClashEnemyAndBullet(enemy);
                }
            }
        }
    }
}
