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
    /// <summary>
    /// Function that, given a category id returns an output string of each category property delimited with a comma.
    /// </summary>
    /// <param name="pCategory">Category Id</param>
    public void executeFunction1(int pCategory)
    {
        var DsFunctions = new CategoryFunctions();
        var vResult = DsFunctions.getCategoryProperty(_categories, pCategory);
        Console.WriteLine("Input:" + pCategory);
        Console.WriteLine("Output:" + vResult);
        Console.WriteLine("---------------------------------------------------------------------");
    }

    /// <summary>
    /// Function that, given category level as parameter (say N), returns the category ids of the
    /// categories which are of N’th level in the hierarchy.
    /// Categories with parentId -1 are at 1st level
    /// </summary>
    /// <param name="pLevel">Level Number</param>
    public void executeFunction2(int pLevel)
    {
        var DsFunctions = new CategoryFunctions();
        var vResult = DsFunctions.getCategoryLevel(_categories, pLevel);
        Console.WriteLine("Input:" + pLevel);
        Console.WriteLine("Output:" + vResult);
        Console.WriteLine("---------------------------------------------------------------------");


    }
}