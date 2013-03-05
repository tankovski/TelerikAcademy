using System;


public class Worker:Human
{
    //Fields
    private int weekSalary;
    private int workHoursPerDay;

    public int WeekSalary
    {
        get { return this.weekSalary; }
        set 
        {
            if (value<0)
            {
                throw new ArgumentException("The salary can't be a negative number!");
            }
            this.weekSalary = value;
        }
    }
    public int WorkHoursPerDay
    {
        get { return this.workHoursPerDay; }
        set
        {
            if (value<=0)
            {
                throw new ArgumentException("The worker must work at least one hour to be a worker!");
            }
            if (value>12)
            {
                throw new ArgumentException("Worker can work maksimum 12 hours!");
            }
            this.workHoursPerDay = value;
        }
    }

    //Constructor
    public Worker(string firstName, string lastName, int weekSalary, int workHoursPerDay)
        : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    //Methods
    public decimal MoneyPerHour()
    {
        return (decimal)weekSalary / (workHoursPerDay * 5);//If the working days are 5
    }
}

