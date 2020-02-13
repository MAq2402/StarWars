using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using StarWars.Application.Services;
using StarWars.Data.Repositories;
using Xunit;

namespace StarWars.Application.Tests
{
    public class CharacterServiceTests
    {
        [Theory]
        [InlineData(true, true)]
        [InlineData(false, false)]
        public async void CheckIfCharacterExistsAsync_ShouldWork(bool valueReturnedByRepository, bool expected)
        {
            var mockedCharacterRepository = new Mock<ICharacterRepository>();
            mockedCharacterRepository.Setup(r => r.CheckIfCharacterExistsAsync(new Guid()))
                .Returns(Task.FromResult(valueReturnedByRepository));
            var mockedMapper = new Mock<IMapper>();
            var characterService = new CharacterService(mockedCharacterRepository.Object, mockedMapper.Object);

            var actual = await characterService.CheckIfCharacterExistsAsync(new Guid());

            Assert.Equal(actual, expected);
        }
    }
}