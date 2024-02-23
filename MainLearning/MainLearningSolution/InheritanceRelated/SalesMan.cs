public class SalesMan : Employee
{
    public string Region { get; set; }

    public long GetSalesOfCurrentMonth() 
    {
        return 50000;
    }
}

