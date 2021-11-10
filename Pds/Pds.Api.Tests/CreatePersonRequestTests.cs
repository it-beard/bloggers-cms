using System.ComponentModel.DataAnnotations;
using AutoFixture;
using NUnit.Framework;
using Pds.Api.Contracts.Person;
namespace Pds.Api.Tests;

public class CreatePersonRequestTests
{
    [Test]
    public void Validate_ShouldReturnFalse()
    {
        // arrange
        var request = new CreatePersonRequest();

        var context = new ValidationContext(request, null, null);
        var results = new List<ValidationResult>();

        // act
        var isModelStateValid = Validator.TryValidateObject(request, context, results, true);

        // assert
        Assert.False(isModelStateValid);
    }

    [Test]
    public void Validate_ShouldReturnTrue()
    {
        // arrange
        var fixture = new Fixture();
        var request = new CreatePersonRequest
        {
            FirstName = fixture.Create<string>(),
            LastName = fixture.Create<string>()
        };

        var context = new ValidationContext(request, null, null);
        var results = new List<ValidationResult>();

        // act
        var isModelStateValid = Validator.TryValidateObject(request, context, results, true);

        // assert
        Assert.True(isModelStateValid);
    }
}