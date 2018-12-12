using Xunit;

namespace Lixen.Core.Tests
{
    public class BuilderTests
    {
        [Fact]
        public void BuilderCreatesAppropriateScenario()
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