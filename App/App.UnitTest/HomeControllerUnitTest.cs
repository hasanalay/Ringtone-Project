using App.Controllers;
using App.Models;
using Microsoft.AspNetCore.Mvc;

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
    
    [Test]
    public void Index_ReturnsViewResult_WithListOfRingtones_WithCorrectData()
    {
        // Arrange
        var controller = new HomeController();

        // Act
        var result = controller.Index();

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
        var viewResult = result as ViewResult;
        Assert.IsInstanceOf<List<Ringtone>>(viewResult.Model);
        var model = viewResult.Model as List<Ringtone>;
        Assert.AreEqual(2, model.Count);
        Assert.AreEqual("Ringtone 1", model[0].Name);
        Assert.AreEqual("Ringtone 2", model[1].Name);
    }
    
    [Test] 
    public void Details_ReturnsNotFound_ForInvalidId()
    {
        // Arrange
        var controller = new HomeController();

        // Act
        var result = controller.Details(0);

        // Assert
        Assert.IsInstanceOf<NotFoundResult>(result);
    }
    
    [Test] 
    public void Details_ReturnsViewResult_WithRingtone()
    {
        // Arrange
        var controller = new HomeController();

        // Act
        var result = controller.Details(1);

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
        var viewResult = result as ViewResult;
        Assert.IsInstanceOf<Ringtone>(viewResult.Model);
    }
    
    [Test]
    public void Contact()
    {
        // Arrange
        var controller = new HomeController();

        // Act
        var result = controller.Contact();

        // Assert
        Assert.IsNotNull(result);
    }
    
    [Test]
    public void Contact_ReturnsViewResult()
    {
        // Arrange
        var controller = new HomeController();

        // Act
        var result = controller.Contact();

        // Assert
        Assert.IsInstanceOf<ViewResult>(result);
    }

}