using Moq;
using MovimaxNet.Models;
using MovimaxNet.Repositories;
using MovimaxNet.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MovimaxNet.WebApi.Tests
{
    public class FilmControllerTest
    {
        [Fact]
        public async Task Get_Should_Return_List_Film()
        {
            // Arrange
            var mockRepositoryService = new Mock<IRepositoryService>();
            mockRepositoryService.Setup(service =>
               service.FilmRepository.GetAll())
                .ReturnsAsync(GetFilms());
            var filmController = new FilmController(mockRepositoryService.Object);


            // Act 
            var results = await filmController.Get();

            // Assert
            var actionResult = Assert.IsAssignableFrom<IEnumerable<Film>>(results);
            Assert.Equal(2, actionResult.Count());
        }

        private IEnumerable<Film> GetFilms()
        {
            var films = new List<Film>();
            films.Add(new Film
            {
                Id = 1,
                Title = "Film 1",
                Description = "Film 1 Desc",
                ReleaseDate = new DateTime(2019, 12, 21),
                RuntimeMinute = 0,
                Revenue = "$0",
                PosterUrl = "https://img.imdb.com/image.jpg"
            });
            films.Add(new Film
            {
                Id = 2,
                Title = "Film 2",
                Description = "Film 2 Desc",
                ReleaseDate = new DateTime(2019, 12, 22),
                RuntimeMinute = 0,
                Revenue = "$0",
                PosterUrl = "https://img.imdb.com/image.jpg"
            });
            return films;
        }
    }
}
