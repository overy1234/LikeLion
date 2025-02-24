using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024Answer_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //            문제 2.비트 반전(~) 연산자 활용 프로그램
            //설명:
            //사용자로부터 정수를 입력받아 비트 반전(~) 연산자를 적용한 결과를 출력합니다.


            // 사용자로부터 정수 입력 받기
            Console.Write("정수를 입력하세요: ");
            int number = int.Parse(Console.ReadLine());

            // 비트 반전 연산자 적용 (~ 연산자는 모든 비트를 반전시킵니다)
            int result = ~number;

            // 원래 값과 비트 반전 후의 값 출력
            Console.WriteLine("원래 값: " + number);
            Console.WriteLine("비트 반전 후 값: " + result);





        }
    }
}
