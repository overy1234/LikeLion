using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExam
{
    //인터페이스를 활용하면 객체가 어떤 특정한 동작을 보장하면서도 다양한 형태로 사용
    //여러 동물을 공통된 방식으로 다룰수있다.

    //인터페이스 정의
    interface IAnimal
    {
        void Speak();
    }

    class Dog : IAnimal
    {
        public void Speak()
        {
            Console.WriteLine("멍멍");
        }
    }

    class Cat : IAnimal
    {
        public void Speak()
        {
            Console.WriteLine("야옹~");
        }
    }

    //인터페이스를 활용한 공통메서드
    class AnimalTrainer
    {
        public void Train(IAnimal animal)
        {
            Console.Write("동물이 소리를 냅니다.");
            animal.Speak();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AnimalTrainer trainer = new AnimalTrainer();

            IAnimal myDog = new Dog();
            IAnimal myCat = new Cat();

            trainer.Train(myDog);
            trainer.Train(myCat);

        }
    }
}
//Train(IAnimal animal) 메서드는 Dog, Cat 모두를 받을 수 있음 → 코드 재사용성 증가
// 추가적인 IAnimal을 구현한 새로운 동물이 생기더라도 Train() 메서드는 변경할 필요 없음 → 유지보수 용이