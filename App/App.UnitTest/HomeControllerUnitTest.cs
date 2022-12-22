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
}