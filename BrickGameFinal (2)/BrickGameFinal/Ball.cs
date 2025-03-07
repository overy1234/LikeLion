using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickGameFinal
{
    public class Ball
    {
        BALLDATA m_tBall = new BALLDATA();

        //C#공의 방향 배열 정의
        int[,] g_WallCollision = new int[4, 6]
        {
            {  3 , 2,-1,-1,-1, 4},
            { -1 ,-1,-1,-1, 2, 1},
            { -1 , 5, 4,-1,-1,-1},
            { -1 ,-1, 1, 0, 5,-1},
        };


        
        Bar m_pBar;
      
        Block m_pBlock;
        //바 클래스도 가져와야할거같다. 값만가져온다.
        public void SetBar(Bar bar) { m_pBar = bar; }
        //벽돌 클래스도 가져와야할거같다. ref로 가져와서 값을 변환해줄수있다.
        public void SetBlock(ref Block pBlock) { m_pBlock = pBlock; }
        

        public void ScreenWall() 
        {
            Program.gotoxy(0, 0);
            Console.Write("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            Program.gotoxy(0, 1);
            Console.Write("┃                                                                             ┃");
            Program.gotoxy(0, 2);
            Console.Write("┃                                                                             ┃");
            Program.gotoxy(0, 3);
            Console.Write("┃                                                                             ┃");
            Program.gotoxy(0, 4);
            Console.Write("┃                                                                             ┃");
            Program.gotoxy(0, 5);
            Console.Write("┃                                                                             ┃");
            Program.gotoxy(0, 6);
            Console.Write("┃                                                                             ┃");
            Program.gotoxy(0, 7);
            Console.Write("┃                                                                             ┃");
            Program.gotoxy(0, 8);
            Console.Write("┃                                                                             ┃");
            Program.gotoxy(0, 9);
            Console.Write("┃                                                                             ┃");
            Program.gotoxy(0, 10);
            Console.Write("┃                                                                             ┃");
            Program.gotoxy(0, 11);
            Console.Write("┃                                                                             ┃");
            Program.gotoxy(0, 12);
            Console.Write("┃                                                                             ┃");
            Program.gotoxy(0, 13);
            Console.Write("┃                                                                             ┃");
            Program.gotoxy(0, 14);
            Console.Write("┃                                                                             ┃");
            Program.gotoxy(0, 15);
            Console.Write("┃                                                                             ┃");
            Program.gotoxy(0, 16);
            Console.Write("┃                                                                             ┃");
            Program.gotoxy(0, 17);
            Console.Write("┃                                                                             ┃");
            Program.gotoxy(0, 18);
            Console.Write("┃                                                                             ┃");
            Program.gotoxy(0, 19);
            Console.Write("┃                                                                             ┃");
            Program.gotoxy(0, 20);
            Console.Write("┃                                                                             ┃");
            Program.gotoxy(0, 21);
            Console.Write("┃                                                                             ┃");
            Program.gotoxy(0, 22);
            Console.Write("┃                                                                             ┃");
            Program.gotoxy(0, 23);
            Console.Write("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");



        }
        public int Collision(int x, int y) 
        {
            //벽충돌
            if (y == 0)
            {
                m_tBall.nDirect = g_WallCollision[0, m_tBall.nDirect];
                return 1; //공의 방향이 바뀌면 1을 리턴  
            }

            if (x == 1)
            {
                m_tBall.nDirect = g_WallCollision[1, m_tBall.nDirect];
                return 1;
            }

            if (x == 77)
            {
                m_tBall.nDirect = g_WallCollision[2, m_tBall.nDirect];
                return 1;
            }

            if (y == 23)
            {
                m_tBall.nDirect = g_WallCollision[3, m_tBall.nDirect];
                return 1;
            }


            //Bar충돌처리
            if(x >= m_pBar.m_tBar.nX[0] && x <= m_pBar.m_tBar.nX[2] +1 && 
                y== (m_pBar.m_tBar.nY)) //바 위 충돌
            {
                if (m_tBall.nDirect == 1)
                    m_tBall.nDirect = 2;
                else if (m_tBall.nDirect == 2)
                    m_tBall.nDirect = 1;
                else if (m_tBall.nDirect == 5)
                    m_tBall.nDirect = 4;
                else if (m_tBall.nDirect == 4)
                    m_tBall.nDirect = 5;

                return 1; //방향이 바뀐다.
            }

            if (x >= m_pBar.m_tBar.nX[0] && x <= m_pBar.m_tBar.nX[2] + 1 &&
              y == (m_pBar.m_tBar.nY+1)) //바 아래 충돌
            {
                if (m_tBall.nDirect == 1)
                    m_tBall.nDirect = 2;
                else if (m_tBall.nDirect == 2)
                    m_tBall.nDirect = 1;
                else if (m_tBall.nDirect == 5)
                    m_tBall.nDirect = 4;
                else if (m_tBall.nDirect == 4)
                    m_tBall.nDirect = 5;

                return 1; //방향이 바뀐다.
            }


            //벽돌 충돌
            for(int i =0; i<20; i++)
            {
                if (m_pBlock.tBlock[i].nLife == 1)
                {
                    if(x >= m_pBlock.tBlock[i].nX && x<= m_pBlock.tBlock[i].nX+1 &&
                        y == m_pBlock.tBlock[i].nY)
                    {
                        if (m_tBall.nDirect == 1)
                            m_tBall.nDirect = 2;
                        else if (m_tBall.nDirect == 2)
                            m_tBall.nDirect = 1;
                        else if (m_tBall.nDirect == 5)
                            m_tBall.nDirect = 4;
                        else if (m_tBall.nDirect == 4)
                            m_tBall.nDirect = 5;

                        //벽돌 죽이기
                        m_pBlock.tBlock[i].nLife = 0;

                        return 1;
                    }


                    if (x >= m_pBlock.tBlock[i].nX && x <= m_pBlock.tBlock[i].nX + 1 &&
                       y == m_pBlock.tBlock[i].nY+1)
                    {
                        if (m_tBall.nDirect == 1)
                            m_tBall.nDirect = 2;
                        else if (m_tBall.nDirect == 2)
                            m_tBall.nDirect = 1;
                        else if (m_tBall.nDirect == 5)
                            m_tBall.nDirect = 4;
                        else if (m_tBall.nDirect == 4)
                            m_tBall.nDirect = 5;

                        //벽돌 죽이기
                        m_pBlock.tBlock[i].nLife = 0;

                        return 1;
                    }
                }
            }






            return 0; //공의 방향이 바뀌지 않으면 0 리턴         
        
        }
        public BALLDATA GetBall() { return m_tBall; }
        public void SetX(int x) { m_tBall.nX += x; }
        public void SetY(int y) { m_tBall.nY += y; }
        public void SetBall(BALLDATA tBall) { m_tBall = tBall; }
        public void SetReady(int Ready) { m_tBall.nReady = Ready; }

        public void Initialize() 
        {
            m_tBall.nReady = 0; //공안움직임 1 움직임 0
            m_tBall.nDirect = 1;
            m_tBall.nX = 30;
            m_tBall.nY = 10;

            //커서 안보이게 하기
            Console.CursorVisible = false;

        }
        public void Progress() {

            if (m_tBall.nReady == 0)
            {
                //공의 방향에따른 스위치문
                switch (m_tBall.nDirect)
                {
                    case 0: //위
                        if (Collision(m_tBall.nX, m_tBall.nY - 1) == 0)
                            m_tBall.nY--;
                        break;
                    case 1:  //오른쪽 위
                        if (Collision(m_tBall.nX + 1, m_tBall.nY - 1) == 0)
                        {
                            m_tBall.nX++;
                            m_tBall.nY--;
                        }
                        break;
                    case 2: //오른쪽 아래
                        if (Collision(m_tBall.nX + 1, m_tBall.nY + 1) == 0)
                        {
                            m_tBall.nX++;
                            m_tBall.nY++;
                        }
                        break;
                    case 3: //아래
                        if (Collision(m_tBall.nX, m_tBall.nY + 1) == 0)
                            m_tBall.nY++;
                        break;
                    case 4: //왼쪽 아래
                        if (Collision(m_tBall.nX - 1, m_tBall.nY + 1) == 0)
                        {
                            m_tBall.nX--;
                            m_tBall.nY++;
                        }
                        break;
                    case 5://왼쪽 위
                        if (Collision(m_tBall.nX - 1, m_tBall.nY - 1) == 0)
                        {
                            m_tBall.nX--;
                            m_tBall.nY--;
                        }
                        break;
                }
            }
        }
        public void Render() 
        {
            ScreenWall();
            Program.gotoxy(m_tBall.nX, m_tBall.nY);
            Console.Write("●");
        }
        public void Release() { }





    }
}
