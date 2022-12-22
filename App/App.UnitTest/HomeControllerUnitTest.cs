using App.Controllers;

namespace App.UnitTest;

public class HomeControllerUnitTest
{
    [Test]
    public void Index()
    {
        // Arrange
        var controller = new HomeController();

        // Act
        var result = controller.Index();

        // Assert
        Assert.IsNotNull(result);
    }
    
    [Test]
    public void Index_ReturnsViewResult_WithListOfRingtones()
    {
        // Arrange
        var controller = new HomeController();

        // Act
        var result = controller.Index();

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
        var viewResult = result as ViewResult;
        Assert.IsInstanceOf<List<Ringtone>>(viewResult.Model);
    }
    
    [Test]
    public void Index_ReturnsNotFound_ForEmptyDatabase()
    {
        // Arrange
        var controller = new HomeController();

        // Act
        var result = controller.Index();

        // Assert
        Assert.IsInstanceOf<NotFoundResult>(result);
    }

}