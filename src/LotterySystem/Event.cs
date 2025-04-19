public class Event
{
    public string EventCode { get; set; }
    public string EventName { get; set; }
    public List<Prize> Prizes { get; set; }
    public List<Participant> Participants { get; set; }
    public int MaxWinCount { get; set; }

    public Event(string eventCode, string eventName, int maxWinCount = 2)
    {
        EventCode = eventCode;
        EventName = eventName;
        MaxWinCount = maxWinCount;
        Prizes = new List<Prize>();
        Participants = new List<Participant>();
    }

    public void AddPrize(Prize prize)
    {
        Prizes.Add(prize);
    }

    public void AddParticipant(Participant participant)
    {
        Participants.Add(participant);
    }

    public bool CanParticipantWin(Participant participant)
    {
        return participant.WinCount < MaxWinCount;
    }
} 