using ExamSchedule.Data;
using ExamSchedule.Model;

namespace ExamSchedule;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Exam Schedule System ===\n");

        // Initialize data
        DataBank.InitializeData();

        bool running = true;
        while (running)
        {
            Console.WriteLine("\n--- Main Menu ---");
            Console.WriteLine("1. Add New Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. View All Exams");
            Console.WriteLine("4. View Exam Schedule");
            Console.WriteLine("5. Enroll Student in Exam");
            Console.WriteLine("6. View Student Enrollments");
            Console.WriteLine("7. Exit");
            Console.Write("\nSelect an option: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddNewStudent();
                    break;
                case "2":
                    ViewAllStudents();
                    break;
                case "3":
                    ViewAllExams();
                    break;
                case "4":
                    ViewExamSchedule();
                    break;
                case "5":
                    EnrollStudent();
                    break;
                case "6":
                    ViewStudentEnrollments();
                    break;
                case "7":
                    running = false;
                    Console.WriteLine("\nThank you for using Exam Schedule System!");
                    break;
                default:
                    Console.WriteLine("\nInvalid option. Please try again.");
                    break;
            }
        }
    }

    static void AddNewStudent()
    {
        Console.WriteLine("\n=== Add New Student ===");
        Console.Write("Enter student name: ");
        string? name = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(name))
        {
            DataBank.AddStudent(name);
        }
        else
        {
            Console.WriteLine("Student name cannot be empty!");
        }
    }

    static void ViewAllStudents()
    {
        Console.WriteLine("\n=== Registered Students ===");
        foreach (var student in DataBank.students)
        {
            Console.WriteLine($"ID: {student.Id}, Name: {student.Name}");
        }
        Console.WriteLine($"\nTotal Students: {DataBank.students.Count}");
    }

    static void ViewAllExams()
    {
        Console.WriteLine("\n=== Available Exams ===");
        foreach (var exam in DataBank.exams)
        {
            int enrolled = DataBank.enrollments.Count(e => e.ExamId == exam.Id);
            Console.WriteLine($"ID: {exam.Id}");
            Console.WriteLine($"  Subject: {exam.Subject}");
            Console.WriteLine($"  Date: {exam.ExamDate:yyyy-MM-dd HH:mm}");
            Console.WriteLine($"  Duration: {exam.Duration.Hours}h {exam.Duration.Minutes}m");
            Console.WriteLine($"  Location: {exam.Location}");
            Console.WriteLine($"  Capacity: {enrolled}/{exam.MaxCapacity}");
            Console.WriteLine();
        }
    }

    static void ViewExamSchedule()
    {
        Console.WriteLine("\n=== Exam Schedule ===");
        var sortedExams = DataBank.exams.OrderBy(e => e.ExamDate).ToList();

        foreach (var exam in sortedExams)
        {
            var endTime = exam.ExamDate.Add(exam.Duration);
            Console.WriteLine($"{exam.ExamDate:ddd, MMM dd yyyy} | {exam.ExamDate:HH:mm} - {endTime:HH:mm} | {exam.Subject} | {exam.Location}");
        }
    }

    static void EnrollStudent()
    {
        Console.WriteLine("\n=== Enroll Student in Exam ===");
        Console.Write("Enter Student ID: ");
        if (int.TryParse(Console.ReadLine(), out int studentId))
        {
            Console.Write("Enter Exam ID: ");
            if (int.TryParse(Console.ReadLine(), out int examId))
            {
                DataBank.EnrollStudentInExam(studentId, examId);
            }
            else
            {
                Console.WriteLine("Invalid Exam ID!");
            }
        }
        else
        {
            Console.WriteLine("Invalid Student ID!");
        }
    }

    static void ViewStudentEnrollments()
    {
        Console.WriteLine("\n=== Student Enrollments ===");
        Console.Write("Enter Student ID: ");
        if (int.TryParse(Console.ReadLine(), out int studentId))
        {
            var student = DataBank.students.FirstOrDefault(s => s.Id == studentId);
            if (student == null)
            {
                Console.WriteLine("Student not found!");
                return;
            }

            Console.WriteLine($"\nEnrollments for {student.Name} (ID: {student.Id}):");
            var studentEnrollments = DataBank.enrollments.Where(e => e.StudentId == studentId).ToList();

            if (!studentEnrollments.Any())
            {
                Console.WriteLine("No enrollments found.");
                return;
            }

            foreach (var enrollment in studentEnrollments)
            {
                var exam = DataBank.exams.FirstOrDefault(e => e.Id == enrollment.ExamId);
                if (exam != null)
                {
                    Console.WriteLine($"  - {exam.Subject} on {exam.ExamDate:yyyy-MM-dd HH:mm} at {exam.Location}");
                }
            }
        }
        else
        {
            Console.WriteLine("Invalid Student ID!");
        }
    }
}