using System;
using Xunit;

namespace Lixen.Core.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var builder = ScenarioBuilder.Create<LiquidationScenario>();
            
            // Act
            var scenario = builder.Build();
            
            // Assert
            Assert.IsType<IScenario<LiquidationScenario>>(scenario);

        }
    }
}