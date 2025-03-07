using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXTRPG
{
    class MainGame
    {
        public Player m_pPlayer = null;
        //필드객체
        public Field m_pField = null;



        //초기화해주는함수
        public void Initialize()
        {
            //플레이어생성 및 직업 선택
            m_pPlayer = new Player();
            m_pPlayer.SelectJob();

        }


        //게임의 전체적인 과정관리
        public void Progress()
        {
            int iInput = 0;

            while(true)
            {
                Console.Clear();
                m_pPlayer.Render(); //플레이어 출력
                Console.WriteLine("1.사냥터 2.종료 : ");
                iInput = int.Parse(Console.ReadLine());

                if (iInput == 2)
                    break;


                if(iInput == 1)
                {
                    //사냥터 구현
                    if(m_pField == null)
                    {
                        m_pField = new Field();
                        //필드로 갈때 플레이어 넣어주기
                        m_pField.SetPlayer( m_pPlayer);
                    }
                    m_pField.Progress();

                }
            }
        }

        public MainGame() { }

        ~MainGame() { }



    }
}


//오늘과제 
//1.상속으로 만들어보기
//2.한번보면서 다시 만들어보기


//내일 시험 텍스트알피지 타임어택
//1시간안에 텍스트알피지 만들기 시험시간동안 최대한 안보고하기