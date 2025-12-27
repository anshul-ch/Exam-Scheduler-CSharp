namespace ExamSchedule.Model;

public class StudentsAndSessions
{
    public int EnrollmentId { get; set; }
    public int StudentId { get; set; }
    public int ExamId { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public bool IsPresent { get; set; }
    public decimal? Score { get; set; }

    public StudentsAndSessions() { }

    public StudentsAndSessions(int enrollmentId, int studentId, int examId)
    {
        EnrollmentId = enrollmentId;
        StudentId = studentId;
        ExamId = examId;
        EnrollmentDate = DateTime.UtcNow;
        IsPresent = false;
        Score = null;
    }
}