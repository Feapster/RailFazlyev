using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

Parent parent1 = new Parent("Alice", 45, Gender.Female, "New York", "Engineer");
Student student1 = new Student("Bob", 20, Gender.Male, "New York", parent1, "Harvard University", "Computer Science");
Teacher teacher1 = new Teacher("Charlie", 35, Gender.Male, "New York", parent1, "Mathematics", 5000);

Group group1 = new Group(teacher1, "name", null);
group1.Add(student1);

School school1 = new School("GreatSchool");
school1.Add(group1);

student1.GreetGroup();
teacher1.Greet();
teacher1.AssignHomework(student1, "Solve quadratic equations.");
parent1.OfferHelp();
parent1.ContactTeacher(teacher1);
group1.GreetGroup();

group1.Remove(student1);
school1.Remove(group1);

public enum Gender { Male, Female }

public interface IContact<T>
{
    void Greet();
    void Contact(T person);
}

public interface IGreetGroup
{
    void GreetGroup();
}

public interface IManageGroup<T>
{
    void Remove(T objectInGroup);
    void Add(T objectInGroup);
}

public abstract class Human
{
    public string Name { get; set; }
    public int Age { get; set; }
    public Gender Gender { get; }
    public Parent Parent { get; set; }
}

public abstract class Person : Human, IContact<Human>
{
    public string PlaceOfLiving { get; set; }
    public abstract void Greet();
    public void Contact(Human person)
    {
        Console.WriteLine($"Hello, {person.Name}, How are you?.");
    }
}

public class Teacher : Person
{
    public string SubjectOfTeaching { get; set; }
    public double Salary { get; set; }

    public Teacher(string name, int age, Gender gender, string placeOfLiving, Parent parent, string subject, double salary)
    {
        Parent = parent;
        SubjectOfTeaching = subject;
        Salary = salary;
    }

    public override void Greet()
    {
        Console.WriteLine($"Hi. I am {Name}. As a teacher of {SubjectOfTeaching}, I earn {Salary} per month.");
    }

    public void AssignHomework(Student student, string assignment)
    {
        Console.WriteLine($"Dear {student.Name}, your assignment is: {assignment}");
    }
}

public class Student : Person, IGreetGroup
{
    public string University { get; set; }
    public string Specialization { get; set; }

    public Student(string name, int age, Gender gender, string placeOfLiving, Parent parent, string university, string specialization)
    {
        Parent = parent;
        University = university;
        Specialization = specialization;
    }

    public override void Greet()
    {
        Console.WriteLine($"Hello, I'm {Name}, I am learning {Specialization}.");
    }

    public void GreetGroup()
    {
        Console.WriteLine($"Hello, I'm {Name}, I study {Specialization} at {University}.");
    }
}

public class Parent : Person
{
    public string Job { get; set; }
    public Human Child { get; set; }

    public Parent(string name, int age, Gender gender, string placeOfLiving, string job, Human child = null)
    {
        Job = job;
        Child = child;
    }
    public override void Greet()
    {
        Console.WriteLine($"Hello, I'm {Name}, I am parent of {Child}.");
    }

    public void OfferHelp()
    {
        Console.WriteLine($"Hi {Child.Name}, do you need help with anything? I have experience in {Job}.");
    }

    public void ContactTeacher(Teacher teacher)
    {
        Console.WriteLine($"Hello {teacher.Name}, I am {Name} and I would like to discuss my child's progress.");
    }

    public void SetChild(Human child)
    {
        if (child != null)
        {
            Child = child;
            child.Parent = this;
        }
    }
}

public class Group : IManageGroup<Student>, IGreetGroup
{
    public Teacher Teacher { get; set; }
    public List<Student> Students { get; private set; }
    public string Name { get; set; }

    public Group(Teacher teacher, string name, List<Student> students = null)
    {
        Teacher = teacher;
        Students = students ?? new List<Student>();
        Name = name;
    }

    public void Add(Student student)
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

    public void Remove(Student student)
    {
        Students.Remove(student);
    }

    public void GreetGroup()
    {
        Console.WriteLine($"{Teacher.Name} greets all students in the group:");
        foreach (Student student in Students)
        {
            Console.WriteLine($"Hello, {student.Name}!");
        }
    }
}

public class School : IManageGroup<Group>
{
    public string Name { get; set; }
    public List<Group> Groups { get; private set; }

    public School(string name)
    {
        Name = name;
        Groups = new List<Group>();
    }

    public void Add(Group group)
    {
        Groups.Add(group);
    }

    public void Remove(Group group)
    {
        Groups.Remove(group);
    }
}