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

            set
            {
                switch(index )
                {
                    case 0:
                        this.Eno = (int)value; 
                        break;
                    case 1:
                        this.Ename = (string)value;
                        break;
                    case 2:
                        this.Job = (string)value;
                        break;
                    case 3:
                        this.Dname = (string)value;
                        break;
                    case 4:
                        this.Location = (string)value;
                        break;
                    case 5:
                        this.Salary = (double)value;
                        break;
                    
                   
                }
            }

        }


        public Object this[string name]
        {
            get
            {
                switch (name.ToLower())
                {
                    case "eno":
                        {
                            return this.Eno;
                        }
                    case "ename":
                        {
                            return this.Ename;
                        }
                    case "job":
                        {
                            return this.Job;
                        }
                    case "dname":
                        {
                            return this.Dname;
                        }
                    case "location":
                        {
                            return this.Location;
                        }
                    case "salary":
                        {
                            return this.Salary;
                        }
                    default:
                        {
                            return null;
                        }
                }
            }

            set
            {
                switch (name.ToLower())
                {
                    case "eno":
                        this.Eno = (int)value;
                        break;
                    case "ename":
                        this.Ename = (string)value;
                        break;
                    case "job":
                        this.Job = (string)value;
                        break;
                    case "dname":
                        this.Dname = (string)value;
                        break;
                    case "location":
                        this.Location = (string)value;
                        break;
                    case "salary":
                        this.Salary = (double)value;
                        break;


                }
            }

        }


    }
}
