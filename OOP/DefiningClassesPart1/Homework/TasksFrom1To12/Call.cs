using System;


class Call
{
    //fields
    private DateTime dateTime;
    private string phone;
    private long duration;
   

    //Constructor

    public Call(DateTime dateTime, string phone, long duration)
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
    public string Phone
    {
        get { return this.phone; }
        set
        {
            foreach (char ch in value)
            {
                if (!char.IsDigit(ch) && ch!='-')
                {
                    throw new ArgumentException("The phone number must contain onli digits or '-'!");
                }
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

