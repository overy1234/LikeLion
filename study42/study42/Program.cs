using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study42
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("간단한 RPG 게임을 시작합니다.");

            //캐릭터 생성
            GameCharacter warrior = new Warrior("전사");
            GameCharacter mage = new Mage("마법사");

            //전투 시뮬
            Console.WriteLine("=====전투 시작! ======");

            //전사의 공격
            warrior.BasicAttack(mage);
            warrior.SpecialAttack(mage);

            //마법사의 반격

            mage.BasicAttack(warrior);
            mage.SpecialAttack(warrior);


            Console.WriteLine("=========전투종료========");
            Console.WriteLine($"전사 남은 체력: {warrior.Health}");
            Console.WriteLine($"마법사 남은 체력: {mage.Health}");





        }
    }
}
