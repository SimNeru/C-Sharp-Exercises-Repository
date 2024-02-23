public class Manager : Employee
{
    private string _departmentName;

    public string DepartmentName 
    {
        set { _departmentName = value; }

        get { return _departmentName;  }
    }

    public long GetTotalSalesOfTheYear() 
    {
        return 10000;
    }
}

