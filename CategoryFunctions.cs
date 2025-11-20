using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEdwinZR
{
    public class CategoryFunctions
    {
        private string delimiter = ",";
        public string getCategoryProperty(List<Category> pCategories, int pCategoryId)
        {
            if (pCategories == null || !pCategories.Any())
                return "There is no a Category Dataset";

            Category? pResult = pCategories.FirstOrDefault(p => p.CategoryId == pCategoryId);

            if (pResult == null)
                return "Category not found";

            if(pResult.Keywords.Equals(""))
                pResult.Keywords = getParentKeyword(pCategories, pResult.ParentCategoryId);

           
            return $"ParentCategoryID = { pResult.ParentCategoryId + delimiter } Name = { pResult.Name + delimiter} Keywords = { pResult.Keywords}";
        }

        private string getParentKeyword(List<Category> pCategories, int pCategoryId)
        {
            Category? vCurrenCategory = pCategories.FirstOrDefault(c => c.CategoryId == pCategoryId);

            if (vCurrenCategory == null)
                return "No Keyword";

            if (!vCurrenCategory.Keywords.Equals(""))
                return vCurrenCategory.Keywords;

            return getParentKeyword(pCategories, vCurrenCategory.ParentCategoryId);
        }

        public string getCategoryLevel(List<Category> pCategories, int pLevel)
        {
            int[] vResult= new  int[0];
            List<int> allResults = new List<int>();

            if (pLevel == 1)
                vResult = pCategories.Where(c => c.ParentCategoryId == -1)
                                    .Select(c => c.CategoryId)
                                    .ToArray();
            else
            {
                foreach (Category category in pCategories.Where(c => c.ParentCategoryId == -1))
                {
                    int[] vresult = level(pCategories, category, (pLevel - 1));
                    if (vresult != null)
                        allResults.AddRange(vresult);
                }
                    
                vResult = allResults.ToArray();
            }
            return $"[{(vResult.Length == 0 ? "Invalid level" : string.Join(",", vResult))}]";   
        }

        private int[] level(List<Category> pCategories, Category pData, int plevel)
        {
            List<int> allResults = new List<int>();
            int[] vResult = new int[0];

            if (plevel == 1)
            {
                return pCategories.Where(c => c.ParentCategoryId == pData.CategoryId)
                                    .Select(c => c.CategoryId)
                                    .ToArray();
            }
            else
            {
                List<Category> lCategory = pCategories.Where(c => c.ParentCategoryId == pData.CategoryId).ToList();

                foreach (Category category in lCategory)
                    allResults.AddRange(level(pCategories.Where(c => c.ParentCategoryId != pData.CategoryId).ToList(), category, (plevel - 1)));
                vResult = allResults.ToArray();
            }
            return vResult;
        }
    }
}
