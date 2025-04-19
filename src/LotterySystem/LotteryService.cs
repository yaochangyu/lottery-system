using LotterySystem.Rule;

namespace LotterySystem;

/// <summary>
/// 抽獎服務類別，負責處理抽獎核心邏輯
/// </summary>
public class LotteryService
{
    /// <summary>
    /// 隨機數生成器，用於抽獎
    /// </summary>
    private Random random = new Random();

    /// <summary>
    /// 執行抽獎操作
    /// </summary>
    /// <param name="selectedEvent">選中的活動</param>
    /// <param name="selectedPrize">選中的獎項</param>
    /// <param name="drawCount">抽取數量</param>
    /// <returns>中獎者列表</returns>
    public List<Participant> Draw(Event selectedEvent, Prize selectedPrize, int drawCount)
    {
        if (selectedPrize.RemainingQuantity < drawCount)
        {
            throw new InvalidOperationException("抽取數量超過剩餘獎項數量");
        }

        // 獲取符合資格的參與者
        var eligibleParticipants = selectedEvent.GetEligibleParticipants();
        
        if (eligibleParticipants.Count < drawCount)
        {
            throw new InvalidOperationException($"符合抽獎資格的參與者數量不足，僅有 {eligibleParticipants.Count} 位");
        }

        // 執行抽獎
        var winners = eligibleParticipants
            .OrderBy(x => random.Next())
            .Take(drawCount)
            .ToList();

        // 更新中獎者資訊
        foreach (var winner in winners)
        {
            selectedEvent.AddWin(winner);
        }

        // 更新獎項剩餘數量
        selectedPrize.SubtractRemainingQuantity(drawCount);

        return winners;
    }

    /// <summary>
    /// 檢查是否有足夠的合格參與者
    /// </summary>
    /// <param name="selectedEvent">選中的活動</param>
    /// <param name="drawCount">抽取數量</param>
    /// <returns>符合資格的參與者數量</returns>
    public int CheckEligibleParticipantsCount(Event selectedEvent)
    {
        return selectedEvent.GetEligibleParticipants().Count;
    }
}