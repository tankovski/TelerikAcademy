using System;

class LoanAccount:Account,IDeposit
{
    //Constructor
    public LoanAccount(Customer customer, decimal balance, decimal interestRate)
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

    public override decimal InterestAmountForPeriod(uint mounts)
    {
        if (this.Customer.GetType().ToString()=="Individual")
        {
            if (mounts<=3)
            {
                return 0;
            }
            else
            {
                return (this.Balance * this.InterestRate) * (mounts - 3);
            }
        }
        else
        {
            if (mounts<=2)
            {
                return 0;
            }
            else
            {
                return (this.Balance * this.InterestRate) * (mounts - 2);
            }
        }
    }
}

