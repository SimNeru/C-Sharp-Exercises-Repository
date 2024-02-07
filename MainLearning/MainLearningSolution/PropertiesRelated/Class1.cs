using System.Runtime.InteropServices.WindowsRuntime;

public class Class1
{
    private int _id;
    private string _name;
    private string _job;
    
    //quando sono readonly usabile solo la proprietà GET
    private readonly double _salary = 1200;

    //può non essere readonly ma lo può essere la proprietà GET
    private double _tax;

    
    
    private static string _companyName;

    //ISTANCE PROPERTY
    public int EmpID 
    {
        get { return _id; }
        
        //code to validate the value
        set
        {
            if (value >= 100)
            {  
                _id = value; 
            }
        }
    }

    public string EmpName
    {
        get { return _name; }
        set { _name = value; }
    }

    public string EmpJob
    {
        get { return _job; }
        set { _job = value; }
    }

    //STATIC PROPERTY
    public string EmpCompany
    {
        get { return _companyName; }
        
        //code to validate the value
        set 
        {
            if (value.Length <= 10) 
            { 
                _companyName = value; 
            }
        }
    }

    //PROPERTY DI UN READONLY
    public double EmpSalary
    { 
        get { return _salary; }

        //set { _description = value}; darà errore perché trattasi di un campo di sola lettura
    }
    
    /*FUNZIONA MA USABILE SOLO IN VERSIONI DI C# 8.0
    
    public readonly string EMPLicensePlate
    {
        get {return _licensePlate; }
    }*/

    //PROPERTY DI UN WRITE ONLY
    public double Tax 
    { 
        set 
        { 
            if (value > 0 && value <= 100) 
            {
                _tax = value;
            }
        }
    }

    //Method
    public double CalculateNetSalary() 
    { 
        double t = EmpSalary - _tax;
        return t;
    }
}

