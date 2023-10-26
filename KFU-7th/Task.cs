using System;

namespace KFU_7th
{
    enum Tasks
    {
        Development,
        Systems,
        Superiors
    }
    class Task
    {
        public string Description { get; private set; }
        public Employee Manager { get; private set; }
        public Employee Executor { get; private set; }
        public Tasks TypeOfTask { get; private set; }

        public Task(string description, Employee manager, Employee executor, Tasks typeOfTask)
        {
            Description = description;
            Manager = manager;
            Executor = executor;
            TypeOfTask = typeOfTask;    
        }

    }
}
