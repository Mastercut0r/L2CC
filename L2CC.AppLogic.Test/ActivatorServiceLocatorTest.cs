using L2CC.AppLogic.AppLogic;
using L2CC.AppLogic.ServiceLocator;
using Moq;
using System;
using Xunit;

namespace L2CC.AppLogic.Test
{
    public class ActivatorServiceLocatorTest
    {
        [Theory]
        [InlineData(GameType.Classic, typeof(ExpCalculatorClassic))]
        [InlineData(GameType.Essence, typeof(ExpCalculatorEssence))]
        public void LoadServicesTest_ExpCalculator_EmptyCache(GameType gameType, Type expectedType)
        {
            //Arrange
            var cacheMock = new Mock<IServiceLocatorCache>();
            var serviceMock = new Mock<IAppService>().Object;
            cacheMock.Setup(x => x.LookUpInCache(It.IsAny<GameType>(), It.IsAny<Type>())).Returns<IAppService>(null);
            //Act
            var testObject = new ActivatorServiceLocator(cacheMock.Object);
            var service = testObject.LoadService<IExpCalculator>(gameType);
            //Assert
            Assert.NotNull(service);
            Assert.IsType(expectedType, service);
            Assert.IsAssignableFrom<IExpCalculator>(service);
        }
        [Theory]
        [InlineData(GameType.Classic)]
        [InlineData(GameType.Essence)]
        public void LoadServicesTest_ExpCalculator_FromCache(GameType gameType)
        {
            //Arrange
            var cacheMock = new Mock<IServiceLocatorCache>();
            var serviceMock = new Mock<IAppService>().As<IExpCalculator>().Object;
            cacheMock.Setup(x => x.LookUpInCache(It.IsAny<GameType>(), It.IsAny<Type>())).Returns(serviceMock);
            //Act
            var testObject = new ActivatorServiceLocator(cacheMock.Object);
            var service = testObject.LoadService<IExpCalculator>(gameType);
            //Assert
            Assert.NotNull(service);
            Assert.IsAssignableFrom<IExpCalculator>(service);
        }

    }
}
