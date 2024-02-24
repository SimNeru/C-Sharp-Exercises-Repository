public class Manager : Employee
{
    private string _departmentName;

    //constructor classe figlia
    public Manager(int empID, string empName, string location, string departmentName) : base(empID,empName,location)
    {
        _departmentName = departmentName;
    }

    public string DepartmentName 
    {
        set { _departmentName = value; }

        get { return _departmentName;  }
    }

    //Ridefinizione del metodo padre, metod hiding
    public new string GetHealthInsuranceAmount() 
    {
        return "Health insurance is: 1500";
    }

    //method overriding di employee
    public override long GetPaycheckAmount()
    {
        return base.GetPaycheckAmount() + 1000;
    }

    public long GetTotalSalesOfTheYear() 
    {
        return 10000;
    }

    /* base è la keyword usata per rappresentare i membri della classe genitore in quella figlia
     * opzionale usarla, presente di default
     * da usare quando presente ambiguità di nome tra i membri di una classe padre e figlie
     */

    public string GetFullDepartmentName()
    {
        return DepartmentName + " at " + base.Location;
    }
}

