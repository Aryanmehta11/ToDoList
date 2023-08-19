using System;
using System.Collections.Generic;

namespace MyToDoList {
    enum TaskPriority { Low, Medium, High }

    class Task {
        public string Description { get; set; }
        public TaskPriority Priority { get; set; }
        public DateTime DueDate { get; set; }
    }

    class Program {

        static List<Task> tasks = new List<Task>();
        static void Main(string[] args) {
            Console.WriteLine("Welcome to the ToDo List");
            while (true) {
                Console.WriteLine("Please select an option");
                Console.WriteLine("1. Add a task");
                Console.WriteLine("2. View tasks");
                Console.WriteLine("3. Exit");

                int choice = GetUserChoice();

                switch (choice) {
                    case 1:
                        AddTask();
                        break;

                    case 2:
                        ViewTasks();
                        break;

                    case 3:
                        Console.WriteLine("Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid Choice. Please enter a number again");
                        break;
                }
            }
        } // End of the Main Method

        static int GetUserChoice() {
            while (true) {
                Console.WriteLine("What you wanna do");

                if (int.TryParse(Console.ReadLine(), out int choice) && (choice >= 1 && choice <= 3)) {
                    return choice;
                } else {
                    Console.WriteLine("Please enter a valid choice");
                }
            }
        } // End of the user choice

        static void AddTask() {
            Console.WriteLine("Enter a task that you want to do today");
            string taskDescription = Console.ReadLine();

            // Ask user to add the task priority
            Console.WriteLine("Enter the task priority (High/Medium/Low)");
            Enum.TryParse(Console.ReadLine(), out TaskPriority taskPriority);

            // Ask user to add the due date
            Console.WriteLine("Enter the due date (DD-MM-YYYY)");
            DateTime.TryParse(Console.ReadLine(), out DateTime dueDate);

            tasks.Add(new Task {
                Description = taskDescription,
                Priority = taskPriority,
                DueDate = dueDate
            });

            Console.WriteLine("The task has been added successfully");
            Console.WriteLine(); // For space
        }

        static void ViewTasks() {
            Console.WriteLine("\nTasks:");
            for (int i = 0; i < tasks.Count; i++) {
                Console.WriteLine($"{i + 1}. Description: {tasks[i].Description}, Priority: {tasks[i].Priority}, Due Date: {tasks[i].DueDate.ToString("dd-MM-yyyy")}");
                Console.WriteLine();
            }
        } // End of the View the task

    } // End of the Class Program
}
