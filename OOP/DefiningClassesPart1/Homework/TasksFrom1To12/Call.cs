using System;


class Call
{
    //fields
    private DateTime dateTime;
    private int phone;
    private long duration;
   

    //Constructor

    public Call(DateTime dateTime, int phone, long duration)
    {
        this.DateAndTime = dateTime;
        this.Phone = phone;
        this.Duration = duration;
    }


    //Properties
    public DateTime DateAndTime
    {
        get { return this.dateTime; }
        set { this.dateTime = value; }
    }
    public int Phone
    {
        get { return this.phone; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("The phone number can't be a negatuve number!");
            }
            this.phone = value;
        }
    }
    public long Duration
    {
        get { return this.duration; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("The duration of the call can't be a negative number!");
            }
            this.duration = value;
        }
    }

   
}

