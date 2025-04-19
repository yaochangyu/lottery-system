/// <summary>
/// 參與者中獎記錄類別，用於追蹤參與者在特定活動中的中獎情況
/// </summary>
public class ParticipantWinRecord
{
    /// <summary>
    /// 參與者實例
    /// </summary>
    public Participant Participant { get; private set; }

    /// <summary>
    /// 參與者在當前活動中的中獎次數
    /// </summary>
    public int WinCount { get; private set; }

    /// <summary>
    /// 初始化參與者中獎記錄
    /// </summary>
    /// <param name="participant">參與者實例</param>
    public ParticipantWinRecord(Participant participant)
    {
        Participant = participant;
        WinCount = 0;
    }

    /// <summary>
    /// 增加參與者的中獎次數
    /// </summary>
    public void AddWin()
    {
        WinCount++;
    }
} 