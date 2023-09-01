using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MyToDoList
{
    enum TaskPriority { Low, Medium, High }
    enum TaskStatus { Pending, InProgress, Completed }
    enum TaskCategory { Personal, Work, Sports, Shopping, Study }

    class Task
    {
        public string Description { get; set; }
        public TaskPriority Priority { get; set; }
        public DateTime DueDate { get; set; }
        public TaskStatus Status { get; set; }
        public TaskCategory Category { get; set; }
    }

    class Program
    {

        static List<Task> tasks = new List<Task>();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the ToDo List");
            while (true)
            {
                Console.WriteLine("Please select an option");
                Console.WriteLine("1. Add a task");
                Console.WriteLine("2. View tasks");
                Console.WriteLine("3. Update the status of your tasks");
                Console.WriteLine("4. Sorting the tasks");
                Console.WriteLine("5.Deletion of tasks");
                Console.WriteLine("6. Filtering the tasks");
                Console.WriteLine("7.Exit");

                int choice = GetUserChoice();

                switch (choice)
                {
                    case 1:
                        AddTask();
                        break;

                    case 2:
                        ViewTasks();
                        break;

                    case 3:
                        UpdateStatus();
                        break;
                    case 4:
                        SortTasksByPriority();
                        break;

                    case 5: 
                        DeleteTask();
                        break;    

                    case 6:
                        FilterTasks();
                        break;
                        
                    case 7:
                        Console.WriteLine("Goodbye!, see you later");
                        return;


                    default:
                        Console.WriteLine("Invalid Choice. Please enter a number again");
                        break;
                }
            }
        } // End of the Main Method

        static int GetUserChoice()
        {
            while (true)
            {
                Console.WriteLine("What you wanna do");

                if (int.TryParse(Console.ReadLine(), out int choice) && (choice >= 1 && choice <= 7))
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine("Please enter a valid choice");
                }
            }
        } // End of the user choice

        static void AddTask()
        {
            Console.WriteLine("Enter a task that you want to do today");
            string taskDescription = Console.ReadLine();

            // Ask user to add the task priority
            Console.WriteLine("Enter the task priority (High/Medium/Low)");
            Enum.TryParse(Console.ReadLine(), out TaskPriority taskPriority);

            // Ask user to add the due date
            Console.WriteLine("Enter the due date (DD-MM-YYYY)");
            DateTime.TryParse(Console.ReadLine(), out DateTime dueDate);

            
            if (IsValidDueDate(dueDate))
            {
                Console.WriteLine("Choose the task category");
                foreach (TaskCategory category in Enum.GetValues(typeof(TaskCategory)))
                {
                    Console.WriteLine($"{(int)category}.{category}");
                }
                Enum.TryParse(Console.ReadLine(), out TaskCategory taskCategory);

                tasks.Add(new Task
                {
                    Description = taskDescription,
                    Priority = taskPriority,
                    DueDate = dueDate,
                    Status = TaskStatus.Pending,
                    Category = taskCategory
                });

                Console.WriteLine("The task has been added successfully");
                Console.WriteLine(); // For space
            }
            else
            {
                Console.WriteLine("Invalid due date. Please enter a valid date.");
            }
        }

        static void ViewTasks()
        {
            Console.WriteLine("\nTasks:");
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Description: {tasks[i].Description}, Priority: {tasks[i].Priority}, Due Date: {tasks[i].DueDate.ToString("dd-MM-yyyy")} , Status: {tasks[i].Status}, Category:{tasks[i].Category}");
                Console.WriteLine();
            }
        } // End of the View the task

        static void UpdateStatus()
        {
            ViewTasks();

            Console.WriteLine("Enter the index of the task for which you need to need update :");
            if (int.TryParse(Console.ReadLine(), out int taskIndex) && taskIndex >= 1 && taskIndex <= tasks.Count)
            {
                Console.WriteLine("Enter the new status of the task(Pending/Completed/InProgress)");
                Enum.TryParse(Console.ReadLine(), out TaskStatus newStatus);
                tasks[taskIndex - 1].Status = newStatus;
                Console.WriteLine("Your status of the task is updated");
            }

            else
            {
                Console.WriteLine("Invalid Index entered by you , seems like you are dozed off with completion of your tasks");
            }
        }


        static void SortTasksByPriority()
        {
            Console.WriteLine("Mention a critera in which manner you would like to sort the tasks");
            Console.WriteLine("1. Sort it by the due dates of the tasks");
            Console.WriteLine("2. Sort it by the Priority");
            Console.WriteLine("3. Sort it by Status");

            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= 3)
            {
                switch (choice)
                {
                    case 1:
                        tasks = tasks.OrderBy(task => task.DueDate).ToList();
                        break;

                    case 2:
                        tasks = tasks.OrderByDescending(task => task.Priority).ToList();
                        break;

                    case 3:
                        tasks = tasks.OrderBy(task => task.Status).ToList();
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        return;
                }
                Console.WriteLine("Tasks have been sorted");

            }

            else
            {
                Console.WriteLine("Invalid choice");
            }

        } // end of the sorting tasks

        static bool IsValidDueDate(DateTime dueDate)
        {
            DateTime today = DateTime.Today;
            DateTime minDate = today.AddYears(-1); // One year in the past
            DateTime maxDate = today.AddYears(10); // Ten years in the future

            return dueDate >= minDate && dueDate <= maxDate;
        }

        static void DeleteTask(){
            ViewTasks();

            Console.WriteLine("Enter the index of the task you want to delete");

            if (int.TryParse(Console.ReadLine(),out int taskIndex) && taskIndex>=1 && taskIndex<=tasks.Count)
            {
                tasks.RemoveAt(taskIndex-1);
                Console.WriteLine("Task deleted successfully");
            }

            else {
                Console.WriteLine("Invalid index entered");
            }
        }
        static void FilterTasks() {
            Console.WriteLine("Choose a status to filter the tasks");
            foreach (TaskStatus status in Enum.GetValues(typeof(TaskStatus))){
                Console.WriteLine($"{(int) status}.{status}");

            }
            if(Enum.TryParse(Console.ReadLine(),out TaskStatus selectedStatus)){
                    List<Task> filteredTasks= tasks.Where(task=>task.Status==selectedStatus).ToList();
                    Console.WriteLine("Filtered Tasks:");
                    for (int i = 0; i < filteredTasks.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. Description: {filteredTasks[i].Description}, Priority: {filteredTasks[i].Priority}, Due Date: {filteredTasks[i].DueDate.ToString("dd-MM-yyyy")} , Status: {filteredTasks[i].Status}, Category:{filteredTasks[i].Category}");
                                Console.WriteLine();
                            }

            }

            else {
                Console.WriteLine("Invalid status selected");
            }
        }

    } // End of the Class Program
}
