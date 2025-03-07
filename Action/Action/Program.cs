using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Action1
{
    

   
    class Program
    {
        //델리게이트와 이벤트를 더쉽게 만든 Action  
        static void SayHello()
        {
            Console.WriteLine("안녕하세요");
        }

        static void ShowNotification()
        {
            Console.WriteLine("중요한 알림이 있습니다.");
        }

        static void HelloWorld(string message)
        {
            Console.WriteLine("신규메세지" + message);
        }


        static void Main(string[] args)
        {
            //Action은 매개변수가 없고 반환값이 없는 메서드를 참조
            //메서드 이름을 변수에 저장한다고 생각하면 쉬움
            Action sayHello = SayHello;

            sayHello += ShowNotification;

            sayHello?.Invoke();

            Action<string> h = null;

            h += HelloWorld;

            h?.Invoke("이게 액션이다.");

            Action noti = null;

            noti += () => Console.WriteLine("인자없는 액션이다.");

            noti?.Invoke();

            Action<int> Square = number => Console.WriteLine(number * number);

            Square(5);

        }
    }
}
