public class Prize
{
    public string PrizeId { get; set; }
    public string PrizeName { get; set; }
    public int TotalQuantity { get; set; }
    public int RemainingQuantity { get; set; }
    public string ImagePath { get; set; }

    public Prize(string prizeId, string prizeName, int totalQuantity, string imagePath)
    {
        PrizeId = prizeId;
        PrizeName = prizeName;
        TotalQuantity = totalQuantity;
        RemainingQuantity = totalQuantity;
        ImagePath = imagePath;
    }
} 