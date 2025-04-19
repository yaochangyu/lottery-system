class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        var adminManager = new AdminManager();
        var drawManager = new DrawManager(adminManager);

        // 初始化測試資料
        adminManager.GenerateTestData();

        while (true)
        {
            Console.WriteLine("\n=== 抽獎系統 ===");
            Console.WriteLine("1. 前台抽獎");
            Console.WriteLine("2. 後台管理");
            Console.WriteLine("3. 退出系統");
            Console.Write("請選擇: ");

            string choice = Console.ReadLine();
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

            string choice = Console.ReadLine();
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
        string eventCode = Console.ReadLine();
        Console.Write("請輸入活動名稱: ");
        string eventName = Console.ReadLine();

        try
        {
            adminManager.CreateEvent(eventCode, eventName);
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