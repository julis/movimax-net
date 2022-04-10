using Microsoft.AspNetCore.Mvc;
using Moq;
using MovimaxNet.Models;
using MovimaxNet.Repositories;
using MovimaxNet.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MovimaxNet.WebApi.Tests
{
    public class FilmControllerTest
    {
        [Fact]
        public async Task Get_Should_ReturnListFilm()
        {
            // Arrange
            var mockRepositoryService = new Mock<IRepositoryService>();
            mockRepositoryService.Setup(service =>
               service.FilmRepository.GetAll())
                .ReturnsAsync(GetFilms());
            var filmController = new FilmController(mockRepositoryService.Object);


            // Act 
            var result = await filmController.Get();

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<Film>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);

            var listResult = Assert.IsAssignableFrom<IEnumerable<Film>>(okResult.Value);
            Assert.Equal(2, listResult.Count());
        }

        [Fact]
        public async Task GetById_Should_ReturnSingleFilm()
        {
            // Arrange
            int filmId = 1;
            var mockRepositoryService = new Mock<IRepositoryService>();
            mockRepositoryService.Setup(service => service.FilmRepository.Get(filmId))
                .ReturnsAsync(GetFilm());
            var filmController = new FilmController(mockRepositoryService.Object);

            // Act 
            var result = await filmController.Get(filmId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);            
            var resultValue = Assert.IsType<Film>(okResult.Value);
            Assert.Equal(filmId, resultValue.Id);
        }

        [Fact]
        public async Task Create_ReturnsNewlyCreatedFilm()
        {
            // Arrange
            var newFilm = GetFilm();
            var mockRepositoryService = new Mock<IRepositoryService>();
            mockRepositoryService.Setup( service => service.FilmRepository.Add(newFilm))
                .ReturnsAsync(true);             
            var filmController = new FilmController(mockRepositoryService.Object);

            // Act 
            var result = await filmController.Create(newFilm);

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnFilm = Assert.IsType<Film>(createdResult.Value);

            Assert.Equal(newFilm.Id, returnFilm.Id);
            Assert.Equal(newFilm.Title, returnFilm.Title);
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

        private Film GetFilm()
        {
            return new Film
            {
                Id = 1,
                Title = "Film 1",
                Description = "Film 1 Desc",
                ReleaseDate = new DateTime(2019, 12, 21),
                RuntimeMinute = 0,
                Revenue = "$0",
                PosterUrl = "https://img.imdb.com/image.jpg"
            };
        }
    }
}
