using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXTRPG
{
    public class Field
    {
        Player m_pPlayer = null;
        //몬스터
        Monster m_pMonster = null;

        //플레이어 maingame에서 생성한거 가지고와야지
        //플레이어가 필드에서 전투를 하면 데미지를 입을거고 hp가깍이겠다?
        //그럼 배운것중에 ref써볼까?

        //ref안써도 됩니다. c랑 c++때꺼 변경하다가 포인터부분 ref 바꿨던거라 
        //까먹고 안지움
        public void SetPlayer( Player pPlayer) { m_pPlayer = pPlayer;  }



        public void Progress()
        {
            //사냥터로 들어왔다.
            int iInput = 0;

            while(true)
            {
                Console.Clear();

                m_pPlayer.Render();
                DrawMap();

                iInput = int.Parse(Console.ReadLine());

                if (iInput == 4)
                    break;

                if(iInput <= 3)
                {
                    //몬스터를 만들고
                    //1번일때 초보몬스터
                    //2번일때 중급몬스터
                    //3번일때 고급몬스터
                    CreateMonster(iInput);
                    //싸운다
                    Fight();
                }




            }

         
        }

        //생성을 도와주는 함수
        //공장처럼 찍어낸다.
        //팩토리 메서드 패턴
        public void Create(string _strName, int _iHp, int _iAttack, out Monster pMonster)
        {
            pMonster = new Monster(); //몬스터 생성
            INFO tMonster = new INFO(); //몬스터데이터 메모리 주기 객체 생성

            tMonster.strName = _strName; //초보몬스터 ,중,고
            tMonster.iHp = _iHp; //체력
            tMonster.iAttack = _iAttack; //공격력

            pMonster.SetMonster(tMonster); //생성된 데이터 INFO 클래스타입 이자로 데이터 세팅

        }



        public void CreateMonster(int input)
        {
            switch(input)
            {
                case 1:
                    //공장처럼 찍어내준다. 
                    //디자인패턴 팩토리 메서드 패턴
                    Create("초보몹", 30, 3, out m_pMonster);
                    break;
                case 2:                    
                    Create("중수몹", 60, 6, out m_pMonster);
                    break;
                case 3:                   
                    Create("고수몹", 90, 9, out m_pMonster);
                    break;
            }


        }

        public void Fight()
        {
            int iInput = 0;

            while(true)
            {
                Console.Clear(); //콘솔화면 지움
                m_pPlayer.Render(); //플레이어 정보 출력
                m_pMonster.Render(); //몬스터 정보출력


                Console.WriteLine("1.공격 2.도망 : "); //1,2 선택 표시
                iInput = int.Parse(Console.ReadLine()); 

                if(iInput == 1)
                {
                    //플레이어 데미지 주기 몬스터공격력 넣어서 데미지
                    m_pPlayer.SetDamage(m_pMonster.GetMonster().iAttack);
                    //몬스터 데미지 주기 플레이어 공격력 넣기
                    m_pMonster.SetDamage(m_pPlayer.GetInfo().iAttack);

                    if(m_pPlayer.GetInfo().iHp <=0) //플레이어 체력이 0이하이면
                    {
                        m_pPlayer.SetHp(100);
                        break;
                    }



                }


                if(iInput == 2 || m_pMonster.GetMonster().iHp <= 0)
                {
                    m_pMonster = null;
                    break; //탈출
                }
            }
        }


        public void DrawMap()
        {
            Console.WriteLine("1. 초보맵");
            Console.WriteLine("2. 중수맵");
            Console.WriteLine("3. 고수맵");
            Console.WriteLine("4. 전단계");
            Console.WriteLine("=============");
            Console.WriteLine("맵을 선택하세요 : ");
        }

        public Field() { }
        ~Field() { }


    }
}
