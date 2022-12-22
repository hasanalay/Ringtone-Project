using App.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace App.UnitTest;

public class RingtoneControllerUnitTest
{
    [Test]
    public void Index_ReturnsViewResult()
    {
        // Arrange
        var controller = new RingtoneController();

        // Act
        var result = controller.Index();

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
    }
    
    [Test]
    public void Create_ReturnsViewResult()
    {
        // Arrange
        var mockService = new Mock<IRingtoneService>();
        var controller = new RingtoneController(mockService.Object);

        // Act
        var result = controller.Create();

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
    }
}

public interface IRingtoneService
{
}