public class Participant
{
    public int ResumeId { get; set; }
    public string Name { get; set; }
    public int WinCount { get; set; }

    public Participant(int resumeId, string name)
    {
        ResumeId = resumeId;
        Name = name;
        WinCount = 0;
    }

    public void AddWin()
    {
        WinCount++;
    }
} 