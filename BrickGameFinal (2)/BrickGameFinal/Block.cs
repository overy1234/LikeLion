using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickGameFinal
{
    public class Block
    {
        //벽돌이 여러개 
        public BLOCKDATA[] tBlock = new BLOCKDATA[50]; //배열

        public Block() //생성자
        {
            //벽돌초기화
            for (int i = 0; i < tBlock.Length; i++) //for문
            {
                tBlock[i] = new BLOCKDATA();  //객체생성
                tBlock[i].nLife = 0;
                tBlock[i].nX = 0;
                tBlock[i].nY = 0;
            }
        }

        //Search함수 주어진 좌표가 현재 설정된 블록 배열 중에 중복된것이 있는지를 
        //검색해주는 함수이다.
        //현재 최대 블록 50개 설정가능
        //매번 50개의 블록을 전부 검색할 필요없이 스테이지마다 할당된 블록
        //안에서만 검색
        //Search함수는 첫번째 인자의 nEnd변수는 블록의 범위가 된다.
        //이함수는 SetBlock함수에서 호출이된다.
        public int Search(int nEnd, int nX, int nY)
        {
            for (int i = 0; i < nEnd; i++)
            {
                if (tBlock[i].nY == nY) //y좌표가 같고
                {
                    if (tBlock[i].nX == nX || (tBlock[i].nX + 1) == nX)
                        return 1;  //x좌표까지 같으면 1을 반환
                }
            }
            return 0; //같지않으면 0을 반환
        }

        //범위 안에서 블록의 중복 검사를 하는 함수
        public void SetBlock(int nBlockCount)
        {
            int nX, nY;

            Random r = new Random();

            for (int i = 0; i < nBlockCount; i++)
            {
                tBlock[i].nLife = 1;

                while (true) //중복찾기
                {
                    nX = r.Next(2, 66); //2~65범위 안에서
                    nY = r.Next(2, 16); //2~15범위 안에서

                    if (Search(i, nX, nY) == 0)
                    {
                        //중복이아님
                        tBlock[i].nX = nX;
                        tBlock[i].nY = nY;
                        break; //한개만들고 for문 탈출
                    }
                }
            }

        }
        public void Initialize()
        {
            SetBlock(20);
        }
        public void Progress()
        {

        }
        public void Render()
        {
            for (int i = 0; i < 20; i++)
            {
                if (tBlock[i].nLife == 1) //살아있는 벽돌만 그리기
                {
                    Console.SetCursorPosition(tBlock[i].nX, tBlock[i].nY);
                    Console.Write("■");
                }
              
            }
        }
        public void Release() { }





    }





}

