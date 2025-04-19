namespace LotterySystem.Rule;

/// <summary>
/// 基於中獎次數的抽獎規則實現
/// </summary>
public class WinCountRule : ILotteryRule
{
    /// <summary>
    /// 每人最多中獎次數
    /// </summary>
    public int MaxWinCount { get; private set; }
    
    /// <summary>
    /// 參與者當前的中獎次數
    /// </summary>
    public int WinCount { get; private set; }

    /// <summary>
    /// 初始化基於中獎次數的抽獎規則
    /// </summary>
    /// <param name="maxWinCount">每人最多中獎次數，預設值為 2</param>
    /// <param name="winCount">參與者當前的中獎次數，預設值為 0</param>
    public WinCountRule(int maxWinCount = 2, int winCount = 0)
    {
        MaxWinCount = maxWinCount;
        WinCount = winCount;
    }

    /// <summary>
    /// 判斷參與者是否符合中獎資格
    /// </summary>
    /// <param name="participant">參與者實例</param>
    /// <returns>如果參與者的中獎次數小於最大中獎次數則返回 true，否則返回 false</returns>
    public bool CanWin(Participant participant)
    {
        return WinCount < MaxWinCount;
    }
}