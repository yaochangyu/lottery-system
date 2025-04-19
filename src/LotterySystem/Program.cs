using LotterySystem.Rule;

namespace LotterySystem;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        var adminManager = new AdminManager();
        var lotteryService = new LotteryService();
        var lotteryUI = new LotteryConsoleUI(adminManager, lotteryService);


        // 初始化測試資料
        adminManager.GenerateTestData();

        while (true)
        {
            Console.WriteLine("\n=== 抽獎系統 ===");
            Console.WriteLine("1. 前台抽獎");
            Console.WriteLine("2. 後台管理");
            Console.WriteLine("3. 退出系統");
            Console.Write("請選擇: ");

            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    lotteryUI.StartDraw();
                    break;
                case "2":
                    AdminMenu(adminManager);
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("無效的選擇，請重新輸入");
                    break;
            }
        }
    }

    static void AdminMenu(AdminManager adminManager)
    {
        while (true)
        {
            Console.WriteLine("\n=== 後台管理 ===");
            Console.WriteLine("1. 建立活動");
            Console.WriteLine("2. 匯入獎項");
            Console.WriteLine("3. 匯入名單");
            Console.WriteLine("4. 返回主選單");
            Console.Write("請選擇: ");

            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    CreateEvent(adminManager);
                    break;
                case "2":
                    ImportPrizes(adminManager);
                    break;
                case "3":
                    ImportParticipants(adminManager);
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("無效的選擇，請重新輸入");
                    break;
            }
        }
    }

    static void CreateEvent(AdminManager adminManager)
    {
        Console.Write("請輸入活動代碼: ");
        string? eventCode = Console.ReadLine();
        Console.Write("請輸入活動名稱: ");
        string? eventName = Console.ReadLine();

        Console.WriteLine("\n請選擇中獎規則：");
        Console.WriteLine("1. 僅限制中獎次數");
        Console.WriteLine("2. 限制中獎次數和年齡");
        Console.Write("請選擇: ");

        string? ruleChoice = Console.ReadLine();
        ILotteryRule lotteryRule;

        switch (ruleChoice)
        {
            case "1":
                Console.Write("請輸入每人最多中獎次數 (預設: 2): ");
                if (int.TryParse(Console.ReadLine(), out int maxWinCount))
                {
                    lotteryRule = new WinCountRule(maxWinCount);
                }
                else
                {
                    lotteryRule = new WinCountRule();
                }
                break;
            case "2":
                Console.Write("請輸入每人最多中獎次數 (預設: 2): ");
                int.TryParse(Console.ReadLine(), out int maxWinCount2);

                Console.Write("請輸入最小年齡 (預設: 18): ");
                int.TryParse(Console.ReadLine(), out int minAge);

                Console.Write("請輸入最大年齡 (預設: 65): ");
                int.TryParse(Console.ReadLine(), out int maxAge);

                lotteryRule = new WinCountAndAgeRule(
                    maxWinCount2 > 0 ? maxWinCount2 : 2,
                    minAge > 0 ? minAge : 18,
                    maxAge > 0 ? maxAge : 65
                );
                break;
            default:
                Console.WriteLine("無效的選擇，使用預設規則");
                lotteryRule = new WinCountRule();
                break;
        }

        try
        {
            adminManager.CreateEvent(eventCode!, eventName!, lotteryRule);
            Console.WriteLine("活動建立成功");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"錯誤: {ex.Message}");
        }
    }

    static void ImportPrizes(AdminManager adminManager)
    {
        // 這裡可以實作從檔案匯入獎項的功能
        Console.WriteLine("獎項匯入功能尚未實作");
    }

    static void ImportParticipants(AdminManager adminManager)
    {
        // 這裡可以實作從檔案匯入名單的功能
        Console.WriteLine("名單匯入功能尚未實作");
    }
}
