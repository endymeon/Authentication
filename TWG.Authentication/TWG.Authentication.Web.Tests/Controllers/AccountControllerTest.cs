using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TWG.Authentication.Web;
using TWG.Authentication.Web.Controllers;

namespace TWG.Authentication.Web.Tests.Controllers
{
    [TestClass]
    public class AccountControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            AccountController controller = new AccountController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
