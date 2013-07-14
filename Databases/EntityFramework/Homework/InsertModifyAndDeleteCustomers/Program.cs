using System;
using NorthwindEntetiesData;

class Program
{
    static void Main()
    {

        //CustomerControler.InsertCustomer("Mtel", "Mtel", "Pesho", "Menidjer", "Mladost 133", "Sofia", "Sofia", "1505", "Bulgaria",
        //    "088888888", "123456");
        //CustomerControler.DeleteCustomer("Mtel");

        //CustomerControler.ModifyCustomerCompanyName("ALFKI", "NEWNAME");
        CustomerControler.ModifyCustomerContactName("ALFKI", "NEWNAME");
    }
}

