class Task
{
    public string Description { get; set; }
    public bool IsCompleted { get; set; }

    public Task(string description)
    {
        Description = description;
        IsCompleted = false;
    }

    public void MarkAsCompleted()
    {
        IsCompleted = true;
    }

    public override string ToString()
    {
        return $"{Description} - {(IsCompleted ? "Bajarildi" : "Bajarilmagan")}";
    }
}

class Program
{
    static List<Task> tasks = new List<Task>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Tanlang: add, view, delete, change, completed, exit");
            string option = Console.ReadLine()!;

            switch (option.ToLower())
            {
                case "add":
                    AddTask();
                    break;
                case "view":
                    ViewTasks();
                    break;
                case "delete":
                    DeleteTask();
                    break;
                case "change":
                    ChangeTask();
                    break;
                case "completed":
                    ViewCompletedTasks();
                    break;
                case "exit":
                    return;
                default:
                    Console.WriteLine("Noto'g'ri tanlov. Qaytadan urinib ko'ring.");
                    break;
            }
        }
    }

    static void AddTask()
    {
        Console.WriteLine("Vazifa tavsifini kiriting:");
        string description = Console.ReadLine()!;
        tasks.Add(new Task(description));
        Console.WriteLine("Vazifa qo'shildi.");
    }

    static void ViewTasks()
    {
        Console.WriteLine("Barcha vazifalar:");
        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {tasks[i]}");
        }
    }

    static void DeleteTask()
    {
        ViewTasks();
        Console.WriteLine("O'chiriladigan vazifa raqamini kiriting:");
        int index = int.Parse(Console.ReadLine()!) - 1;
        if (index >= 0 && index < tasks.Count)
        {
            tasks.RemoveAt(index);
            Console.WriteLine("Vazifa o'chirildi.");
        }
        else
        {
            Console.WriteLine("Noto'g'ri vazifa raqami.");
        }
    }

    static void ChangeTask()
    {
        ViewTasks();
        Console.WriteLine("O'zgartiriladigan vazifa raqamini kiriting:");
        int index = int.Parse(Console.ReadLine()!) - 1;
        if (index >= 0 && index < tasks.Count)
        {
            Console.WriteLine("Yangi vazifa tavsifini kiriting:");
            string description = Console.ReadLine()!;
            tasks[index].Description = description;
            Console.WriteLine("Vazifa yangilandi.");
        }
        else
        {
            Console.WriteLine("Noto'g'ri vazifa raqami.");
        }
    }

    static void ViewCompletedTasks()
    {
        Console.WriteLine("Bajarilgan vazifalar:");
        foreach (var task in tasks)
        {
            if (task.IsCompleted)
            {
                Console.WriteLine(task);
            }
        }
    }
}