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

        /// <summary>
        /// Get the string with all properties of the specified category
        /// </summary>
        /// <param name="pCategories">List of categories</param>
        /// <param name="pCategoryId">Category Id to filter</param>
        /// <returns>string with all properties of the category</returns>
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

        /// <summary>
        /// Get the keyword of the first category parent.
        /// </summary>
        /// <param name="pCategories">List of Categories</param>
        /// <param name="pCategoryId">Category Id</param>
        /// <returns>Keyword value</returns>
        private string getParentKeyword(List<Category> pCategories, int pCategoryId)
        {
            Category? vCurrenCategory = pCategories.FirstOrDefault(c => c.CategoryId == pCategoryId);

            if (vCurrenCategory == null)
                return "No Keyword";

            if (!vCurrenCategory.Keywords.Equals(""))
                return vCurrenCategory.Keywords;

            return getParentKeyword(pCategories, vCurrenCategory.ParentCategoryId);
        }

        /// <summary>
        /// Category ids of the categories which are of N’th level in the hierarchy
        /// </summary>
        /// <param name="pCategories">List of Categories</param>
        /// <param name="pLevel">Level Number</param>
        /// <returns>String with all Category ids that are related of the level</returns>
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

        /// <summary>
        /// Function that filters the categories by level and Category Id
        /// </summary>
        /// <param name="pCategories">List of Categories</param>
        /// <param name="pData">Category Id</param>
        /// <param name="plevel">Level Number</param>
        /// <returns>List of Categories related to the Category Id and Level Number</returns>
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
