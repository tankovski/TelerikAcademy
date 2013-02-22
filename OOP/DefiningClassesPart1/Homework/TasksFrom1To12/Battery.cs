using System;

class Battery
{
    //Enumeration
    public enum BatteryType
    {
        NiMH, NiCd, LithiumPolymer, LithiumLon
    }

    //Fields
    private string model;
    private int? hoursIdle;
    private int? hoursTalk;
    private BatteryType? batteryType;


    //Constructors
    public Battery()
        : this(null)
    {

    }
    public Battery(string model)
        : this(model, null)
    {
    }
    public Battery(string model, int? hoursIdle)
        : this(model, hoursIdle, null)
    {
    }
    public Battery(string model, int? hoursIdle, int? hoursTalk)
        : this(model, hoursIdle, hoursTalk, null)
    {
    }
    public Battery(string model, int? hoursIdle, int? hoursTalk, BatteryType? batteryType)
    {
        this.Model = model;
        this.HoursIdle = hoursIdle;
        this.HoursTalk = hoursTalk;
        this.BatteryType1 = batteryType;
    }

    //Prperties
    public string Model
    {
        get { return this.model; }
        set
        {
            if (value!=null && value.Length<2 )
            {
                throw new ArgumentException("The battery model must be at least two characters long");
            }
            this.model = value;
        }
    }
    public int? HoursIdle
    {
        get { return this.hoursIdle; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("The hours idle can't be a negative number");
            }
            this.hoursIdle = value;
        }
    }
    public int? HoursTalk
    {
        get { return this.hoursTalk; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("The hours talk can't be a negative number");
            }
            this.hoursTalk = value;
        }
    }
    public BatteryType? BatteryType1
    {
        get { return this.batteryType; }
        set { this.batteryType = value; }
    }

    //Methods
    public string GetBatteryInfo()
    {
        string batteryInfo = "Batter-model: " + model + "\n" + "Battery-hours idle:" + hoursIdle + "\n" +
            "Battery-hours talk:" + hoursTalk + "\n" + "Battery-type: " + batteryType;
        return batteryInfo;
    }
}

