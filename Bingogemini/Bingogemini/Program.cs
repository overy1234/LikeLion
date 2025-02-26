using System;
using System.Collections.Generic;
using System.Linq;

public class BingoGame
{
    private int[,] card;
    private List<int> drawnNumbers;
    private Random random;
    private bool[,] marked; // 맞춘 숫자 표시를 위한 2차원 배열

    public BingoGame()
    {
        card = new int[5, 5];
        drawnNumbers = new List<int>();
        random = new Random();
        marked = new bool[5, 5]; // marked 배열 초기화
    }

    public void GenerateCard()
    {
        // 각 열에 맞는 숫자 범위로 숫자 풀 생성
        List<int>[] columnNumberPools = new List<int>[5];
        int[] startNumbers = { 1, 16, 31, 46, 61 };
        int[] endNumbers = { 15, 30, 45, 60, 75 };

        for (int i = 0; i < 5; i++)
        {
            columnNumberPools[i] = Enumerable.Range(startNumbers[i], endNumbers[i] - startNumbers[i] + 1).ToList();
            Shuffle(columnNumberPools[i]); // 각 숫자 풀을 섞음
        }

        // 빙고 카드에 숫자 할당
        for (int col = 0; col < 5; col++)
        {
            for (int row = 0; row < 5; row++)
            {
                if (row == 2 && col == 2) // 가운데는 FREE SPACE
                {
                    card[row, col] = 0; // 0은 FREE SPACE를 나타냄
                }
                else
                {
                    // 각 열의 숫자 풀에서 숫자 선택
                    card[row, col] = columnNumberPools[col][row];
                }
            }
        }
    }

    private void Shuffle<T>(List<T> list)
    {
        int n = list.Count;
        for (int i = n - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }

    public int DrawNumber()
    {
        int number;
        do
        {
            number = random.Next(1, 76); // 1부터 75까지 숫자
        } while (drawnNumbers.Contains(number));
        drawnNumbers.Add(number);
        return number;
    }

    public bool CheckBingo()
    {
        // 가로 빙고 확인
        for (int row = 0; row < 5; row++)
        {
            int[] rowLine = GetRow(row);
            Console.WriteLine($"가로 줄 {row + 1}: {string.Join(", ", rowLine)}"); // 디버깅 출력
            if (CheckLine(rowLine, row, true)) // CheckLine에 row, isRow=true 추가
            {
                Console.WriteLine($"가로 줄 {row + 1} 빙고!"); // 디버깅 출력
                return true;
            }
        }

        // 세로 빙고 확인
        for (int col = 0; col < 5; col++)
        {
            int[] colLine = GetColumn(col);
            Console.WriteLine($"세로 줄 {col + 1}: {string.Join(", ", colLine)}"); // 디버깅 출력
            if (CheckLine(colLine, col, false)) // CheckLine에 col, isRow=false 추가
            {
                Console.WriteLine($"세로 줄 {col + 1} 빙고!"); // 디버깅 출력
                return true;
            }
        }

        // 대각선 빙고 확인 (왼쪽 위에서 오른쪽 아래)
        int[] diagonal1Line = GetDiagonal1();
        Console.WriteLine($"대각선 줄 1: {string.Join(", ", diagonal1Line)}"); // 디버깅 출력
        if (CheckLine(diagonal1Line, -1, true, true)) // CheckLine에 isDiagonal1=true 추가
        {
            Console.WriteLine($"대각선 줄 1 빙고!"); // 디버깅 출력
            return true;
        }

        // 대각선 빙고 확인 (오른쪽 위에서 왼쪽 아래)
        int[] diagonal2Line = GetDiagonal2();
        Console.WriteLine($"대각선 줄 2: {string.Join(", ", diagonal2Line)}"); // 디버깅 출력
        if (CheckLine(diagonal2Line, -1, false, true)) // CheckLine에 isDiagonal2=true 추가
        {
            Console.WriteLine($"대각선 줄 2 빙고!"); // 디버깅 출력
            return true;
        }

        return false;
    }

    private bool CheckLine(int[] line, int lineIndex, bool isRow, bool isDiagonal = false) // CheckLine 수정
    {
        Console.WriteLine($"CheckLine 입력: {string.Join(", ", line)}"); // 디버깅 출력
        for (int i = 0; i < line.Length; i++)
        {
            int number = line[i];
            int row = isRow ? lineIndex : i;
            int col = isRow ? i : lineIndex;
            if (isDiagonal)
            {
                if (isRow) // isRow가 대각선1 나타냄
                {
                    row = i;
                    col = i;
                }
                else // isRow가 false면 대각선2 나타냄
                {
                    row = i;
                    col = 4 - i;
                }
            }

            if (number != 0 && !marked[row, col]) // 0은 FREE SPACE, marked 배열 확인
            {
                Console.WriteLine($"CheckLine 결과: 빙고 아님"); // 디버깅 출력
                return false;
            }
        }
        Console.WriteLine($"CheckLine 결과: 빙고!"); // 디버깅 출력
        return true;
    }

    private int[] GetRow(int row)
    {
        int[] line = new int[5];
        for (int col = 0; col < 5; col++)
        {
            line[col] = card[row, col];
        }
        return line;
    }

    private int[] GetColumn(int col)
    {
        int[] line = new int[5];
        for (int row = 0; row < 5; row++)
        {
            line[row] = card[row, col];
        }
        return line;
    }

    private int[] GetDiagonal1() // 왼쪽 위에서 오른쪽 아래
    {
        return new int[] { card[0, 0], card[1, 1], card[2, 2], card[3, 3], card[4, 4] };
    }

    private int[] GetDiagonal2() // 오른쪽 위에서 왼쪽 아래
    {
        return new int[] { card[0, 4], card[1, 3], card[2, 2], card[3, 1], card[4, 0] };
    }

    public void PrintCard()
    {
        Console.WriteLine("빙고 카드:");
        Console.WriteLine("--------------------");
        Console.WriteLine(" B  I  N  G  O");
        Console.WriteLine("--------------------");
        for (int row = 0; row < 5; row++)
        {
            Console.Write(" ");
            for (int col = 0; col < 5; col++)
            {
                if (row == 2 && col == 2)
                {
                    Console.Write("FREE ");
                }
                else
                {
                    if (marked[row, col]) // 맞춘 숫자일 경우 'X' 표시
                    {
                        Console.Write(" X  ");
                    }
                    else
                    {
                        Console.Write(string.Format("{0,2} ", card[row, col]));
                    }
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine("--------------------");
    }

    public void PrintDrawnNumbers()
    {
        Console.WriteLine("뽑힌 숫자:");
        foreach (int number in drawnNumbers)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
    }

    public bool MarkNumber(int number) // 숫자 맞추기 메서드
    {
        for (int row = 0; row < 5; row++)
        {
            for (int col = 0; col < 5; col++)
            {
                if (card[row, col] == number)
                {
                    marked[row, col] = true; // 숫자 맞춤 표시
                    drawnNumbers.Add(number); // 뽑힌 숫자 목록에 추가 (빙고 체크를 위해)
                    return true; // 숫자 찾음
                }
            }
        }
        return false; // 숫자 못 찾음
    }
}

public class Bingo
{
    public static void Main(string[] args)
    {
        BingoGame game = new BingoGame();
        game.GenerateCard();
        game.PrintCard();

        while (!game.CheckBingo())
        {
            Console.WriteLine("숫자를 입력하세요 (1-75):");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int number))
            {
                if (number >= 1 && number <= 75)
                {
                    if (game.MarkNumber(number))
                    {
                        Console.WriteLine($"숫자 {number}를 맞췄습니다!");
                    }
                    else
                    {
                        Console.WriteLine($"카드에 숫자 {number}가 없습니다.");
                    }
                    game.PrintCard(); // 매번 카드 상태 출력
                    game.PrintDrawnNumbers(); // 뽑힌 숫자 목록 출력 (선택 사항)

                    if (game.CheckBingo())
                    {
                        Console.WriteLine("빙고!");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("1부터 75 사이의 숫자를 입력하세요.");
                }
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다. 숫자를 입력하세요.");
            }
        }
    }
}
