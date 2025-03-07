using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study27
{
    //부모 클래스
    class Animal
    {
        public string Name { get; set; }

        public void Eat()
        {
            Console.WriteLine($"{Name}이(가) 음식을 먹고 있습니다.");
        }
    }

    //자식 클래스 (파생 클래스)
    class Dog : Animal
    {
        public void Bark()
        {
            Console.WriteLine($"{Name}이(가) 멍멍 짖습니다.!");
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Dog myDog = new Dog();
            myDog.Name = "바둑이"; //부모 클래스의 속성 사용
            myDog.Eat();  //부모 클래스의 메서드 호출 가능
            myDog.Bark(); //자기 메서드 호출 가능 



        }
    }
}
