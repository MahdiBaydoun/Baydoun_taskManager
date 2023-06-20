using System;
using System.Collections.Generic;


// Task class to represent individual tasks
class Task
{
    public int Id { get; set; }
    public string Dscription { get; set; }
    public bool isComplete { get; set; }
}

// TaskManager class to encapsulate task management functionality
class TaskManager
{
    private List<Task> tasks;
    private int nextTaskId;

    public TaskManager()
    {
        tasks = new List<Task>();  //  List to store tasks
        nextTaskId = 1;  //  Counter to assign unique task IDs
    }

    //  Method to add a task
    public void AddTask(string desription)
    {
        var task = new Task { Id = nextTaskId++, Dscription = desription, isComplete = false };
        tasks.Add(task);
        Console.WriteLine("Task added successfully.");
    }

    //  Method to view a task
    public void ViewTasks()
    {
        if(tasks.Count == 0)
        {
            Console.WriteLine("No tasks found.");
            return;
        }

        Console.WriteLine("ID\tDescription\t\tStatus");
        foreach(var task in tasks)
        {
            Console.WriteLine($"{task.Id}\t{task.Dscription}\t\t{(task.isComplete ? "complete" : "Incomplete")}");

        }
    }

    //  Method to update a task
    public void UpdateTask(int id, string newdescription)
    {
        var task = tasks.Find(t => t.Id == id);
        if(task == null)
        {
            Console.WriteLine("Task not found.");
            return;
        }

        task.Dscription = newdescription;
        Console.WriteLine("Task updated successfully");
    }

    //  Method to delet a task
    public void DeleteTask(int id)
    {
        var task = tasks.Find(t => t.Id == id);
        if(task == null)
        {
            Console.WriteLine("Task not found.");
            return; 
        }

        tasks.Remove(task);
        Console.WriteLine("Task deleted successfully.");
    }
}
 
//  Main program
class Program
{
    static void Main()
    {
        var taskManager = new TaskManager();  //Create an instance of TaskManager

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Task Manager");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. view Tasks");
            Console.WriteLine("3. Update Task");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Exit");
            Console.WriteLine(" Enter your choice: ");

            string choice = Console.ReadLine();  //Read users's choice from the console
            Console.WriteLine();

            switch(choice)
            {
                    case "1":
                    Console.Write("Enter task description: ");
                    string description = Console.ReadLine();  // Read the task description from the console
                    taskManager.AddTask(description);  //Add the task using TaskManager's AddTask method
                    break;


                    case "2":
                    taskManager.ViewTasks();  // View all tasks using the TaskManager's ViewTaks method
                    break;


                    case "3":
                    Console.Write("Enter task ID: ");
                    int taskId = Convert.ToInt32(Console.ReadLine());  // Read the task ID from the console
                    Console.Write("Enter new task description: ");
                    string newDescription = Console.ReadLine();  // Read the task description from the console
                    taskManager.UpdateTask(taskId, newDescription);  // Update the task using TaskManager's UpdateTask method
                    break;
  

                    case "4":
                    Console.Write("Enter task ID:");
                    int deletTaskId = Convert.ToInt32(Console.ReadLine());  //Read the task ID from the console
                    taskManager.DeleteTask(deletTaskId);  // Delete the task using TaskManager Delete method
                    break;


                    case "5":
                    Environment.Exit(0);  // Exit the program when pressing 5
                    break;


                    default: 
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;

            }
        }
    }
}
