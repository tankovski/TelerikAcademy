using System;


public class DepositAccount:Account,IDeposit,IDraw
{
    //Constructor
    public DepositAccount(Customer customer, decimal balance, decimal interestRate)
        : base(customer, balance, interestRate)
    { }

    //Methods
    public void AddDeposit(decimal deposit)
    {
        if (deposit < 0)
        {
            throw new ArgumentOutOfRangeException("The money you try to deposit are negative number!");
        }
        else
        {
            this.Balance += deposit;
        }  
    }
    public void Draw(decimal drawMoney)
    {
        if (drawMoney<0)
        {
            throw new ArgumentOutOfRangeException("The money you try to draw are negative number!");
        }
        else
        {
            this.Balance -= drawMoney;
        }        
    }
    public override decimal InterestAmountForPeriod(uint mounts)
    {
        if (this.Balance<=1000 && this.Balance>=0)
        {
            return 0;
        }
        else
        {
            return (this.Balance * this.InterestRate) * mounts;
        }
    }
}

