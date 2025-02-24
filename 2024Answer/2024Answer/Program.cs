using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024Answer
{
    class Program
    {
        static void Main(string[] args)
        {

            //            문제 1.학점 평균 계산 프로그램
            //설명:
            //사용자로부터 국어, 영어, 수학 점수를 입력받아 총점과 평균을 구합니다.
            //평균은 정수형 총점을 실수형으로 캐스팅하여 소수점 둘째 자리까지 출력합니다.


            // 사용자로부터 점수 입력 받기
            Console.Write("국어 점수를 입력하세요: ");
            int kor = int.Parse(Console.ReadLine());

            Console.Write("영어 점수를 입력하세요: ");
            int eng = int.Parse(Console.ReadLine());

            Console.Write("수학 점수를 입력하세요: ");
            int math = int.Parse(Console.ReadLine());

            // 총점 계산
            int total = kor + eng + math;

            // 평균 계산 (정수 총점을 double로 캐스팅)
            double average = (double)total / 3;

            // 결과 출력 (평균은 소수점 둘째 자리까지 표시)
            Console.WriteLine("총점: " + total);
            Console.WriteLine("평균: " + average.ToString("F2"));


        }
    }
}
