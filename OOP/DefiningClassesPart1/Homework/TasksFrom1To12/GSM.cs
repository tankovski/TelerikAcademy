using System;
using System.Collections.Generic;

class GSM
{   //Fields
    private string model;
    private string manufacturer;
    private decimal? price;
    private string owner;
    private Battery battery;
    private Display display;
    internal static GSM iPhone4S=new GSM("IPhone4S","Apple",1500,"Joro Iliev");
    private static List<Call> callHistory = new List<Call>();
    
   //Constructor
    public GSM(string model, string manufacturer, decimal? price = null, string owner = null, Battery battery = null, Display display = null)
    {
        this.Model = model;
        this.Manufacturer = manufacturer;
        this.Price = price;
        this.Owner = owner;
        this.Battery1 = battery;
        this.Display1 = display;
    }

    //Properties
    public string Model
    {
        get { return this.model; }
        set
        {
            if (value!=null && value.Length<2)
            {
                throw new ArgumentException("The lenght of the GSM model must be at least 2 simbols");
            }
            this.model = value;
        }
    }
    public string Manufacturer
    {
        get { return this.manufacturer; }
        set
        {
            if (value != null && value.Length < 2)
            {
                throw new ArgumentException("The lenght of the GSM manufacturer must be at least 2 simbols");
            }
            this.manufacturer = value;
        }
    }
    public decimal? Price
    {
        get { return this.price; }
        set
        {
            if (value<0)
            {
                throw new ArgumentException("The GSM price must be a positive number!");
            }
            this.price = value;
        }
    }
    public string Owner
    {
        get { return this.owner; }
        set
        {
            if (value != null && value.Length < 2)
            {
                throw new ArgumentException("The name of the GSM owner must be at least 2 simbols");
            }
            if (value!=null)
            {
                foreach (char ch in value)
                {
                    if (!IsLetterAllowedInNames(ch))
                    {
                        throw new ArgumentException("Invalid name! Use only letters, space and hyphen");
                    }
                }
            }
            
            this.owner = value;
        }
    }
    public Battery Battery1
    {
        get { return this.battery; }
        set { this.battery = value; }
    }
    public Display Display1
    {
        get { return this.display; }
        set { this.display = value; }
    }
    public GSM IPhone4S
    {
        get { return iPhone4S; }
    }
   


    //Metods
    public override string ToString()
    {
        string gsmInfo= "Model: " + model + "\n" + "Manufacturer: " + manufacturer + "\n" + "Price: " + price + "\n" + "Owner: " + owner;
        if (battery!=null)
        {
            gsmInfo +="\n"+ battery.GetBatteryInfo();
        }
        if (display!=null)
        {
            gsmInfo += "\n" + display.GetDisplayInfo(); 
        }
        return gsmInfo;
    }

    private bool IsLetterAllowedInNames(char ch)
    {
        bool isAllowed =
            char.IsLetter(ch) || ch == '-' || ch == ' ';
        return isAllowed;
    }
    public void AddCall(Call call)
    {
        callHistory.Add(call);
    }
    public void DeleteCall(int num)
    {

        callHistory.RemoveAt(num);

    }
    public void ClearCallHistory()
    {
        callHistory.Clear();
    }
    public void CalculateTotalCallsPrice(decimal price)
    {
        decimal sum = 0;
        foreach (Call call in callHistory)
        {
            sum += call.Duration * price;
        }
        Console.WriteLine("The total praice of all calls is : {0}lv.", sum);
    }
    public void PrintCallHistiry()
    {
        for (int i = 0; i < callHistory.Count; i++)
        {
            Console.WriteLine("Call{0}:\nDateAndTime: {1}\nPhone: {2}\nDuration: {3}", i, callHistory[i].DateAndTime, callHistory[i].Phone, callHistory[i].Duration);
        }
    }
}

