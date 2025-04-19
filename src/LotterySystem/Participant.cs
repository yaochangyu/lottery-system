/// <summary>
/// 參與者類別，代表抽獎活動的參與者
/// </summary>
public class Participant
{
    /// <summary>
    /// 參與者的履歷編號，作為唯一識別碼
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 參與者的姓名
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 參與者的年齡
    /// </summary>
    public int Age { get; set; }

    /// <summary>
    /// 參與者的中獎次數
    /// </summary>
    public int WinCount { get; private set; }

    /// <summary>
    /// 初始化參與者實例
    /// </summary>
    /// <param name="resumeId">履歷編號</param>
    /// <param name="name">姓名</param>
    /// <param name="age">年齡</param>
    public Participant(int resumeId, string name, int age)
    {
        Id = resumeId;
        Name = name;
        Age = age;
        WinCount = 0;
    }

    /// <summary>
    /// 增加參與者的中獎次數
    /// </summary>
    public void AddWin()
    {
        WinCount++;
    }
} 