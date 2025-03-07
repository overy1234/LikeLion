using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hello; //네임스페이스 편하게 쓸수있다. using

namespace Hello
{
    public class Say
    {
        public void SayHello()
        {
            Console.WriteLine("안녕하세요!");
        }
    }
}


namespace study35
{

    class Program
    {
        static void Main(string[] args)
        {
            Say sa = new Say();  
            sa.SayHello();

        }
    }
}
