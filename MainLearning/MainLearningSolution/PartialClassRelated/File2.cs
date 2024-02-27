public partial class Product
{
    //private field
    private double _cost;

    public double Cost
    {
        set { _cost = value; }

        get { return _cost; }
    }

    public void CallGetTax() { GetTax(); }
}

