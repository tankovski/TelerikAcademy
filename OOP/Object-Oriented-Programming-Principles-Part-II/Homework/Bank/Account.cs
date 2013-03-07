using System;


public abstract class Account
{
    //Fields
    private Customer customer;
    private decimal balance;
    private decimal interestRate;

    //Properties
    public Customer Customer
    {
        get { return this.customer; }
        set { this.customer = value; }
    }
    public decimal Balance
    {
        get { return this.balance; }
        set { this.balance = value; }
    }
    public decimal InterestRate
    {
        get { return this.interestRate; }
        set
        {
            if (value<0)
            {
                throw new ArgumentException("The interestRate must be positive number!");
            }
            this.interestRate = value;
        }
    }

    //Constructor
    public Account(Customer customer, decimal balance, decimal interestRate)
    {
        this.Customer = customer;
        this.Balance = balance;
        this.InterestRate = interestRate;
    }

    //Methods
    public virtual decimal InterestAmountForPeriod(uint mounts)
    {
        return (this.Balance * this.InterestRate) * mounts;
    }
}

