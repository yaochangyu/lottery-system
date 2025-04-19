namespace LotterySystem.Rule;

/// <summary>
/// 基於中獎次數和年齡的抽獎規則實現
/// </summary>
public class WinCountAndAgeRule : ILotteryRule
{
    /// <summary>
    /// 每人最多中獎次數
    /// </summary>
    public int MaxWinCount { get; private set; }

    /// <summary>
    /// 最小年齡限制
    /// </summary>
    public int MinAge { get; private set; }

    /// <summary>
    /// 最大年齡限制
    /// </summary>
    public int MaxAge { get; private set; }

    /// <summary>
    /// 初始化基於中獎次數和年齡的抽獎規則
    /// </summary>
    /// <param name="maxWinCount">每人最多中獎次數，預設值為 2</param>
    /// <param name="minAge">最小年齡限制，預設值為 18</param>
    /// <param name="maxAge">最大年齡限制，預設值為 65</param>
    public WinCountAndAgeRule(int maxWinCount = 2, int minAge = 18, int maxAge = 65)
    {
        MaxWinCount = maxWinCount;
        MinAge = minAge;
        MaxAge = maxAge;
    }

    /// <summary>
    /// 判斷參與者是否符合中獎資格
    /// </summary>
    /// <param name="participant">參與者實例</param>
    /// <returns>如果參與者的中獎次數小於最大中獎次數且年齡在限制範圍內則返回 true，否則返回 false</returns>
    public bool CanWin(Participant participant)
    {
        return participant.WinCount < MaxWinCount &&
               participant.Age >= MinAge &&
               participant.Age <= MaxAge;
    }
}