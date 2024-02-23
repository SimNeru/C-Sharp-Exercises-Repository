public class Employee
{
    private int _empID;
    private string _empName;
    private string _location;
    private string _prova;

    public int EmpID 
    {
        set { this._empID = value; }
        
        get { return _empID; } 
    }

    public string EmpName 
    {
        set { this._empName = value;  }

        get { return _empName; }
    }

    public string Location 
    {
        set { this._location = value; }
        
        get { return _location; }
    }
}
