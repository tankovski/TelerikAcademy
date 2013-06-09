using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Article:IComparable<Article>
{
    public int Barcode { get; set; }
    public string Vedndor { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }

    public Article(int barcode, string vendor, string title, decimal price)
    {
        this.Barcode = barcode;
        this.Vedndor = vendor;
        this.Title = title;
        this.Price = price;
    }

    public int CompareTo(Article otherArticle)
    {
        return this.Price.CompareTo(otherArticle.Price);
    }
}

