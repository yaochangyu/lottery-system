namespace LotterySystem.Rule;

/// <summary>
/// 抽獎規則介面，定義了判斷參與者是否符合中獎資格的標準
/// </summary>
public interface ILotteryRule
{
    /// <summary>
    /// 判斷參與者是否符合中獎資格
    /// </summary>
    /// <param name="participant">參與者實例</param>
    /// <returns>如果參與者符合中獎資格則返回 true，否則返回 false</returns>
    bool CanParticipantWin(Participant participant);
}