using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCourseAPI.ProgrammingConcepts.IndexersDemo
{
    public class Employee
    {
        private int Eno;
        private string Ename, Job, Dname, Location;
        private double Salary;




        public Employee(int empNumber, string employeeName, string job, string departmentName, string location, double salary)
        {
            this.Eno = empNumber;
            this.Ename = employeeName;
            this.Job = job;
            this.Dname = departmentName;
            this.Location = location;
            this.Salary = salary;
        }

        public Object this[int index]
        {
            get
            {
                switch(index)
                {
                    case 0:
                        {
                            return this.Eno;
                        }
                    case 1:
                        {
                            return this.Ename;
                        }
                    case 2:
                        {
                            return this.Job;
                        }
                    case 3:
                        {
                            return this.Dname;
                        }
                    case 4:
                        {
                            return this.Location;
                        }
                    case 5:
                        {
                            return this.Salary;
                        }
                        default:
                        {
                            return null;
                        }
                }
            }

        }
        

    }
}
