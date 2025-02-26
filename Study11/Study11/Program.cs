using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Study11
{
    class Program
    {

        //1단계함수
        //반환형 함수이름 (매개변수)
        //{
        //}
        //1단계 기본형
        static void Loading()
        {

            Console.WriteLine("로딩중.");
            Thread.Sleep(1000);
            Console.WriteLine("로딩중..");
            Thread.Sleep(1000);
            Console.WriteLine("로딩중...");
            Thread.Sleep(1000);
        }

        //2단계
        //입력
        static void AttackFunction(int Attack)
        {
            Console.WriteLine("공격력은 : " + Attack);
        }


        //3단계
        //출력
        static int BaseAttack()
        {
            //기본공격력 10
            int attack = 10;

            return attack; //출력
        }


        static int Add(int a, int b)
        {
            return a + b;
        }


        static void Main(string[] args)
        {
            //int Attack = 0;
            //int bAttack = 0;
            //Console.WriteLine("캐릭터의 공격력을 입력 : ");
            //Attack = int.Parse(Console.ReadLine());

            ////기본공격력
            //bAttack = BaseAttack();

            //AttackFunction(bAttack+Attack);

            //두수를 더하는 함수 만들어서 오류를 해결하세요.
            //int result = Add(10, 20);
            //Console.WriteLine($"10 + 20 = {result}");

            //string[] fruits = { "사과", "바나나", "체리" };

            ////반복문
            //foreach(string fruit in fruits)
            //{
            //    Console.WriteLine(fruit);
            //}


        }
    }
}
