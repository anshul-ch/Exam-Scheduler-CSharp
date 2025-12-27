
using System;

namespace ExamSchedule.Model
{
    public class StudentSession
    {
        public int SessionId { get; set; }
        public string SessionName { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Semester { get; set; } = string.Empty;

        public StudentSession() { }

        public StudentSession(int sessionId, string sessionName, DateTime startDate, DateTime endDate, string semester)
        {
            SessionId = sessionId;
            SessionName = sessionName;
            StartDate = startDate;
            EndDate = endDate;
            Semester = semester;
        }
    }
}