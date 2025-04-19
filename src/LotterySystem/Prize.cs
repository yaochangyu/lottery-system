namespace LotterySystem;

/// <summary>
/// 獎品類別 - 用於表示抽獎系統中的獎品
/// </summary>
public class Prize
{
    /// <summary>
    /// 獎品唯一識別碼
    /// </summary>
    public string Id { get; set; }
    
    /// <summary>
    /// 獎品名稱
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// 獎品總數量 - 表示此獎品的初始總數量
    /// </summary>
    public int TotalQuantity { get; private set; }
    
    /// <summary>
    /// 獎品剩餘數量 - 表示此獎品目前尚未被抽走的數量
    /// </summary>
    public int RemainingQuantity { get; private set; }
    
    /// <summary>
    /// 獎品圖片路徑 - 用於顯示獎品的圖片位置
    /// </summary>
    public string ImagePath { get; set; }

    /// <summary>
    /// 建構子 - 初始化獎品物件
    /// </summary>
    /// <param name="prizeId">獎品唯一識別碼</param>
    /// <param name="prizeName">獎品名稱</param>
    /// <param name="totalQuantity">獎品總數量</param>
    /// <param name="imagePath">獎品圖片路徑</param>
    public Prize(string prizeId, string prizeName, int totalQuantity, string imagePath)
    {
        Id = prizeId;
        Name = prizeName;
        TotalQuantity = totalQuantity;
        RemainingQuantity = totalQuantity; // 初始時，剩餘數量等於總數量
        ImagePath = imagePath;
    }
    
    /// <summary>
    /// 減少獎品剩餘數量
    /// </summary>
    /// <param name="quantity">要減少的數量</param>
    /// <returns>是否成功減少數量</returns>
    /// <exception cref="System.ArgumentException">當減少的數量為負數或大於剩餘數量時拋出</exception>
    public bool SubtractRemainingQuantity(int quantity)
    {
        if (quantity <= 0)
        {
            throw new System.ArgumentException("減少的數量必須為正數", nameof(quantity));
        }
        
        if (quantity > RemainingQuantity)
        {
            return false; // 剩餘數量不足，無法減少
        }
        
        RemainingQuantity -= quantity;
        return true;
    }
    
    /// <summary>
    /// 調整獎品總數量
    /// </summary>
    /// <param name="newTotalQuantity">新的總數量</param>
    /// <returns>是否成功調整總數量</returns>
    /// <exception cref="System.ArgumentException">當新的總數量為負數或小於已抽出的數量時拋出</exception>
    public bool AdjustTotalQuantity(int newTotalQuantity)
    {
        if (newTotalQuantity < 0)
        {
            throw new System.ArgumentException("總數量不能為負數", nameof(newTotalQuantity));
        }
        
        int drawnQuantity = TotalQuantity - RemainingQuantity;
        
        if (newTotalQuantity < drawnQuantity)
        {
            return false; // 新總數量小於已抽出數量，無法調整
        }
        
        int difference = newTotalQuantity - TotalQuantity;
        TotalQuantity = newTotalQuantity;
        RemainingQuantity += difference;
        
        return true;
    }
}