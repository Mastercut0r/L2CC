using L2CC.AppLogic.AppLogic;
using L2CC.AppLogic.ServiceLocator;
using Moq;
using System;
using Xunit;

namespace L2CC.AppLogic.Test
{
    public class LambdaPoweredServiceLocatorTest
    {
        [Theory]
        [InlineData(GameType.Classic, typeof(ExpCalculatorClassic))]
        [InlineData(GameType.Essence, typeof(ExpCalculatorEssence))]
        public void LoadServiceTest_ExpCalculator(GameType gameType, Type expectedType)
        {
            //Arrange
            var cacheMock = new Mock<IServiceLocatorCache>();
            cacheMock.Setup(x => x.LookUpInCache(It.IsAny<GameType>(), It.IsAny<Type>())).Returns<IAppService>(null);
            //Act
            var testObject = new LambdaPoweredServiceLocator(null, cacheMock.Object);
            var service = testObject.LoadService<IExpCalculator>(gameType);
            //Assert
            Assert.NotNull(service);
            Assert.IsType(expectedType, service);
            Assert.IsAssignableFrom<IExpCalculator>(service);
        }
    }
}
