using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study43
{
    //C# 인터페이스(Interface)란?
    //인터페이스는 클래스나 구조체에서 구현해야하는 메서드, 속성 등을 정의하는 추상적인 개념입니다.
    //즉, 어떤 기능을 반드시 포함하도록 강제하는 역할을 합니다.

    //인터페이스의특징
    //interface 키워드를 사용해서 정의
    //추상 메서드만 포함(구현X)-> 인터페이스를 구현하는 클래스에서 반드시 구현해야함.
    //다중 상속 가능(C#에서는 클래스 다중상속이 불가능하지만, 인터페이스는 여러개 구현 가능)
    //객체를 생성할수없음(추상 클래스와 유사).

    //인터페이스 정의
    interface IAinimal
    {
        void MakeSound();  //인터페이스의 메서드 (구현 x)
    }

    //인터페이스 구현(클래스에서 반드시 구현해야함)
    class Dog: IAinimal
    {
        public void MakeSound()
        {
            Console.WriteLine("멍멍!");
        }
    }
    class Cat : IAinimal
    {
        public void MakeSound()
        {
            Console.WriteLine("야옹");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IAinimal dog = new Dog();
            dog.MakeSound();

            IAinimal cat = new Cat();
            cat.MakeSound();
        }
    }
}
