using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace study9
{
    class Program
    {
        static void Main(string[] args)
        {
            //switch문

            //int day = 6;

            //switch(day)
            //{
            //    case 1:
            //        Console.WriteLine("월요일");
            //        break;
            //    case 2:
            //        Console.WriteLine("화요일");
            //        break;
            //    case 3:
            //        Console.WriteLine("수요일");
            //        break;
            //    case 4:
            //        Console.WriteLine("목요일");
            //        break;
            //    case 5:
            //        Console.WriteLine("금요일");
            //        break;
            //    default:
            //        Console.WriteLine("주말입니다.");
            //        break;
            //}

            //문제 1.세 정수의 최대값 구하기
            //문제 설명:
            //사용자로부터 3개의 정수를 입력받아 그 중 가장 큰 값을 출력하는 프로그램을 작성하세요.
            //요구사항:

            //사용자에게 세 개의 정수를 입력받습니다.
            //if문을 사용하여 가장 큰 정수를 결정합니다.
            //결과를 “최대값: X” 형식으로 출력합니다.

            //사용자로부터 3개의 정수를 입력받는다.
            //Console.Write("첫 번째 정수를 입력하세요: ");
            //int a = int.Parse(Console.ReadLine());
            //Console.Write("첫 번째 정수를 입력하세요: ");
            //int b = int.Parse(Console.ReadLine());
            //Console.Write("첫 번째 정수를 입력하세요: ");
            //int c = int.Parse(Console.ReadLine());


            ////if 문을 사용해서 최대값 구한다.
            //int max = a;  // 초기 최대값을 a로 설정
            //if (b > max)
            //    max = b;
            //if (c > max)
            //    max = c;

            ////결과 출력
            //Console.WriteLine("최대값 : " + max);


            //            문제 2.점수에 따른 학점 평가
            //문제 설명:
            //            학생의 점수를 입력받아 아래 기준에 따라 학점을 출력하는 프로그램을 작성하세요.

            //90 이상: A 학점
            //80 이상 90 미만: B 학점
            //70 이상 80 미만: C 학점
            //60 이상 70 미만: D 학점
            //60 미만: F 학점


            //// 학생의 점수를 입력받는다.
            //Console.Write("학생의 점수를 입력하세요 (0 ~ 100): ");
            //int score = int.Parse(Console.ReadLine());
            //string grade;

            //// if-else if문을 사용하여 점수에 따른 학점을 결정한다.
            //if (score >= 90)
            //    grade = "A";
            //else if (score >= 80)
            //    grade = "B";
            //else if (score >= 70)
            //    grade = "C";
            //else if (score >= 60)
            //    grade = "D";
            //else
            //    grade = "F";

            //// 결과 출력
            //Console.WriteLine("학점: " + grade);



            //            문제 3.간단한 사칙연산 계산기
            //문제 설명:
            //사용자로부터 두 개의 숫자와 연산자(+, -, *, /)를 입력받아 해당 연산을 수행하고 결과를 출력하는 계산기 프로그램을 작성하세요.
            //요구사항:

            //            두 개의 숫자와 연산자 기호를 입력받습니다.
            //if문을 사용하여 연산자를 확인하고 해당 연산을 수행합니다.
            //나눗셈의 경우 0으로 나누는 상황을 처리하여 에러 메시지를 출력합니다.
            //결과는 “결과: X” 형식으로 출력합니다.

            // 사용자로부터 두 개의 숫자를 입력받는다.
            //Console.Write("첫 번째 숫자를 입력하세요: ");
            //double num1 = double.Parse(Console.ReadLine());
            //Console.Write("두 번째 숫자를 입력하세요: ");
            //double num2 = double.Parse(Console.ReadLine());

            //// 사용자로부터 연산자를 입력받는다.
            //Console.Write("연산자 (+, -, *, /)를 입력하세요: ");
            //char op = Console.ReadLine()[0];

            //double result = 0;
            //bool valid = true;

            //// 입력받은 연산자에 따라 if문을 사용해 연산을 수행한다.
            //if (op == '+')
            //{
            //    result = num1 + num2;
            //}
            //else if (op == '-')
            //{
            //    result = num1 - num2;
            //}
            //else if (op == '*')
            //{
            //    result = num1 * num2;
            //}
            //else if (op == '/')
            //{
            //    // 0으로 나누는 경우를 체크
            //    if (num2 != 0)
            //        result = num1 / num2;
            //    else
            //    {
            //        Console.WriteLine("0으로 나눌 수 없습니다.");
            //        valid = false;
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("잘못된 연산자입니다.");
            //    valid = false;
            //}

            //// 연산이 정상적으로 수행되었으면 결과 출력
            //if (valid)
            //    Console.WriteLine("결과: " + result);


            //캐릭터를 선택하세요 (1.검사 2.마법사 3.도적) :
            //스위치문사용해보자

            //int iInput = 0;
            //Console.Write("캐릭터를 선택하세요 (1.검사 2.마법사 3.도적): ");
            //iInput = int.Parse(Console.ReadLine());

            //switch(iInput)
            //{
            //    case 1:

            //        Console.WriteLine("검사 ");
            //        Console.WriteLine("공격력 100");
            //        Console.WriteLine("방어력  90");
            //        break;
            //    case 2:

            //        Console.WriteLine("마법사");
            //        Console.WriteLine("공격력 110");
            //        Console.WriteLine("방어력  80");
            //        break;
            //    case 3:

            //        Console.WriteLine("도적");
            //        Console.WriteLine("공격력 115");
            //        Console.WriteLine("방어력  70");
            //        break;
            //}


            //1
            //검사 
            //공격력 100
            //방어력  90

            //마법사
            //공격력 110
            //방어력  80

            //도적
            //공격력 115
            //방어력  70


            //반복문

            //초기화 / 조건문 /증감식
            //for(int i =1; i<=5; i++)
            //{
            //    Console.WriteLine("숫자 : " + i);
            //}

            //무한반복
            //for(; ; )
            //{
            //    Console.WriteLine("중요한건 꺽이지 않는 마음");
            //}


            //0부터 9까지 출력하기
            //for문활용하기

            //for(int i =0; i<10; i++)
            //{
            //    Console.WriteLine(i);
            //}

            //int sum = 0;

            ////1부터 10까지의 합 구하기
            //for(int i =1; i<=10; i++)
            //{
            //    //sum += i;
            //    sum = sum + i;

            //    Console.WriteLine($"sum : {sum} i : {i}");
            //}


            //Console.WriteLine("1부터 10까지의 합 : " + sum);



            //int count = 1; //초기화

            //while(count <= 5) //조건식
            //{
            //    Console.WriteLine("Count : " + count);

            //    count++; //증가,감소

            //    if(count == 3)
            //    {
            //        Console.WriteLine("3일때 반복문 탈출");
            //        break;
            //    }

            //}


            //Console.WriteLine("Count : " + count);


            //랜덤
            //Random rand = new Random(); //Random 객체를 생성한다.

            ////0이상 10 미만의 랜덤 정수 생성
            //int randomInRange =0;
            //for (int i =0; i<100; i++)
            //{
            //    randomInRange = rand.Next(5, 15);
            //    Console.WriteLine("5부터 14까지: " + randomInRange);

            //}

            //대장장이 키우기
            //도끼등급 SSS  10%
            //도끼등급 SS   40%
            //도끼등급 S    50%

            //Random rand = new Random(); //랜덤값을 뽑는 문장

            //int rnd = 0;

            //for(int i =0; i<20; i++)
            //{
            //    rnd = rand.Next(1, 101);  //1~100


            //    if(rnd >= 1 && rnd <=10)
            //    {
            //        Console.WriteLine("도끼등급 SSS");
            //    }
            //    else if (rnd >= 11 && rnd <= 40)
            //    {
            //        Console.WriteLine("도끼등급 SS");
            //    }
            //    else
            //    {
            //        Console.WriteLine("도끼등급 S");
            //    }
            //    Thread.Sleep(500); //0.5초정도로 뽑아라.

            //}



            //do while
            //1회 무조건 실행하고  while문과 같이 조건진행

            //int x = 5;

            //do
            //{
            //    Console.WriteLine("최소 한번은 실행됩니다.");
            //    x--;
            //} while (x > 0);

            //break 문
            //반복문을 탈출할수있다.

            //for(int i=1; i<=10; i++)
            //{
            //    if (i == 5)
            //    {
            //        break;
            //    }


            //    Console.WriteLine(i);                   
            //}

            //continue 
            //현재 반복을 건너뛰고 다음 반복으로 넘어간다.

            //for (int i = 1; i <= 10; i++)
            //{
            //    if (i % 2 == 0)
            //    {
            //        continue;
            //    }

            //    Console.WriteLine(i); //홀수만 출력
            //}


            //goto 

            //int n = 1;

            //start:

            //if(n <=5)
            //{
            //    Console.WriteLine(n);
            //    n++;

            //    goto start; //레이블로 이동
            //}


            //1시에 시작



        }
    }
}
