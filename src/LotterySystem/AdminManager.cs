using LotterySystem.Rule;

namespace LotterySystem;

/// <summary>
/// 管理員類別，負責管理活動、獎項和參與者
/// </summary>
public class AdminManager
{
    /// <summary>
    /// 活動列表
    /// </summary>
    private List<Event> events = new List<Event>();

    /// <summary>
    /// 隨機數生成器，用於生成測試數據
    /// </summary>
    private Random random = new Random();

    /// <summary>
    /// 創建新的抽獎活動
    /// </summary>
    /// <param name="eventCode">活動代碼</param>
    /// <param name="eventName">活動名稱</param>
    /// <param name="lotteryRule">中獎規則</param>
    /// <exception cref="Exception">當活動代碼已存在時拋出異常</exception>
    public void CreateEvent(string eventCode, string eventName, ILotteryRule lotteryRule)
    {
        if (events.Any(e => e.Id == eventCode))
        {
            throw new Exception("活動代碼已存在");
        }

        Event newEvent = new Event(eventCode, eventName, lotteryRule);
        events.Add(newEvent);
    }

    /// <summary>
    /// 匯入獎項到指定活動
    /// </summary>
    /// <param name="eventCode">活動代碼</param>
    /// <param name="prizes">要匯入的獎項列表</param>
    /// <exception cref="Exception">當找不到指定的活動時拋出異常</exception>
    public void ImportPrizes(string eventCode, List<Prize> prizes)
    {
        var targetEvent = events.FirstOrDefault(e => e.Id == eventCode);
        if (targetEvent == null)
        {
            throw new Exception("找不到指定的活動");
        }

        foreach (var prize in prizes)
        {
            targetEvent.AddPrize(prize);
        }
    }

    /// <summary>
    /// 匯入參與者到指定活動
    /// </summary>
    /// <param name="eventCode">活動代碼</param>
    /// <param name="participants">要匯入的參與者列表</param>
    /// <exception cref="Exception">當找不到指定的活動時拋出異常</exception>
    public void ImportParticipants(string eventCode, List<Participant> participants)
    {
        var targetEvent = events.FirstOrDefault(e => e.Id == eventCode);
        if (targetEvent == null)
        {
            throw new Exception("找不到指定的活動");
        }

        foreach (var participant in participants)
        {
            targetEvent.AddParticipant(participant);
        }
    }

    /// <summary>
    /// 獲取所有活動列表
    /// </summary>
    /// <returns>活動列表</returns>
    public List<Event> GetAllEvents()
    {
        return events;
    }

    /// <summary>
    /// 生成測試數據
    /// </summary>
    public void GenerateTestData()
    {
        // 創建測試活動
        var winCountRule = new WinCountRule(2);
        CreateEvent("EV001", "年終抽獎活動", winCountRule);

        // 生成測試獎項
        string[] prizeNames = { "賓士", "BMW", "奧迪", "保時捷", "法拉利", "藍寶堅尼", "瑪莎拉蒂", "勞斯萊斯", "賓利", "麥拉倫" };
        var prizes = new List<Prize>();
        for (int i = 1; i <= 10; i++)
        {
            prizes.Add(new Prize(
                $"P{i:D3}",
                prizeNames[i-1],
                random.Next(5, 20),
                $"{prizeNames[i-1]}.jpg"
            ));
        }
        ImportPrizes("EV001", prizes);

        // 生成測試名單
        string[] surnames = { "王", "李", "張", "劉", "陳", "楊", "黃", "趙", "周", "吳", "余", "林", "鄭", "謝", "郭" };
        var participants = new List<Participant>();
        for (int i = 1; i <= 100000; i++)
        {
            string name = surnames[random.Next(surnames.Length)] + "XX";
            int age = random.Next(15, 70); // 年齡範圍 15-70 歲
            participants.Add(new Participant(i, name, age));
        }
        ImportParticipants("EV001", participants);
    }
}