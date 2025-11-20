using System.Collections.Generic;
using TestEdwinZR;
// Dataset
List<Category> DsCategories = new List<Category> {
    new Category { CategoryId = 100, ParentCategoryId = -1, Name = "Business", Keywords = "Money" },
    new Category { CategoryId = 200, ParentCategoryId = -1, Name = "Tutoring", Keywords = "Teaching" },
    new Category { CategoryId = 101, ParentCategoryId = 100, Name = "Accounting", Keywords = "Taxes" },
    new Category { CategoryId = 102, ParentCategoryId = 100, Name = "Taxation", Keywords = "" },
    new Category { CategoryId = 201, ParentCategoryId = 200, Name = "Computer", Keywords = "" },
    new Category { CategoryId = 103, ParentCategoryId = 101, Name = "Corporate Tax", Keywords = "" },
    new Category { CategoryId = 202, ParentCategoryId = 201, Name = "Operating System", Keywords = "" },
    new Category { CategoryId = 109, ParentCategoryId = 101, Name = "Small Business Tax", Keywords = "" },
};

Test initTest = new Test(DsCategories);

Console.WriteLine("Examples for Solution 1:");
Console.WriteLine("");

initTest.executeFunction1(201);
initTest.executeFunction1(202);
initTest.executeFunction1(109);

Console.WriteLine("*********************************************************************");
Console.WriteLine("Examples for Solution 2:");
Console.WriteLine("");

initTest.executeFunction2(1);
initTest.executeFunction2(2);
initTest.executeFunction2(3);
initTest.executeFunction2(4);

Console.ReadLine();

public class Test
{
    private List<Category> _categories;

    public Test(List<Category> categories)
    {
        _categories = categories;
    }
    public void executeFunction1(int pValue)
    {
        var DsFunctions = new CategoryFunctions();
        var vResult = DsFunctions.getCategoryProperty(_categories, pValue);
        Console.WriteLine("Input:" + pValue);
        Console.WriteLine("Output:" + vResult);
        Console.WriteLine("---------------------------------------------------------------------");
    }

    public void executeFunction2(int pValue)
    {
        var DsFunctions = new CategoryFunctions();
        var vResult = DsFunctions.getCategoryLevel(_categories, pValue);
        Console.WriteLine("Input:" + pValue);
        Console.WriteLine("Output:" + vResult);
        Console.WriteLine("---------------------------------------------------------------------");


    }
}