public struct Category
{
    private int _categoryID;
    private string _categoryName;

    //parametrized constructor, necessario inizializzare tutti i fields della classe
    public Category(int categoryID, string categoryName) 
    {
        _categoryID = categoryID;
        _categoryName = categoryName;
    }

    public int CategoryID 
    {
        get { return _categoryID;}

        set
        {
            if (value >= 1 && value <= 100)
            {
                _categoryID = value;
            }
        }
    }

    public string CategoryName 
    {
        get { return _categoryName; }

        set {
            if (value.Length <= 40) 
            {
                _categoryName = value;
            }
        }
    }

    public int GetCategoryNameLenght() 
    {
        return _categoryName.Length;
    }
}

