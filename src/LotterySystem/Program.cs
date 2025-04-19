using LotterySystem.Rule;

namespace LotterySystem;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        var adminManager = new AdminManager();
        var lotteryService = new LotteryService();
        var drawManager = new DrawManager(adminManager, lotteryService);

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
                    drawManager.StartDraw();
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

    // 其餘方法保持不變
    static void AdminMenu(AdminManager adminManager)
    {
        // 保持原有實現不變
    }

    static void CreateEvent(AdminManager adminManager)
    {
        // 保持原有實現不變
    }

    static void ImportPrizes(AdminManager adminManager)
    {
        // 保持原有實現不變
    }

    static void ImportParticipants(AdminManager adminManager)
    {
        // 保持原有實現不變
    }
}
