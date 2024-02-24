public class SalesMan : Employee
{
    public string Region { get; set; }

    //constructor child class
    public SalesMan(int empID, string empName, string location, string region) : base (empID, empName, location) 
    {
        Region = region;
    }

    //override del motodo virtual di Employee
    public override long GetPaycheckAmount()
    {
        return base.GetPaycheckAmount() + 400;
    }

    public long GetSalesOfCurrentMonth() 
    {
        return 50000;
    }
}

