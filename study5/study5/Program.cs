
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace study5
{
    class Program
    {
        static void Main(string[] args)
        {
            ////숫자 데이터 형식: 정수와 실수를 다룰 때 사용하는 다양한 타입
            //int integerNum = 10;     //정수 데이터
            //float floatNum = 3.14f;  //단정밀도 실수
            //double doubleNum = 3.14159; //배정밀도 실수 

            //Console.WriteLine(integerNum);
            //Console.WriteLine(floatNum); 
            //Console.WriteLine(doubleNum);

            //정수 데이터형식: 소수점이 없는 숫자를 표현 
            //int intValue = -100;  //4바이트 크기의 정수
            //long longValue = 1234567890L; //8바이트 크기의 정수

            //Console.WriteLine(intValue); //출력: -100
            //Console.WriteLine(longValue); //출력 : 1234567890


            ////부호 있는 정수 : 음수와 양수를 모두 표현 가능
            //sbyte signedByte = -50; //1바이트 크기
            //short signedShort = -32000; //2바이트 크기
            //int signedInt = -200000000; //4바이트 크기

            //Console.WriteLine(signedByte);
            //Console.WriteLine(signedShort);
            //Console.WriteLine(signedInt);

            //부호없는 정수 데이터 형식
            //byte unsignedByte = 255; //1바이트 크기
            //ushort unsignedShort = 65000; //2바이트 크기
            //uint unsignedInt = 4000000000; //4바이트 크기

            //Console.WriteLine(unsignedByte);
            //Console.WriteLine(unsignedShort);
            //Console.WriteLine(unsignedInt);


            ////실수형 데이터 형식: 소수점을 포함한 숫자를 표현
            //float singlePrecision = 3.14f;   //단정밀도 실수 
            //double doublePrecision = 3.1415926535; //배정밀도 실수 (8바이트)
            //decimal highPrecision = 3.141592653545646546545m; //고정밀도 (16바이트)

            //Console.WriteLine(singlePrecision);
            //Console.WriteLine(doublePrecision);
            //Console.WriteLine(highPrecision);


            //char형식: 단일 문자를 표현
            //char letter = 'A'; //문자 'A' 저장
            //char symbol = '#'; //특수 기호 저장
            //char number = '9'; //숫자 형태의 문자 저장(문자 '9',숫자 9 아님)

            //Console.WriteLine(letter);
            //Console.WriteLine(symbol);
            //Console.WriteLine(number);

            //string 형식: 여러 문자를 저장
            //string greeting = "Hello World"; //문자열 저장
            //string name = "Alice"; //이름 저장

            ////Console.WriteLine(greeting); //Hello,World
            ////Console.WriteLine(name);  //출력 : Alice

            ////Hello World Alice
            //Console.Write(greeting +" "+ name);


            //bool형식 : 참(true) =1   거짓 (false) =0

            //bool isRunning = true;  //프로그램 실행 상태
            //bool isFinished = false; //프로그램 종료 상태



            //Console.WriteLine(isRunning); 
            //Console.WriteLine(isFinished);

            ////닷넷 형식 : 기본 형식의 닷넷표현
            //Int32 number = 123; //int닷넷형식
            //String text = "Hello"; //string의 닷넷 형식
            //Boolean flag = true; //bool의 닷넷 형식

            //Console.WriteLine(number);
            //Console.WriteLine(text);
            //Console.WriteLine(flag);


            //int 래퍼 형식의 메서드 활용
            int number = 123;

            string numberAsString = number.ToString(); //정수를 문자열로 변환

            //bool 래퍼형식
            bool flag = true;

            string flagAsString = flag.ToString(); //논리값을 문자열로 변환

            Console.WriteLine(numberAsString);
            Console.WriteLine(flagAsString);


        }
    }
}
