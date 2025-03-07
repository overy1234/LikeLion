using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXTRPG
{
    public class Player
    {
        public INFO m_tInfo;

        //데미지를 입는 함수
        public void SetDamage(int iAttack) { m_tInfo.iHp -= iAttack; }
        //플레이어 정보를 외부에서 볼수있는 함수
        public INFO GetInfo() { return m_tInfo;  }
        //hp를 다시 설정해주는 함수
        public void SetHp(int iHp) { m_tInfo.iHp = iHp; }



        //직업선택
        public void SelectJob()
        {
            m_tInfo = new INFO();

            Console.WriteLine("직업을 선택하세요(1.기사 2.마법사 3.도둑) : ");
            int iInput = 0;

            iInput = int.Parse(Console.ReadLine());

            switch(iInput)
            {
                case 1:
                    m_tInfo.strName = "기사";
                    m_tInfo.iHp = 100;
                    m_tInfo.iAttack = 10;
                    break;
                case 2:
                    m_tInfo.strName = "마법사";
                    m_tInfo.iHp = 90;
                    m_tInfo.iAttack = 15;
                    break;
                case 3:
                    m_tInfo.strName = "도둑";
                    m_tInfo.iHp = 85;
                    m_tInfo.iAttack = 13;
                    break;
            }
        }



        public void Render()
        {
            Console.WriteLine("=========================");
            Console.WriteLine("직업 이름 : " + m_tInfo.strName);
            Console.WriteLine("체력 : " + m_tInfo.iHp + "\t공격력 :  " + m_tInfo.iAttack);
        }


        public Player() { }

        ~Player() { } //소멸자

    }
}
