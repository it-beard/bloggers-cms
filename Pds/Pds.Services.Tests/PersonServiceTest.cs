using AutoFixture;
using Moq;
using NUnit.Framework;
using Pds.Data;
using Pds.Data.Entities;
using Pds.Data.Repositories.Interfaces;
using Pds.Services.Services;

namespace Pds.Services.Tests;

public class PersonServiceTest
{
    private readonly PersonService service;
    private readonly Mock<IPersonRepository> personRepositoryMock;

    public PersonServiceTest()
    {
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        personRepositoryMock = new Mock<IPersonRepository>();

        unitOfWorkMock.Setup(x => x.Persons)
            .Returns(personRepositoryMock.Object);

        service = new PersonService(unitOfWorkMock.Object);
    }

    [Test]
    public async Task CreateAsync_NewPerson_ShouldCreateNewPerson()
    {
        // arrange
        var fixture = new Fixture();
        var newPerson = new Person();
        var expectedId = fixture.Create<Guid>();

        personRepositoryMock
            .Setup(x => x.InsertAsync(newPerson))
            .ReturnsAsync(new Person
            {
                Id = expectedId
            });

        // act
        var result = await service.CreateAsync(newPerson);

        // assert
        Assert.NotNull(result);
        Assert.AreEqual(expectedId, result);
        personRepositoryMock.Verify(x => x.InsertAsync(newPerson), Times.Once);
    }

    [Test]
    public void CreateAsync_NullPerson_ShouldThrowNullArgumentException()
    {
        // arrange
        // act
        Assert.CatchAsync<ArgumentNullException>(() => service.CreateAsync(null));

        // assert
        personRepositoryMock.Verify(x => x.InsertAsync(It.IsAny<Person>()), Times.Never);
    }
}