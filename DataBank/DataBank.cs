using ExamSchedule.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamSchedule.Data
{
    public static class DataBank
    {
        public static List<Student> students = new List<Student>();
        public static List<Exam> exams = new List<Exam>();
        public static List<StudentSession> sessions = new List<StudentSession>();
        public static List<StudentsAndSessions> enrollments = new List<StudentsAndSessions>();

        public static void InitializeData()
        {
            // Initialize students
            students.Add(new Student { Id = 101, Name = "Shreyansh" });
            students.Add(new Student { Id = 102, Name = "Priya" });
            students.Add(new Student { Id = 103, Name = "Rahul" });

            // Initialize exam sessions
            sessions.Add(new StudentSession(1, "Fall 2024", new DateTime(2024, 9, 1), new DateTime(2024, 12, 20), "Fall"));
            sessions.Add(new StudentSession(2, "Spring 2025", new DateTime(2025, 1, 15), new DateTime(2025, 5, 30), "Spring"));

            // Initialize exams
            exams.Add(new Exam(1, "Mathematics", new DateTime(2024, 12, 15, 9, 0, 0), TimeSpan.FromHours(3), "Room 101", 30));
            exams.Add(new Exam(2, "Physics", new DateTime(2024, 12, 16, 14, 0, 0), TimeSpan.FromHours(2), "Room 102", 25));
            exams.Add(new Exam(3, "Computer Science", new DateTime(2024, 12, 17, 10, 0, 0), TimeSpan.FromHours(3), "Lab A", 20));
            exams.Add(new Exam(4, "English", new DateTime(2024, 12, 18, 9, 0, 0), TimeSpan.FromHours(2), "Room 103", 35));

            // Initialize some enrollments
            enrollments.Add(new StudentsAndSessions(1, 101, 1));
            enrollments.Add(new StudentsAndSessions(2, 101, 2));
            enrollments.Add(new StudentsAndSessions(3, 102, 1));
            enrollments.Add(new StudentsAndSessions(4, 103, 3));
        }

        public static void EnrollStudentInExam(int studentId, int examId)
        {
            var student = students.FirstOrDefault(s => s.Id == studentId);
            var exam = exams.FirstOrDefault(e => e.Id == examId);

            if (student == null)
            {
                Console.WriteLine("Student not found!");
                return;
            }

            if (exam == null)
            {
                Console.WriteLine("Exam not found!");
                return;
            }

            var existingEnrollment = enrollments.FirstOrDefault(e => e.StudentId == studentId && e.ExamId == examId);
            if (existingEnrollment != null)
            {
                Console.WriteLine($"{student.Name} is already enrolled in {exam.Subject}!");
                return;
            }

            var enrolledCount = enrollments.Count(e => e.ExamId == examId);
            if (enrolledCount >= exam.MaxCapacity)
            {
                Console.WriteLine($"Exam {exam.Subject} is at full capacity!");
                return;
            }

            int newId = enrollments.Any() ? enrollments.Max(e => e.EnrollmentId) + 1 : 1;
            enrollments.Add(new StudentsAndSessions(newId, studentId, examId));
            Console.WriteLine($"Successfully enrolled {student.Name} in {exam.Subject}!");
        }

        public static void AddStudent(string name)
        {
            // Validate student name
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Student name cannot be empty!");
                return;
            }

            // Generate new ID (auto-increment from highest existing ID)
            int newId = students.Any() ? students.Max(s => s.Id) + 1 : 101;

            // Add the new student
            students.Add(new Student { Id = newId, Name = name });
            Console.WriteLine($"Successfully added student: {name} (ID: {newId})");
        }
    }
}