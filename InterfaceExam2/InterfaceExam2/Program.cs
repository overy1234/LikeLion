using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExam2
{
    //인터페이스를 사용하면 기존 코드 변경 없이 새로운 기능 추가가 가능함.
    //다양한 결제 시스템 추가(Open-Closed Principle)

    interface IPayment
    {
        void ProcessPayment();
    }


    //신용카드 결제 클래스
    class CreditCardPayment : IPayment
    {
        public void ProcessPayment()
        {
            Console.WriteLine("신용카드 결제 완료!");
        }
    }

    class PayPalPayment : IPayment
    {
        public void ProcessPayment()
        {
            Console.WriteLine("PayPal 결제완료");
        }
    }







    //결제처리기
    class PaymentProcessor
    {
        public void Pay(IPayment payment)
        {
            payment.ProcessPayment();
        }
    }


   


    class Program
    {
        static void Main(string[] args)
        {
            PaymentProcessor processor = new PaymentProcessor();

            IPayment creditCard = new CreditCardPayment();
            IPayment paypal = new PayPalPayment();

            processor.Pay(paypal);
           

        }
    }
}
