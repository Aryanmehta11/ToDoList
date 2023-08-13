using System;
using System.Collections.Generic;

namespace MyToDoList {
    class Program {

        static List<string> tasks = new List<string>();
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
            string task = Console.ReadLine();
            tasks.Add(task);
            Console.WriteLine("The task has been added successfully");
            Console.WriteLine(); //For space
        }

        static void ViewTasks() {
            Console.WriteLine("\nTasks:");
            for (int i = 0; i < tasks.Count; i++) {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
                Console.WriteLine();
            }
        } // End of the View the task

    } // End of the Class Program
}
