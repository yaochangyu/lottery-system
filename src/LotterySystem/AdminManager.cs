public class AdminManager
{
    private List<Event> events = new List<Event>();
    private Random random = new Random();

    public void CreateEvent(string eventCode, string eventName)
    {
        if (events.Any(e => e.EventCode == eventCode))
        {
            throw new Exception("活動代碼已存在");
        }

        Event newEvent = new Event(eventCode, eventName);
        events.Add(newEvent);
    }

    public void ImportPrizes(string eventCode, List<Prize> prizes)
    {
        var targetEvent = events.FirstOrDefault(e => e.EventCode == eventCode);
        if (targetEvent == null)
        {
            throw new Exception("找不到指定的活動");
        }

        foreach (var prize in prizes)
        {
            targetEvent.AddPrize(prize);
        }
    }

    public void ImportParticipants(string eventCode, List<Participant> participants)
    {
        var targetEvent = events.FirstOrDefault(e => e.EventCode == eventCode);
        if (targetEvent == null)
        {
            throw new Exception("找不到指定的活動");
        }

        foreach (var participant in participants)
        {
            targetEvent.AddParticipant(participant);
        }
    }

    public List<Event> GetAllEvents()
    {
        return events;
    }

    public void GenerateTestData()
    {
        // 創建測試活動
        CreateEvent("EV001", "年終抽獎活動");

        // 生成測試獎項
        string[] prizeNames = { "賓士", "BMW", "奧迪", "保時捷", "法拉利", "藍寶堅尼", "瑪莎拉蒂", "勞斯萊斯", "賓利", "麥拉倫" };
        var prizes = new List<Prize>();
        for (int i = 1; i <= 10; i++)
        {
            prizes.Add(new Prize(
                $"P{i:D3}",  // 使用格式化的字串，如 P001, P002 等
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
            participants.Add(new Participant(i, name));
        }
        ImportParticipants("EV001", participants);
    }
} 