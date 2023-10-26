using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace KFU_7th
{
    class Employee
    {
        public string Name { get; private set; }
        public List<Employee> Subordinates { get; private set; }
        public Tasks Tasks { get; private set; }

        public Employee(string name, Tasks tasks)
        {
            Name = name;
            Subordinates = new List<Employee>();
            Tasks = tasks;
        }

        public void AddSubordinate(Employee subordinate)
        {
            Subordinates.Add(subordinate);
        }
    }
}
