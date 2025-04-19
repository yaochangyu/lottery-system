using System.Collections.Generic;
using System.Linq;
using System;

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
    /// 初始化基於中獎次數的抽獎規則
    /// </summary>
    /// <param name="maxWinCount">每人最多中獎次數，預設值為 2</param>
    public WinCountRule(int maxWinCount = 2)
    {
        MaxWinCount = maxWinCount;
    }

    /// <summary>
    /// 判斷參與者是否符合中獎資格
    /// </summary>
    /// <param name="participant">參與者實例</param>
    /// <param name="winCount">參與者當前的中獎次數</param>
    /// <returns>如果參與者的中獎次數小於最大中獎次數則返回 true，否則返回 false</returns>
    public bool CanParticipantWin(Participant participant, int winCount)
    {
        return winCount < MaxWinCount;
    }

    /// <summary>
    /// 獲取符合中獎資格的參與者列表
    /// </summary>
    /// <param name="participants">所有參與者列表</param>
    /// <param name="getWinCount">獲取參與者中獎次數的函數</param>
    /// <returns>中獎次數小於最大中獎次數的參與者列表</returns>
    public List<Participant> GetEligibleParticipants(List<Participant> participants, Func<Participant, int> getWinCount)
    {
        return participants.Where(p => CanParticipantWin(p, getWinCount(p))).ToList();
    }
} 