/// <summary>
/// 抽獎規則介面，定義了判斷參與者是否符合中獎資格的標準
/// </summary>
public interface ILotteryRule
{
    /// <summary>
    /// 判斷參與者是否符合中獎資格
    /// </summary>
    /// <param name="participant">參與者實例</param>
    /// <param name="winCount">參與者當前的中獎次數</param>
    /// <returns>如果參與者符合中獎資格則返回 true，否則返回 false</returns>
    bool CanParticipantWin(Participant participant, int winCount);

    /// <summary>
    /// 獲取符合中獎資格的參與者列表
    /// </summary>
    /// <param name="participants">所有參與者列表</param>
    /// <param name="getWinCount">獲取參與者中獎次數的函數</param>
    /// <returns>符合中獎資格的參與者列表</returns>
    List<Participant> GetEligibleParticipants(List<Participant> participants, Func<Participant, int> getWinCount);
} 