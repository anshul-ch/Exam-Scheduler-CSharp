# Exam Scheduler (C#)

An automated scheduling system designed to manage the complexities of academic examinations. This program processes student enrollments, course requirements, and venue capacities to produce a conflict-free examination timetable.



## 📌 Overview
The **Exam Scheduler** is a C# application developed to solve the logistical challenge of organizing exams. It ensures that students are not double-booked, exam halls are used efficiently according to their capacity, and all courses are assigned a valid time slot.

## ✨ Key Features
* **Smart Allocation:** Automatically assigns courses to available Exam Halls based on capacity.
* **Constraint Satisfaction:** * Ensures no student is scheduled for two exams in the same time slot.
    * Prevents overbooking of exam hall seating capacities.
* **Conflict Reporting:** Identifies and highlights scheduling bottlenecks if constraints cannot be met.
* **Data Management:** Robust handling of Student, Course, and Hall objects.

## 🛠️ Tech Stack
* **Language:** C#
* **Framework:** .NET (Core/Framework)
* **IDE:** Visual Studio / VS Code

## 📂 Project Structure
* **Models:** Core entities like `Student.cs`, `Course.cs`, `ExamHall.cs`, and `ExamSlot.cs`.
* **Logic:** The engine handling the scheduling algorithm and validation rules.
* **Data:** Handles persistence and loading of scheduling data.

## 🚀 Getting Started

### Prerequisites
* [.NET SDK](https://dotnet.microsoft.com/download)
* Visual Studio 2022 or higher

### Installation & Run
1. **Clone the repo:**
   ```bash
   git clone [https://github.com/anshul-ch/Exam-Scheduler-CSharp.git](https://github.com/anshul-ch/Exam-Scheduler-CSharp.git)
## 🤝 Contributing
1. **Fork** the Project.
2. **Create** your Feature Branch (`git checkout -b feature/AmazingFeature`).
3. **Commit** your Changes (`git commit -m 'Add some AmazingFeature'`).
4. **Push** to the Branch (`git push origin feature/AmazingFeature`).
5. **Open** a Pull Request.

## ✍️ Author
**Anshul Chaudhary**
* **GitHub:** [@anshul-ch](https://github.com/anshul-ch)
