/// <summary>
/// 抽獎活動類別，代表一個抽獎活動
/// </summary>
public class Event
{
    /// <summary>
    /// 活動代碼，作為活動的唯一識別碼
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// 活動名稱
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 活動的獎項列表
    /// </summary>
    public List<Prize> Prizes { get; set; }

    /// <summary>
    /// 活動的參與者列表
    /// </summary>
    public List<Participant> Participants { get; set; }

    /// <summary>
    /// 活動的中獎規則
    /// </summary>
    public ILotteryRule LotteryRule { get; private set; }

    /// <summary>
    /// 初始化抽獎活動
    /// </summary>
    /// <param name="eventCode">活動代碼</param>
    /// <param name="eventName">活動名稱</param>
    /// <param name="lotteryRule">中獎規則</param>
    public Event(string eventCode, string eventName, ILotteryRule lotteryRule)
    {
        Id = eventCode;
        Name = eventName;
        LotteryRule = lotteryRule;
        Prizes = new List<Prize>();
        Participants = new List<Participant>();
    }

    /// <summary>
    /// 添加獎項到活動中
    /// </summary>
    /// <param name="prize">要添加的獎項</param>
    public void AddPrize(Prize prize)
    {
        Prizes.Add(prize);
    }

    /// <summary>
    /// 添加參與者到活動中
    /// </summary>
    /// <param name="participant">要添加的參與者</param>
    public void AddParticipant(Participant participant)
    {
        Participants.Add(participant);
    }

    /// <summary>
    /// 判斷參與者是否符合中獎資格
    /// </summary>
    /// <param name="participant">參與者實例</param>
    /// <returns>如果參與者符合中獎資格則返回 true，否則返回 false</returns>
    public bool CanParticipantWin(Participant participant)
    {
        return LotteryRule.CanWin(participant);
    }

    /// <summary>
    /// 獲取符合中獎資格的參與者列表
    /// </summary>
    /// <returns>符合中獎資格的參與者列表</returns>
    public List<Participant> GetEligibleParticipants()
    {
        return Participants.Where(p => CanParticipantWin(p)).ToList();
    }

    /// <summary>
    /// 增加參與者的中獎次數
    /// </summary>
    /// <param name="participant">參與者實例</param>
    public void AddWin(Participant participant)
    {
        participant.AddWin();
    }
} 