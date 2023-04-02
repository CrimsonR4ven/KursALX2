using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D4_ObserverCollection
{
    public class Employee
    {
        public string Name { get; set; }
        public bool? IsManager { get; set; }
        public double Salary { get; set; }
    }
    public class EmployeeList : ObservableCollection<Employee>
    {
        public EmployeeList() 
        {
            Add(new Employee() { Name = "Jack Heisenberg" });
            Add(new Employee() { Name = "John Bjornsonn" });
            Add(new Employee() { Name = "Edgar Kodd" });
            Add(new Employee() { Name = "Marek Nowak" });
            Add(new Employee() { Name = "Place Holder", IsManager = true, Salary=52340.1});
        }
    }
}
