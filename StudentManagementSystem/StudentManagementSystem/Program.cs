using System;
using System.Collections.Generic;

interface IPerson
{
    void Login();
}

class Person : IPerson
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Password { get; set; }

    public virtual void Login()
    {
        Console.WriteLine("Login method from Person class.");
    }
}

class Student : Person
{
    public int StudentNumber { get; set; }
    public List<Course> Courses { get; set; } = new List<Course>();

    public override void Login()
    {
        Console.WriteLine($"Student {Name} {Surname} logged in.");
    }

    public void ShowCourses()
    {
        Console.WriteLine("Enrolled Courses:");
        foreach (var course in Courses)
        {
            Console.WriteLine($"- {course.CourseName} ({course.Credit} credits)");
        }
    }
}

class Teacher : Person
{
    public string Department { get; set; }
    public List<Course> Courses { get; set; } = new List<Course>();

    public override void Login()
    {
        Console.WriteLine($"Teacher {Name} {Surname} logged in.");
    }

    public void ShowCourses()
    {
        Console.WriteLine("Courses taught:");
        foreach (var course in Courses)
        {
            Console.WriteLine($"- {course.CourseName} ({course.Credit} credits)");
        }
    }
}

class Course
{
    public string CourseName { get; set; }
    public int Credit { get; set; }
    public Teacher Teacher { get; set; }
    public List<Student> EnrolledStudents { get; set; } = new List<Student>();

    public void EnrollStudent(Student student)
    {
        EnrolledStudents.Add(student);
        student.Courses.Add(this);
    }

    public void ShowCourseDetails()
    {
        Console.WriteLine($"Course: {CourseName}, Credits: {Credit}, Teacher: {Teacher.Name} {Teacher.Surname}");
        Console.WriteLine("Enrolled Students:");
        foreach (var student in EnrolledStudents)
        {
            Console.WriteLine($"- {student.Name} {student.Surname} (Student Number: {student.StudentNumber})");
        }
    }
}

class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>();
        List<Teacher> teachers = new List<Teacher>();
        List<Course> courses = new List<Course>();

        // Öğretmenler ekleniyor
        teachers.Add(new Teacher { Name = "Ali", Surname = "Yılmaz", Department = "Fizik" });
        teachers.Add(new Teacher { Name = "Ayşe", Surname = "Kara", Department = "Kimya" });
        teachers.Add(new Teacher { Name = "Veli", Surname = "Demir", Department = "Matematik" });
        teachers.Add(new Teacher { Name = "Fatma", Surname = "Karaoğlu", Department = "Bilgisayar Bilimleri" });
        teachers.Add(new Teacher { Name = "Mehmet", Surname = "Öztürk", Department = "Biyoloji" });
        teachers.Add(new Teacher { Name = "Zeynep", Surname = "Kılıç", Department = "Jeoloji" });

        // Öğrenciler ekleniyor
        students.Add(new Student { Name = "Emir", Surname = "Akbaş", StudentNumber = 101 });
        students.Add(new Student { Name = "Ahmet", Surname = "Çelik", StudentNumber = 102 });
        students.Add(new Student { Name = "Fatma", Surname = "Güler", StudentNumber = 103 });
        students.Add(new Student { Name = "Murat", Surname = "Kaya", StudentNumber = 104 });
        students.Add(new Student { Name = "Zeynep", Surname = "Demirtaş", StudentNumber = 105 });
        students.Add(new Student { Name = "Mustafa", Surname = "Öztürk", StudentNumber = 106 });
        students.Add(new Student { Name = "Aylin", Surname = "Yılmaz", StudentNumber = 107 });
        students.Add(new Student { Name = "Cem", Surname = "Çelik", StudentNumber = 108 });
        students.Add(new Student { Name = "Nalan", Surname = "Kara", StudentNumber = 109 });
        students.Add(new Student { Name = "Hakan", Surname = "Yıldız", StudentNumber = 110 });
        students.Add(new Student { Name = "Ali", Surname = "Sarı", StudentNumber = 111 });
        students.Add(new Student { Name = "Seda", Surname = "Aydın", StudentNumber = 112 });
        students.Add(new Student { Name = "Mehmet", Surname = "Koç", StudentNumber = 113 });
        students.Add(new Student { Name = "Rabia", Surname = "Aslan", StudentNumber = 114 });
        students.Add(new Student { Name = "Emre", Surname = "Başar", StudentNumber = 115 });

        // Dersler ekleniyor
        courses.Add(new Course { CourseName = "Fizik 101", Credit = 2, Teacher = teachers[0] });
        courses.Add(new Course { CourseName = "Kimya 101", Credit = 2, Teacher = teachers[1] });
        courses.Add(new Course { CourseName = "Matematik 101", Credit = 2, Teacher = teachers[2] });
        courses.Add(new Course { CourseName = "Bilgisayar Bilimleri 101", Credit = 2, Teacher = teachers[3] });
        courses.Add(new Course { CourseName = "Biyoloji 101", Credit = 2, Teacher = teachers[4] });
        courses.Add(new Course { CourseName = "Jeoloji 101", Credit = 2, Teacher = teachers[5] });

        // Ana menü
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nBir seçenek girin:");
            Console.WriteLine("1. Öğrenci Ekle");
            Console.WriteLine("2. Öğretmen Ekle");
            Console.WriteLine("3. Ders Oluştur");
            Console.WriteLine("4. Öğrenciyi Derse Kaydet");
            Console.WriteLine("5. Ders Detaylarını Göster");
            Console.WriteLine("6. Çık");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                // Öğrenci Ekleme
                Console.Write("Öğrenci Adı: ");
                string studentName = Console.ReadLine();
                Console.Write("Öğrenci Soyadı: ");
                string studentSurname = Console.ReadLine();
                int studentNumber;

                // Öğrenci numarasını alırken 3 haneli olup olmadığını kontrol etme
                while (true)
                {
                    Console.Write("Öğrenci Numarası (3 haneli): ");
                    studentNumber = Convert.ToInt32(Console.ReadLine());
                    if (studentNumber < 100 || studentNumber > 999)
                    {
                        Console.WriteLine("Hata! Öğrenci numarası 3 haneli olmalıdır.");
                    }
                    else
                    {
                        break;
                    }
                }

                Student newStudent = new Student { Name = studentName, Surname = studentSurname, StudentNumber = studentNumber };
                students.Add(newStudent);
                Console.WriteLine($"Öğrenci {studentName} {studentSurname} numarasıyla eklendi.");
            }
            else if (choice == 2)
            {
                // Öğretmen Ekleme
                Console.Write("Öğretmen Adı: ");
                string teacherName = Console.ReadLine();
                Console.Write("Öğretmen Soyadı: ");
                string teacherSurname = Console.ReadLine();
                Console.WriteLine("Bölüm Seçin: 1=Fizik, 2=Kimya, 3=Matematik, 4=Bilgisayar Bilimleri, 5=Biyoloji, 6=Jeoloji");
                int departmentChoice = Convert.ToInt32(Console.ReadLine());
                string department = "";

                if (departmentChoice == 1)
                    department = "Fizik";
                else if (departmentChoice == 2)
                    department = "Kimya";
                else if (departmentChoice == 3)
                    department = "Matematik";
                else if (departmentChoice == 4)
                    department = "Bilgisayar Bilimleri";
                else if (departmentChoice == 5)
                    department = "Biyoloji";
                else if (departmentChoice == 6)
                    department = "Jeoloji";

                Teacher newTeacher = new Teacher { Name = teacherName, Surname = teacherSurname, Department = department };
                teachers.Add(newTeacher);
                Console.WriteLine($"Öğretmen {teacherName} {teacherSurname} bölümünde eklendi.");
            }
            else if (choice == 3)
            {
                // Ders Oluşturma
                Console.WriteLine("Mevcut Öğretmenler:");
                for (int i = 0; i < teachers.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {teachers[i].Name} {teachers[i].Surname} ({teachers[i].Department})");
                }

                Console.Write("Öğretmen Seçin: ");
                int teacherChoice = Convert.ToInt32(Console.ReadLine()) - 1;

                Console.Write("Ders Adı: ");
                string courseName = Console.ReadLine();

                Course newCourse = new Course
                {
                    CourseName = courseName,
                    Credit = 2, // Varsayılan kredi
                    Teacher = teachers[teacherChoice]
                };

                courses.Add(newCourse);
                teachers[teacherChoice].Courses.Add(newCourse);

                Console.WriteLine($"{courseName} dersi oluşturuldu.");
            }
            else if (choice == 4)
            {
                // Öğrenciyi Derse Kaydetme
                Console.WriteLine("Mevcut Öğrenciler:");
                for (int i = 0; i < students.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {students[i].Name} {students[i].Surname} (Numara: {students[i].StudentNumber})");
                }

                Console.Write("Öğrenci Seçin: ");
                int studentChoice = Convert.ToInt32(Console.ReadLine()) - 1;

                Console.WriteLine("Mevcut Dersler:");
                for (int i = 0; i < courses.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {courses[i].CourseName} ({courses[i].Teacher.Name} {courses[i].Teacher.Surname})");
                }

                Console.Write("Ders Seçin: ");
                int courseChoice = Convert.ToInt32(Console.ReadLine()) - 1;

                courses[courseChoice].EnrollStudent(students[studentChoice]);
                Console.WriteLine($"{students[studentChoice].Name} {students[studentChoice].Surname} derse kaydedildi.");
            }
            else if (choice == 5)
            {
                // Ders Detaylarını Gösterme
                Console.WriteLine("Mevcut Dersler:");
                for (int i = 0; i < courses.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {courses[i].CourseName} ({courses[i].Teacher.Name} {courses[i].Teacher.Surname})");
                }

                Console.Write("Ders Seçin: ");
                int courseDetailChoice = Convert.ToInt32(Console.ReadLine()) - 1;

                courses[courseDetailChoice].ShowCourseDetails();
            }
            else if (choice == 6)
            {
                exit = true;
            }
        }
    }
}
