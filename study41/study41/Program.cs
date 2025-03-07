using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study41
{
    class Parent
    {
        protected string name;

        //부모 생성자에서 name 초기화
        public Parent(string name)
        {
            this.name = name;
            Console.WriteLine($"부모 생성자: {name}");
        }
    }

    class Child: Parent
    {
        private int age;

        //부모 생성자를 호출하면서 name 전달 + 추가로 age초기화
        public Child(string name, int age):base(name)  //1
        {
            this.age = age;
            Console.WriteLine($"자식 생성자: 나이 = {age}");
        }

        public void ShowInfo()
        {
            Console.WriteLine($"이름 : {name}, 나이 : {age} ");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Child child = new Child("홍길동", 25); //0
            child.ShowInfo();
        }
    }
}
