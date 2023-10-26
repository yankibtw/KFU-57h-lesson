using KFU_7th;
using System;
using System.Collections.Generic;

namespace TaskAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee semyon = new Employee("Семён", Tasks.Superiors);
            Employee rashid = new Employee("Рашид", Tasks.Superiors);
            Employee oIlkham = new Employee("О Ильхам", Tasks.Superiors);
            Employee orkadiy = new Employee("Оркадий", Tasks.Superiors);
            Employee volodya = new Employee("Володя", Tasks.Superiors);
            Employee lukas = new Employee("Лукас", Tasks.Superiors);
            Employee ilshat = new Employee("Ильшат", Tasks.Superiors);
            Employee ivanych = new Employee("Иваныч", Tasks.Superiors);
            Employee ilya = new Employee("Илья", Tasks.Systems);
            Employee vitya = new Employee("Витя", Tasks.Systems);
            Employee jenya = new Employee("Женя", Tasks.Systems);
            Employee sergey = new Employee("Сергей", Tasks.Superiors);
            Employee lyaysan = new Employee("Ляйсан", Tasks.Superiors);
            Employee marat = new Employee("Марат", Tasks.Development);
            Employee dina = new Employee("Дина", Tasks.Development);
            Employee ildar = new Employee("Ильдар", Tasks.Development);
            Employee anton = new Employee("Антон", Tasks.Development);

            semyon.AddSubordinate(rashid);
            semyon.AddSubordinate(oIlkham);
            rashid.AddSubordinate(lukas);
            oIlkham.AddSubordinate(orkadiy);
            orkadiy.AddSubordinate(volodya);
            orkadiy.AddSubordinate(sergey);
            orkadiy.AddSubordinate(ilshat);
            volodya.AddSubordinate(ilshat);
            volodya.AddSubordinate(sergey);
            sergey.AddSubordinate(lyaysan);
            lyaysan.AddSubordinate(marat);
            lyaysan.AddSubordinate(dina);
            lyaysan.AddSubordinate(anton);
            lyaysan.AddSubordinate(ildar);
            ilshat.AddSubordinate(ivanych);
            ivanych.AddSubordinate(ilya);
            ivanych.AddSubordinate(vitya);
            ivanych.AddSubordinate(jenya);

            List<Task> tasks = new List<Task>
            {
                new Task("Создание веб-сайта", sergey, marat, Tasks.Development),
                new Task("Создание приложения", lyaysan, dina, Tasks.Development),
                new Task("Настройка сети", oIlkham, marat, Tasks.Systems),
                new Task("Настройка оборудования", ivanych, ilya, Tasks.Systems),
                new Task("Разработка нового проекта", sergey, marat, Tasks.Superiors),
                new Task("Выполнить бухгалтерский отчет", rashid, lukas, Tasks.Superiors),
            };

            foreach (var task in tasks)
            {
                if(WillBeExecuted(task.Manager, task.Executor, task.TypeOfTask))
                    Console.WriteLine($"Задача '{task.Description}', заданная от {task.Manager.Name} для {task.Executor.Name} будет выполнена!(берет)");
                else
                    Console.WriteLine($"Задача '{task.Description}', заданная от {task.Manager.Name} для {task.Executor.Name} не будет выполнена!(не берет)");
            }

            bool WillBeExecuted(Employee manager, Employee executor, Tasks Type)
            {
                if (manager.Subordinates.Contains(executor))
                {
                    if(executor.Tasks == Type)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

    }
}
