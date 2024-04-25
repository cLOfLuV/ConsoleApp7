
using System;
using System.Threading;

namespace yong
{
    internal class Program //하 오류 쥰내 많아유 진짜루다가 ㅠㅜ
    {
        private static Character player;

        private static bool isResting = false;
        private static bool isInterrupted = false;
        static void Main(string[] args)
        {
            DBDB();//데베임
            ininintro();// 겜 인트로 ㅇㅇㅇ
        }

        static void DBDB()
        {
            player = new Character("세계최강지강권용", "대마법사", 1, 10, 5, 100, 1000);//ㅋㅋㅋㅋㅋㅋ
        }

        static void ininintro()
        {
            Console.Clear();//지원튜터님이 말한 클리어..클리어가 제일 편하드라

            Console.WriteLine();
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1. 상태보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("4. 휴식하기");
            Console.WriteLine("원하시는 행동을 입력해주세요."); // 진짜?

            int input = CheckValidInput(1, 4);

            switch (input)
            {
                case 1:
                    ChaInfo();
                    break;
                case 2:
                    MyCharacterInventory();
                    break;
                case 3:
                    MyCharacterShop();
                    break;
                case 4:
                    Console.WriteLine("200 gold를 소모하여 체력을 전부 회복합니다. 휴식하시겠습니까? (Y/N)");
                    char choice = char.ToUpper(Console.ReadKey().KeyChar);
                    if (choice == 'Y')
                    {
                        Rest();
                    }
                    else if (choice == 'N')
                    {
                        ininintro();
                    }
                    else
                    {
                        Console.WriteLine("\n잘못된 입력입니다.");
                        Thread.Sleep(2000);
                        ininintro();
                    }
                    break;
            } //case 5: 쉬고싶음 자고싶음 롤하고싶음
        }

        static void ChaInfo()
        {
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("상태 보기");
            Console.WriteLine($"Lv. {player.Level}"); //이거 설마 나중에 쓰려고 만든거 아니지? 지금 쓸모가 없던데
            Console.WriteLine($"{player.Name}({player.Job})"); // 왼쪽 이름 오른쪽 직업

            int prevAtk = player.Atk;
            int prevDef = player.Def;
            int prevHp = player.Hp;

            if (player.IsGabEquipped) player.Def += 5;
            if (player.isSwordEquipped) player.Atk += 7;
            if (player.isEyeEquipped) player.Atk += 10;

            Console.WriteLine($"공격력 : {player.Atk} ({(player.Atk - prevAtk > 0 ? $"+{player.Atk - prevAtk}" : "")})");//이건 인터넷에서 가져옴..너무어렵
            Console.WriteLine($"방어력 : {player.Def} ({(player.Def - prevDef > 0 ? $"+{player.Def - prevDef}" : "")})");
            Console.WriteLine($"체력 : {player.Hp} ({(player.Hp - prevHp > 0 ? $"+{player.Hp - prevHp}" : "")})");

            Console.WriteLine($"Gold : {player.Gold}");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("0. 나가기");

            int input = CheckValidInput(0, 0);

            switch (input)
            {
                case 0:
                    if (player.IsGabEquipped) player.Def = prevDef;
                    if (player.isSwordEquipped) player.Atk = prevAtk; // 공격력 가시화
                    if (player.isEyeEquipped) player.Atk = prevAtk;
                    ininintro();
                    break;
            }
        }

        static void MyCharacterInventory()
        {

            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다."); //더만들고싶은데 귀찮아... 
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine($"{(player.IsGabEquipped ? "(E)" : "")}  무쇠갑옷 | 방어력 + 5 | 무쇠로 만들어져 튼튼한 갑옷입니다");
            Console.WriteLine($"{(player.isSwordEquipped ? "(E)" : "")}  스파르타 창 | 공격력 +7 | 스파르타의 전사들이 사용했다는 전설의 창입니다. ");
            Console.WriteLine($"{(player.isEyeEquipped ? "(E)" : "")}  낡은 검 | 공격력 +2 | 쉽게 볼 수 있는 낡은 검 입니다.");
            Console.WriteLine($"{(player.isEyeEquipped ? "(E)" : "")}  혁매의 실시간 감시의 눈 | 공격력 +10 | 금속성 물질까지 투시해 볼 수 있다.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1. 장착관리");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요."); // 수면이요 수면

            int input = CheckValidInput(0, 1);
            switch (input)
            {
                case 0:
                    ininintro();
                    break;
                case 1:
                    EQITEM();
                    break;
            }
        }

        static void EQITEM()
        {
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("장착하고 싶은 아이템을 선택하세요."); // 아 4번오류 실화

         
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine($"1. {(player.IsGabEquipped ? "(E)" : "")} 무쇠갑옷 | 방어력 + 5 | 무쇠로 만들어져 튼튼한 갑옷입니다");
            Console.WriteLine($"2. {(player.IsGabEquipped ? "(E)" : "")} 스파르타 창 | 공격력 + 7 | 스파르타의 전사들이 사용했다는 전설의 창입니다. ");
            Console.WriteLine($"3. {(player.isSwordEquipped ? "(E)" : "")} 낡은 검 | 공격력 +2 | 쉽게 볼 수 있는 낡은 검 입니다.");
            Console.WriteLine($"4. {(player.isEyeEquipped ? "(E)" : "")} 혁매의 실시간 감시의 눈 | 공격력 + 10 | 금속성 물질까지 투시해 볼 수 있다.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("0. 나가기");

            int prevAtk = player.Atk;
            int prevDef = player.Def;
            int prevHp = player.Hp; // 이건 한바퀴 도니까 왜 넣었더라 기억이 안난다.. // 빼면 오류뜨네.. 위에서 선언을 안해준듯

            int input = CheckValidInput(0, 4);

            switch (input)
            {
                case 0:
                    MyCharacterInventory();
                    break;
                case 1:
                    EquipItem("무쇠갑옷", 5);
                    break;
                case 2:
                    EquipItem("스파르타 창", 7);
                    break;
                case 3:
                    EquipItem("낡은 검", 2);
                    break;
                case 4:
                    EquipItem("혁매의 실시간 감시의 눈", 10);
                    break;
            }


            Thread.Sleep(2000); // 대기함수 안넣으면 문자 출력이 안되던데 혹시 아시는분..?
            MyCharacterInventory();
        }

        static void MyCharacterShop()
        {
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("상점에 오신 것을 환영합니다.");
            Console.WriteLine($"보유 골드: {player.Gold}");
            Console.WriteLine("구매할 아이템을 선택하세요.");
            Console.WriteLine();
            Console.WriteLine("[상품 목록]");
            Console.WriteLine("1. 무쇠갑옷 | 방어력 +5 | 가격: 200 Gold");
            Console.WriteLine("2. 스파르타 창 | 공격력 +7 | 가격: 150 Gold");
            Console.WriteLine("3. 낡은 검 | 공격력 +2 | 가격: 50 Gold");
            Console.WriteLine("4. 혁매의 실시간 감시의 눈 | 공격력 +10 | 가격: 300 Gold");
            Console.WriteLine("0. 나가기");

            int input = CheckValidInput(0, 4);

            switch (input)
            {
                case 0:
                    ininintro();
                    break;
                case 1:
                    BuyItem("무쇠갑옷", 200, 5, true);
                    break;
                case 2:
                    BuyItem("스파르타 창", 150, 7, true);
                    break;
                case 3:
                    BuyItem("낡은 검", 50, 2, true);
                    break;
                case 4:
                    BuyItem("혁매의 실시간 감시의 눈", 300, 10, true);
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다."); // 초기자금으로 풀템 삽가능이지 ㅋㅋ
                    break;
            }
        }

        static void BuyItem(string itemName, int price, int statIncrease, bool isEquipable) // 진짜 이거 짜느라 고생좀 했다 ㅠㅠㅠ 쳇 gpt 살앙해 ㅠㅠ
        {
            if (player.IsItemPurchased(itemName))
            {
                Console.WriteLine("이미 구매한 아이템입니다.");
            }
            else if (player.Gold >= price)
            {
                player.Gold -= price;
                player.AddItemToInventory(itemName, statIncrease, isEquipable);
                Console.WriteLine($"아이템 구매를 성공했습니다. {itemName}을(를) 구매했습니다.");


                Thread.Sleep(2000);
                MyCharacterShop();
            }
            else
            {
                Console.WriteLine("Gold가 부족합니다.");
                MyCharacterShop();
            }
        }

        static void EquipItem(string itemName, int statIncrease)
        {
            if (!player.IsItemPurchased(itemName))
            {
                Console.WriteLine("상점에서 먼저 구매해주세요!");
                return;
            }

            if (player.IsItemEquipped(itemName))
            {
                Console.WriteLine("이미 착용한 아이템입니다.");
            }
            else
            {
                Console.WriteLine($"{itemName}을(를) 착용했습니다. {statIncrease} 만큼 스탯이 증가합니다.");


                switch (itemName)
                {
                    case "무쇠갑옷":
                        player.IsGabEquipped = true;
                        break;
                    case "스파르타 창":
                        player.isSwordEquipped = true;
                        break;


                    case "낡은 검":
                        player.isEyeEquipped = true;
                        break;
                    case "혁매의 실시간 감시의 눈":
                        player.isEyeEquipped = true;
                        break;
                }
            }



            ShowItemInfo();
        }

        static void ShowItemInfo()
        {
            MyCharacterInventory();
        }

        static void Rest()
        {
            if (player.Gold < 200)
            {
                Console.WriteLine("\nGold가 부족하여 휴식을 취할 수 없습니다.");
                Thread.Sleep(2000);
                ininintro();
                return;
            }

            isResting = true;

            Console.WriteLine("\n휴식을 취합니다...");
            Console.WriteLine("남은 시간: 20초");

            int originalLeft = Console.CursorLeft;

            for (int i = 20; i > 0; i--)
            {
                Thread.Sleep(1000); // 1초 대기

                if (isInterrupted)
                {
                    isResting = false;
                    isInterrupted = false;
                    Console.WriteLine("\n휴식이 중단되었습니다.");
                    Thread.Sleep(2000);
                    ininintro();
                    return;
                }

                Console.SetCursorPosition(originalLeft, Console.CursorTop);
                Console.Write($"{i,2}초");
            }

            if (isResting)
            {
                player.Gold -= 200;
                player.Hp = 100;

                Console.SetCursorPosition(originalLeft, Console.CursorTop);
                Console.WriteLine("\n휴식 완료! 200 Gold를 소모하여 체력을 회복했습니다.");
                Thread.Sleep(2000);

                ininintro();
            }
        }


        private static int CheckValidInput(int min, int max)
        {
            while (true)
            {
                string input = Console.ReadLine();

                bool parseSuccess = int.TryParse(input, out var ret);
                if (parseSuccess)
                {
                    if (ret >= min && ret <= max)
                        return ret;
                }
                Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
            }
        }
    }

    public class Character
    {
        public string Name { get; }
        public string Job { get; }
        public int Level { get; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Hp { get; set; }
        public int Gold { get; set; }
        public bool IsGabEquipped { get; set; }
        public bool isSwordEquipped { get; set; }
        public bool isEyeEquipped { get; set; }

        public bool IsItemPurchased(string itemName)
        {
            switch (itemName)
            {
                case "무쇠갑옷":
                    return IsGabEquipped;
                case "스파르타 창":
                    return isSwordEquipped;
                case "낡은 검":
                    return isEyeEquipped;
                case "혁매의 실시간 감시의 눈":
                    return isEyeEquipped;
                default:
                    return false;
            }
        }

        public bool IsItemEquipped(string itemName)
        {
            switch (itemName)
            {
                case "무쇠갑옷":
                    return IsGabEquipped;
                case "스파르타 창":
                    return isSwordEquipped;
                case "낡은 검":
                    return isEyeEquipped;
                case "혁매의 실시간 감시의 눈":
                    return isEyeEquipped;
                default:
                    return false;
            }
        }

        public void AddItemToInventory(string itemName, int statIncrease, bool isEquipable)
        {
            switch (itemName)
            {
                case "무쇠갑옷":
                    IsGabEquipped = true;
                    break;
                case "스파르타 창":
                    isSwordEquipped = true;
                    break;
                case "낡은 검":
                    isEyeEquipped = true;
                    break;
                case "혁매의 실시간 감시의 눈":
                    isEyeEquipped = true;
                    break;
            }
        }

        public Character(string name, string job, int level, int atk, int def, int hp, int gold)
        {
            Name = name;
            Job = job;
            Level = level;
            Atk = atk;
            Def = def;
            Hp = hp;
            Gold = gold;
        }
    }
}
