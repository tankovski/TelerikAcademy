using System;

static class GSMTest
{
    static GSM[] gsmTesting = new GSM[]
        {
            new GSM("Nokia","Japan",300,"Joro"),
            new GSM("Samsung","Japan",300,"Ivo",new Battery("sony",20,20,Battery.BatteryType.NiMH),new Display(30,5000))
        };

    public static void GSMTesing()
    {
        foreach (GSM gsm in gsmTesting)
        {
            Console.WriteLine(gsm.ToString()+"\n");
        }
        Console.WriteLine(GSM.iPhone4S);
    }
}

