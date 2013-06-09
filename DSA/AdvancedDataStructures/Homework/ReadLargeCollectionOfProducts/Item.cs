using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Item : IComparable<Item>
{
    private string name;
    private int price;

    public string Name
    {
        get { return this.name; }
        private set { }
    }

    public int Price
    {
        get { return this.price; }
        private set { }
    }

    public Item(string name, int price)
    {
        this.name = name;
        this.price = price;
    }

    public int CompareTo(Item oderItem)
    {
        return this.price.CompareTo(oderItem.price);
    }
}
