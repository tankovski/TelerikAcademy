using System;

public class Performance
{
    public string Operation{get; private set;}
    public string Type { get; private set; }
    public TimeSpan PerformanceTime { get; private set; }

    public Performance(string operation, string type, TimeSpan performanceTime)
    {
        this.Operation = operation;
        this.Type = type;
        this.PerformanceTime = performanceTime;
    }
}

