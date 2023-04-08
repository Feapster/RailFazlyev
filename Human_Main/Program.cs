using System;
using System.Collections.Generic;



Parent parent1 = new Parent("Alice", 45, Gender.Female, "New York", "Engineer");

Student student1 = new Student("Bob", 20, Gender.Male, "New York", parent1, "Harvard University", "Computer Science");
Teacher teacher1 = new Teacher("Charlie", 35, Gender.Male, "New York", parent1, "Mathematics", 5000);

Group group1 = new Group(teacher1);
group1.AddStudent(student1);

School school1 = new School("GreatSchool");
school1.AddGroup(group1);

teacher1.GreetGroup(group1);
student1.GreetGroup(group1);
teacher1.TalkAboutSalary();
teacher1.AssignHomework(student1, "Solve quadratic equations.");
parent1.OfferHelp(student1);
parent1.ContactTeacher(teacher1);
group1.GreetAllStudents();

group1.RemoveStudent(student1);
school1.RemoveGroup(group1);




public enum Gender { Male, Female }

public class Human
{
    // Свойтсва : Имя, Возраст, Пол, Место Жительства
    public string Name { get; set; }
    public int Age { get; set; }
    public Gender Gender { get; set; }
    public string PlaceOfLiving { get; set; }

    // Конструктор для инициализации Human
    public Human(string name, int age, Gender gender, string placeOfLiving)
    {	
        Name = name;
        Age = age;
        Gender = gender;
        PlaceOfLiving = placeOfLiving;
    }
}

public class Teacher : Human
{
    // Свойтсва : Родитель, Предмет Учёбы, Зарплата
    public Parent Parent { get; }
    public string Subject { get; set; }
    public double Salary { get; set; }

    // Конструктор для инициализации Teacher
    public Teacher(string name, int age, Gender gender, string placeOfLiving, Parent parent, string subject, double salary)
    : base(name, age, gender, placeOfLiving)
    {
        Parent = parent;
        Subject = subject;
        Salary = salary;
    }

    // Поздороваться с Группой
    public void GreetGroup(Group group)
    {
        Console.WriteLine($"Hello, I'm {Name} and I will be teaching {Subject}.");
    }

    // Поговорить о Зарплате
    public void TalkAboutSalary()
    {
        Console.WriteLine($"As a teacher, I earn {Salary} per month.");
    }
    // Дать Домашку
    public void AssignHomework(Student student, string assignment)
    {
        Console.WriteLine($"Dear {student.Name}, your assignment is: {assignment}");
    }
}

public class Student : Human
{
    // Свойтсва : Родитель, Универститет, Специализация
    public Parent Parent { get; }
    public string University { get; set; }
    public string Specialization { get; set; }

    // Конструктор для инициализации Student
    public Student(string name, int age, Gender gender, string placeOfLiving, Parent parent, string university, string specialization)
    : base(name, age, gender, placeOfLiving)
    {
        Parent = parent;
        University = university;
        Specialization = specialization;
    }

    // Поздороваться с Группой
    public void GreetGroup(Group group)
    {
        Console.WriteLine($"Hello, I'm {Name}, I study {Specialization} at {University}.");
    }
}

public class Parent : Human
{
    // Свойтсва : Работа 
    public string Job { get; set; }

    // Конструктор для инициализации Parent
    public Parent(string name, int age, Gender gender, string placeOfLiving, string job)
    : base(name, age, gender, placeOfLiving)
    {
        Job = job;
    }
    // Предложить Помошь Сыну / Дочери
    public void OfferHelp(Student child)
    {
        Console.WriteLine($"Hi {child.Name}, do you need help with anything? I have experience in {Job}.");
    }

    // Поговорить с Учителем Сына / Дочери
    public void ContactTeacher(Teacher teacher)
    {
        Console.WriteLine($"Hello {teacher.Name}, I am {Name} and I would like to discuss my child's progress.");
    }
}

public class Group
{
    // Свойтсва : Учитель, Список Студентов
    public Teacher Teacher { get; set; }
    public List<Student> Students { get; private set; }

    // Конструктор для инициализации Group
    public Group(Teacher teacher, List<Student> students = null)
    {
        Teacher = teacher;
        Students = students ?? new List<Student>();
    }

    // Добавить Студента
    public void AddStudent(Student student)
    {
        if (student != null) // check for null reference
        {
            Students.Add(student);
        }
        else
        {
            Console.WriteLine("Cannot add null student to group.");
        }
    }

    // Убрать Студента
    public void RemoveStudent(Student student)
    {
        Students.Remove(student);
    }

    // Убрать Поздороваться со Всеми Студентами
    public void GreetAllStudents()
    {
        Console.WriteLine($"{Teacher.Name} greets all students in the group:");
        foreach (Student student in Students)
        {
            Console.WriteLine($"Hello, {student.Name}!");
        }
    }

}


public class School
{
    // Свойства : Название Школы, Список Групп
    public string Name { get; set; }
    public List<Group> Groups { get; private set; }

    // Конструктор для инициализации School 
    public School(string name)
    {
        Name = name;
        Groups = new List<Group>();
    }

    // Добавить Группу 
    public void AddGroup(Group group)
    {
        Groups.Add(group);
    }

    // Убрать Группу
    public void RemoveGroup(Group group)
    {
        Groups.Remove(group);
    }
}