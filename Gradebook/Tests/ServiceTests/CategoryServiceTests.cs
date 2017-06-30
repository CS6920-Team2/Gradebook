using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradebook.Data.DAO;
using Gradebook.Data.Services;

namespace Gradebook.Tests.ServiceTests
{
    [TestClass]
    public class CategoryServiceTests
    {
        private CategoryService categoryService;
        private List<Category> originalCategories;

        [TestInitialize]
        public void TestSetUp()
        {
            categoryService = new CategoryService();

            // Original categories should never change.
            originalCategories = categoryService.findCategoriesByTaughtCourseID(1);
        }


        [TestMethod]
        public void findCategoriesByTaughtCourseIDSuccess()
        {
            List<Category> categories = categoryService.findCategoriesByTaughtCourseID(1);
            Assert.IsNotNull(categories);
            Assert.AreEqual(5, categories.Count);
        }


        [TestMethod]
        public void findCategoriesByTaughtCourseIDReturnZeroCategories()
        {
            List<Category> categories = categoryService.findCategoriesByTaughtCourseID(-1);
            Assert.IsNotNull(categories);
            Assert.AreEqual(0, categories.Count);
        }

        [TestMethod]
        public void updateAllCategoriesForTaughtCourseCommits()
        {
            List<Category> categories = categoryService.findCategoriesByTaughtCourseID(1);

            foreach (Category category in categories)
            {
                category.weight = 10;
            }

            bool success = categoryService.updateAllCategoriesForTaughtCourse(categories);
            Assert.IsTrue(success);

            // Make sure categories are updated in the DB to match values recently given 
            List<Category> updatedCategories = categoryService.findCategoriesByTaughtCourseID(1);
            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(updatedCategories[i].categoryID, categories[i].categoryID);
                Assert.AreEqual(updatedCategories[i].weight, categories[i].weight);
                Assert.AreEqual(updatedCategories[i].name, categories[i].name);
            }
        }

        [TestMethod]
        public void updateAllCategoriesForTaughtCourseRollsBack()
        {
            List<Category> categories = categoryService.findCategoriesByTaughtCourseID(1);

            // Remove one category, preventing full update of all categories from being possible
            categories.Remove(categories[4]);

            foreach (Category category in categories)
            {
                category.weight = 10;
            }

            bool success = categoryService.updateAllCategoriesForTaughtCourse(categories);
            Assert.IsFalse(success);

            // Make sure that DB hasn't changed and alterations have rolled back.
            List<Category> notUpdatedCategories = categoryService.findCategoriesByTaughtCourseID(1);
            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(notUpdatedCategories[i].categoryID, originalCategories[i].categoryID);
                Assert.AreEqual(notUpdatedCategories[i].weight, originalCategories[i].weight);
                Assert.AreEqual(notUpdatedCategories[i].name, originalCategories[i].name);
            }
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            categoryService.updateAllCategoriesForTaughtCourse(originalCategories);
        }
    }
}
