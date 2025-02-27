using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    class Program
    {
        //최대 아이템 개수(배열 크기)
        const int MAX_ITEMS = 10;

        //아이템 배열 (이름 저장)
        static string[] itemNames = new string[MAX_ITEMS];
        static int[] itemCounts = new int[MAX_ITEMS];


        //아이템 추가 함수
        static void AddItem(string name, int count)
        {
            for(int i =0; i<MAX_ITEMS; i++)
            {
                if (itemNames[i] == name)  //이미 있는 아이템이면 개수 증가
                {
                    itemCounts[i] += count;
                    return;
                }
            }

            //빈 슬롯에 새로운 아이템 추가
            for(int i=0; i<MAX_ITEMS; i++)
            {
                if (itemNames[i] == null)
                {
                    itemNames[i] = name;
                    itemCounts[i] = count;
                    return;
                }
            }
            Console.WriteLine("인벤토리가 가득 찼습니다.");

        }

        //아이템 제거 함수
        static void RemoveItem(string name, int count)
        {
            for (int i =0; i<MAX_ITEMS; i++)
            {
                if (itemNames[i] ==name) //이름하고 같은지
                {
                    if (itemCounts[i] >= count) //개수가 충분하면 차감
                    {
                        itemCounts[i] -= count;
                        if (itemCounts[i]==0) //개수가 0이면 삭제
                        {
                            itemNames[i] = null;
                        }
                        return;
                    }
                    else
                    {
                        Console.WriteLine("아이템 개수가 부족합니다!");
                        return;
                    }
                }
            }

            Console.WriteLine("아이템을 찾을 수 없습니다!");

        }


        //인벤토리 출력 함수
        static void ShowInventory()
        {
            Console.WriteLine("현재 인벤토리 : ");
            bool isEmpty = true;

            for(int i =0; i<MAX_ITEMS; i++)
            {
                if (itemNames[i] != null)
                {
                    Console.WriteLine($"{itemNames[i]} (x{itemCounts[i]})");
                    isEmpty = false;
                }
            }

            if(isEmpty)
            {
                Console.WriteLine("인벤토리가 비어 있습니다.");
            }
        }

        static void Main(string[] args)
        {
            //테스트 : 아이템 추가
            AddItem("포션", 5);
            AddItem("칼", 1);
            AddItem("포션", 3); //포션 개수 추가

            ShowInventory();

            //아이템 사용
            Console.WriteLine("포션 2개 사용");
            RemoveItem("포션", 2);
            ShowInventory();

            //테스트 : 없는 아이템 제거
            Console.WriteLine("방패 1개 제거 시도");
            RemoveItem("방패", 1);

            ShowInventory();


            //테스트: 모든 포션 제거
            Console.WriteLine("포션 6개 사용(초과 사용 테스트)");
            RemoveItem("포션", 6);
            ShowInventory();


        }
    }
}
