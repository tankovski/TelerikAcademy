using System;

class Program
{
    static void Main(string[] args)
    {

        //A bank holds different types of accounts for its customers: deposit accounts, loan 
        //accounts and mortgage accounts. Customers could be individuals or companies.
	    //All accounts have customer, balance and interest rate (monthly based). Deposit accounts
        //are allowed to deposit and with draw money. Loan and mortgage accounts can only deposit money.
        //All accounts can calculate their interest amount for a given period (in months). In the 
        //common case its is calculated as follows: number_of_months * interest_rate.
        //Loan accounts have no interest for the first 3 months if are held by individuals and for the 
        //first 2 months if are held by a company.
        //Deposit accounts have no interest if their balance is positive and less than 1000.
        //Mortgage accounts have ½ interest for the first 12 months for companies and no interest for the
        //first 6 months for individuals.
        //Your task is to write a program to model the bank system by classes and interfaces. You should
        //identify the classes, interfaces, base classes and abstract actions and implement the calculation
        //of the interest functionality through overridden methods.






        //Make two customers - one company and one individual
        Company kaBar = new Company("KaBar");
        Individual peter = new Individual("Peter Petrov");

        //Make deposite account for individual and company and test the account functionalities
        DepositAccount peterDepositAcount = new DepositAccount(peter, 500m, 0.05m);
        DepositAccount kaBarDepositAcount = new DepositAccount(kaBar, 500m, 0.05m);
        peterDepositAcount.Draw(200m);
        Console.WriteLine(peterDepositAcount.Balance);
        peterDepositAcount.AddDeposit(200);
        Console.WriteLine(peterDepositAcount.Balance);

        Console.WriteLine("The {0} of the {1}-{2} have interest amount for next six mounths: {3} "
            , peterDepositAcount.GetType(), peterDepositAcount.Customer.GetType(), peterDepositAcount.Customer.Name, peterDepositAcount.InterestAmountForPeriod(6));
        Console.WriteLine("The {0} of the {1}-{2} have interest amount for next six mounths: {3} "
            , kaBarDepositAcount.GetType(), kaBarDepositAcount.Customer.GetType(), kaBarDepositAcount.Customer.Name, kaBarDepositAcount.InterestAmountForPeriod(6));
        Console.WriteLine("--------------------------------------------------------------------");


        //Make loan account for individual and company and test the account functionalities
        LoanAccount peterLoanAccount = new LoanAccount(peter, 500m, 0.05m);
        Console.WriteLine("The {0} of the {1}-{2} have interest amount for next six mounths: {3} "
            , peterLoanAccount.GetType(), peterLoanAccount.Customer.GetType(), peterLoanAccount.Customer.Name, peterLoanAccount.InterestAmountForPeriod(6));

        LoanAccount kaBarLoanAccount = new LoanAccount(kaBar, 500m, 0.05m);
        Console.WriteLine("The {0} of the {1}-{2} have interest amount for next six mounths: {3} "
            , kaBarLoanAccount.GetType(), kaBarLoanAccount.Customer.GetType(), kaBarLoanAccount.Customer.Name, kaBarLoanAccount.InterestAmountForPeriod(6));
        Console.WriteLine("--------------------------------------------------------------------");


        //Make Mortage account for individual and company and test the account functionalities
        MortageAccount peterMortageAccount = new MortageAccount(peter, 500m, 0.05m);
        Console.WriteLine("The {0} of the {1}-{2} have interest amount for next two years: {3} "
            , peterMortageAccount.GetType(), peterMortageAccount.Customer.GetType(), peterMortageAccount.Customer.Name, peterMortageAccount.InterestAmountForPeriod(24));
        MortageAccount kaBarMortageAccount = new MortageAccount(kaBar, 500m, 0.05m);
        Console.WriteLine("The {0} of the {1}-{2} have interest amount for next two years: {3} "
            , kaBarMortageAccount.GetType(), kaBarMortageAccount.Customer.GetType(), kaBarMortageAccount.Customer.Name, kaBarMortageAccount.InterestAmountForPeriod(24));

    }
}

