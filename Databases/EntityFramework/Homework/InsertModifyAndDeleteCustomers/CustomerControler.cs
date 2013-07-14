using System;
using System.Linq;
using NorthwindEntetiesData;

public static class CustomerControler
{
    public static void InsertCustomer(string customerId, string companyName, string contactName, string contactTitle,
        string adress, string city, string region, string postalCode, string country, string phone, string fax)
    {
        if (customerId.Length == 0 || customerId.Length>5)
        {
            throw new ArgumentException("The lenght of CustomerId must be between 0 and 5 characters!");
        }
        
        using (NorthwindEntities nwDb = new NorthwindEntities())
        {
            Customer cusomer = new Customer
            {
                CustomerID = customerId,
                CompanyName = companyName,
                ContactName = contactName,
                ContactTitle = contactTitle,
                Address = adress,
                City = city,
                Region = region,
                PostalCode = postalCode,
                Country = country,
                Phone = phone,
                Fax = fax
            };
            nwDb.Customers.Add(cusomer);
            nwDb.SaveChanges();
        }
    }

    public static void DeleteCustomer(string customerId)
    {
        using (NorthwindEntities nwDb = new NorthwindEntities())
        {
            Customer customer = nwDb.Customers.FirstOrDefault(c => c.CustomerID == customerId);
            nwDb.Customers.Remove(customer);
            nwDb.SaveChanges();
        }
    }

    //This way we can moify every column
    public static void ModifyCustomerCompanyName(string customerId, string newCompanyName)
    {
        using (NorthwindEntities nwDb = new NorthwindEntities())
        {
            Customer customer = nwDb.Customers.FirstOrDefault(c => c.CustomerID == customerId);
            customer.CompanyName = newCompanyName;
            nwDb.SaveChanges();
        }
    }

    public static void ModifyCustomerContactName(string customerId, string newContactName)
    {
        using (NorthwindEntities nwDb = new NorthwindEntities())
        {
            Customer customer = nwDb.Customers.FirstOrDefault(c => c.CustomerID == customerId);
            customer.ContactName = newContactName;
            nwDb.SaveChanges();
        }
    }
}

