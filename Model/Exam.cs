
namespace ExamSchedule.Model;

public class Exam
{
    public int Id { get; set; }
    public string Subject { get; set; } = string.Empty;
    public DateTime ExamDate { get; set; }
    public TimeSpan Duration { get; set; }
    public string Location { get; set; } = string.Empty;
    public int MaxCapacity { get; set; }

    public Exam() { }

    public Exam(int id, string subject, DateTime examDate, TimeSpan duration, string location, int maxCapacity)
    {
        Id = id;
        Subject = subject;
        ExamDate = examDate;
        Duration = duration;
        Location = location;
        MaxCapacity = maxCapacity;
    }
}