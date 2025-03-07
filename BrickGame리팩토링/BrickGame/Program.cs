using System;
using System.Runtime.InteropServices;



//리팩토링이 완료되었습니다. 주요 개선 사항은 다음과 같습니다:
//코드 구조화 및 모듈화
//각 클래스의 책임을 명확히 분리
//메서드를 작은 단위로 분리하여 가독성 향상
//상수 값을 의미 있는 이름으로 정의
//네이밍 컨벤션 개선
//헝가리안 표기법 제거
//일관된 네이밍 규칙 적용
//변수와 메서드 이름을 더 명확하게 변경
//코드 가독성 향상
//불필요한 주석 제거 및 자체 문서화 코드 작성
//메서드 크기 축소
//논리적 그룹화를 통한 코드 구조 개선
//성능 최적화
//불필요한 반복문 제거
//조건문 최적화
//메모리 사용 개선
//오류 처리 개선
//경계 조건 처리 강화
//예외 상황 고려
//데이터 구조 개선
//프로퍼티 사용으로 캡슐화 강화
//명확한 주석으로 데이터 의미 설명
//상수 정의를 통한 매직 넘버 제거
//이제 코드가 더 읽기 쉽고, 유지보수가 용이하며, 확장성이 좋아졌습니다. 게임의 기능은 그대로 유지하면서 코드 품질이 크게 향상되었습니다.
//실행하시면 이전과 동일하게 작동하되, 코드는 더 깔끔하고 관리하기 쉬워졌습니다. 추가적인 수정이나 개선이 필요하신 부분이 있다면 말씀해 주세요.


namespace BrickGame
{
    internal class Program
    {
        [DllImport("msvcrt.dll")]
        public static extern int _getch();

        private static void SetCursorPosition(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }

        private static void ConfigureConsole()
        {
            const int WINDOW_WIDTH = 80;
            const int WINDOW_HEIGHT = 25;
            
            Console.SetWindowSize(WINDOW_WIDTH, WINDOW_HEIGHT);
            Console.SetBufferSize(WINDOW_WIDTH, WINDOW_HEIGHT);
        }

        static void Main(string[] args)
        {
            ConfigureConsole();

            var gameManager = new GameManager();
            gameManager.Initialize();

            const int FRAME_DELAY_MS = 50;
            var lastFrameTime = Environment.TickCount;

            while (true)
            {
                var currentTime = Environment.TickCount;
                if (currentTime - lastFrameTime >= FRAME_DELAY_MS)
                {
                    lastFrameTime = currentTime;
                    gameManager.Progress();
                    gameManager.Render();
                }
            }
        }
    }
}
