public class DailyStatsDto
{
    public int Total { get; set; }
    public Dictionary<string, int> ByType { get; set; } = new Dictionary<string, int>();
    public string Date { get; set; } 
}