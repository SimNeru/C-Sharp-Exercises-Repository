/* La keyword SEALED può essere usata per impedire l'ereditarietà di una classe
   oppure per impedire l'override di un metodo destinato all'override ma solo fino
   a determinati requisiti */
public class Employee
{
    private int _empID;
    private string _empName;
    private string _location;
    private long _paycheck;
    private string _prova;

    //costruttore classe genitore
    public Employee(int empID, string empName, string location) 
    {
        _empID = empID;
        _empName = empName;
        _location = location;
        _paycheck = 1200;
    }

    //metodo classe padre per esempio hiding
    public string GetHealthInsuranceAmount() 
    {
        return "Health insurance amount is: " + 500;
    }

    /* Estendendo il metodo, creando un metodo con la stessa firma si tratta di override
     * a differenza del sistema HIDING, che nasconderà completamente il metodo della della classe genitore
     * il method overriding invece eseguirà in contemporanea sia il metodo esteso che quello che lo eredita
     */
    public virtual long GetPaycheckAmount() 
    {
        return _paycheck;
    }

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
