using LotterySystem.Rule;

namespace LotterySystem;

/// <summary>
/// 抽獎控制台界面類別，負責處理抽獎相關的用戶界面互動
/// </summary>
public class LotteryConsoleUI
{
    /// <summary>
    /// 管理員實例，用於獲取活動和獎項信息
    /// </summary>
    private AdminManager adminManager;

    /// <summary>
    /// 抽獎服務實例，用於處理抽獎核心邏輯
    /// </summary>
    private LotteryService lotteryService;

    /// <summary>
    /// 初始化抽獎控制台界面
    /// </summary>
    /// <param name="adminManager">管理員實例</param>
    /// <param name="lotteryService">抽獎服務實例</param>
    public LotteryConsoleUI(AdminManager adminManager, LotteryService lotteryService)
    {
        this.adminManager = adminManager;
        this.lotteryService = lotteryService;
    }

    /// <summary>
    /// 開始抽獎流程
    /// </summary>
    public void StartDraw()
    {
        var events = adminManager.GetAllEvents();
        if (events.Count == 0)
        {
            Console.WriteLine("目前沒有可用的活動");
            return;
        }

        Console.WriteLine("\n可選擇的活動：");
        for (int i = 0; i < events.Count; i++)
        {
            var eventInfo = events[i];
            var rule = eventInfo.LotteryRule;
            string ruleDescription = rule switch
            {
                WinCountRule wcr => $"每人最多中獎{wcr.MaxWinCount}次",
                WinCountAndAgeRule wcar => $"每人最多中獎{wcar.MaxWinCount}次，年齡限制{wcar.MinAge}-{wcar.MaxAge}歲",
                _ => "未知規則"
            };
            Console.WriteLine($"{i + 1}. {eventInfo.Id} - {eventInfo.Name} ({ruleDescription})");
        }

        Console.Write("請選擇活動編號: ");
        if (!int.TryParse(Console.ReadLine(), out int eventIndex) || eventIndex <= 0 || eventIndex > events.Count)
        {
            Console.WriteLine("無效的選擇");
            return;
        }

        var selectedEvent = events[eventIndex - 1];
        DrawProcess(selectedEvent);
    }

    /// <summary>
    /// 執行抽獎流程的用戶界面互動
    /// </summary>
    /// <param name="selectedEvent">選中的活動</param>
    private void DrawProcess(Event selectedEvent)
    {
        while (true)
        {
            Console.WriteLine("\n=== 獎項列表 ===");
            foreach (var prize in selectedEvent.Prizes)
            {
                Console.WriteLine($"{prize.Id}. {prize.Name} (剩餘: {prize.RemainingQuantity}/{prize.TotalQuantity})");
            }

            Console.Write("請選擇獎項代碼: ");
            string? prizeId = Console.ReadLine();
            if (string.IsNullOrEmpty(prizeId))
            {
                Console.WriteLine("無效的獎項代碼");
                continue;
            }

            var selectedPrize = selectedEvent.Prizes.FirstOrDefault(p => p.Id == prizeId);
            if (selectedPrize == null)
            {
                Console.WriteLine("找不到指定的獎項");
                continue;
            }

            if (selectedPrize.RemainingQuantity <= 0)
            {
                Console.WriteLine("該獎項已抽完");
                continue;
            }

            Console.Write("請輸入要抽取的數量: ");
            if (!int.TryParse(Console.ReadLine(), out int drawCount) || drawCount <= 0)
            {
                Console.WriteLine("無效的數量");
                continue;
            }

            if (drawCount > selectedPrize.RemainingQuantity)
            {
                Console.WriteLine("抽取數量超過剩餘獎項數量");
                continue;
            }

            // 檢查是否有足夠的合格參與者
            int eligibleCount = lotteryService.CheckEligibleParticipantsCount(selectedEvent);

            if (eligibleCount < drawCount)
            {
                Console.WriteLine($"警告：只有 {eligibleCount} 位參與者符合抽獎資格");
                Console.Write("是否要繼續抽獎？(Y/N): ");
                if (Console.ReadLine()?.ToUpper() != "Y")
                {
                    continue;
                }
            }

            try
            {
                // 執行抽獎
                var winners = lotteryService.Draw(selectedEvent, selectedPrize, drawCount);

                Console.WriteLine("\n=== 中獎名單 ===");
                foreach (var winner in winners)
                {
                    Console.WriteLine($"履歷編號: {winner.Id}, 姓名: {winner.Name}, 年齡: {winner.Age}, 已中獎次數: {winner.WinCount}");
                }

                Console.WriteLine($"\n獎項 {selectedPrize.Name} 剩餘數量: {selectedPrize.RemainingQuantity}/{selectedPrize.TotalQuantity}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"抽獎失敗: {ex.Message}");
                continue;
            }

            Console.Write("\n是否要繼續抽獎？(Y/N): ");
            if (Console.ReadLine()?.ToUpper() != "Y")
            {
                break;
            }
        }
    }
}