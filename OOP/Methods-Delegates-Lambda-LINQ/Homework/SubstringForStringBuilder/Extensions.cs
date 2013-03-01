using System;
using System.Text;

public static class Extensions
{
    public static StringBuilder Substring(this StringBuilder sb,int index,int lenght)
    {
        StringBuilder temp = new StringBuilder();
        string text = sb.ToString();
        text = text.Substring(index, lenght);
        return temp.Append(text);
    }
}

