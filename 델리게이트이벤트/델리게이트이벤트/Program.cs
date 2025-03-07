using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 델리게이트이벤트
{
    class Program
    {
        //델리게이트 정의 - 메시지 출력을 위한 메서드 참조
        //string 매개변수를 받고 반환값이 없는 (void )메서드를 참조할 수있는 타입
        delegate void MessageHandler(string message);

        //델리게이트에 연결할 메서드
        //메서드 형과 타입이런게 일치해야 받아줌
        static void DisplayMessage(string message)
        {
            Console.WriteLine($"메세지 : {message}");
        }

        static void DisplayUpperMessage(string message)
        {
            Console.WriteLine($"대문자 메시지: {message.ToUpper()}");
        }


        static void Main(string[] args)
        {
            Console.WriteLine("=== 간단한 델리게이트와 이벤트 예제 ===");

            //1.델리게이트 사용해보기
            Console.WriteLine("델리게이트1");

            //델리게이트 변수 선어 및 메서드 연결
            //DisplayMessage 메서드를 messageHandler 변수에 할당
            MessageHandler messagHandler = DisplayMessage;

            //델리게이트 호출 - 연결된 메서드가 실행됨
            messagHandler("안녕하세요");

            //델리게이트에 다른 메서드 추가 (멀티캐스트 델리게이트)
            // += 연산자로 메서드추가
            messagHandler += DisplayUpperMessage;

            //여러 메서드가 연결된 델리게이트 호출
            //등록된 모든 메서드가 순서대로 호출됨
            Console.WriteLine("여러 메서드 호출: ");
            messagHandler("Hello ");






        }
    }
}
