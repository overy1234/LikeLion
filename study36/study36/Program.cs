using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study36
{
    class Person
    {
        private string name = "홍길동"; //필드 클래스의 데이터를 저장하는 멤버입니다.
        public void SetName(string n)
        {
            name = n;
        }
        public string GetName()
        {
            return name;
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person(); //객체로 만들기  인스턴스
            Console.WriteLine(p.GetName());
            p.SetName("Bob");
            Console.WriteLine(p.GetName());

        }
    }
}
