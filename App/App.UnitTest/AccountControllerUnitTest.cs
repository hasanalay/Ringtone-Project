using App.Controllers;
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
    
    [Test]
    public void TestRegisterAction()
    {
        // Arrange
        var mock = new Mock<IAccountService>();
        var controller = new AccountController(mock.Object);

        // Act
        var result = controller.Register();

        // Assert
        Assert.That(result, Is.TypeOf<ViewResult>());
    }
    
    [Test]
    public void TestLogoutAction()
    {
        // Arrange
        var mock = new Mock<IAccountService>();
        var controller = new AccountController(mock.Object);

        // Act
        var result = controller.Logout();

        // Assert
        Assert.That(result, Is.TypeOf<RedirectToActionResult>());
    }
    
    [Test]
    public void TestLogoutActionRedirectsToLogin()
    {
        // Arrange
        var mock = new Mock<IAccountService>();
        var controller = new AccountController(mock.Object);

        // Act
        var result = controller.Logout() as RedirectToActionResult;

        // Assert
        Assert.That(result.ActionName, Is.EqualTo("Login"));
    }
}

public interface IAccountService
{
}
