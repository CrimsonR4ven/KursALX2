using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D4_ObserverCollection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeList employees = new EmployeeList();
            employees.CollectionChanged += EmployeeListChanged;
            employees.Add(new Employee() { Name = "Dolan Dusk" });
            employees.Insert(0,new Employee() { Name = "Jan Kowalski" });
            employees.RemoveAt(1);
        }

        private static void EmployeeListChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Console.Clear();
            Console.WriteLine(e.Action + "\n");
            foreach(Employee emp in sender as EmployeeList)
            {
                Console.WriteLine(emp.Name);
            }
            Console.ReadKey();
        }
    }
}
