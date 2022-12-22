using App.Controllers;
using App.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace App.UnitTest;

public class AccountControllerTest
{
    
    [Test]
    public void TestLoginAction()
    {
        // Arrange
        var mock = new Mock<IAccountService>();
        var controller = new AccountController(mock.Object);

        // Act
        var result = controller.Login();

        // Assert
        Assert.That(result, Is.TypeOf<ViewResult>());
    }
    
    
}

public interface IAccountService
{
}
