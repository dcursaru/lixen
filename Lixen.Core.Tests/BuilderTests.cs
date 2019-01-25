using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Lixen.Core.Tests
{
    public class BuilderTests
    {
        [Fact]
        public void BuilderCannotCreateScenarioWithoutIdentity()
        {
            // Arrange
            var builder = ScenarioBuilder.Create<LiquidationScenario>();
            
            // Act
            //var scenario = builder.Build();
            
            // Assert
            Assert.Throws<NullReferenceException>(() => builder.Build());
            //Assert.IsType<IScenario<IPosition>>(scenario);

        }

        [Fact]
        public void BuilderCreatesScenario()
        {
            // Arrange
            var builder = ScenarioBuilder.Create<LiquidationScenario>()
                .WithId(1)
                .WithSpecification(new BrokerSpecification(new[] {"DB", "MS"}));
                

            // Act
            var scenario = builder.Build();

            // Assert
            //Assert.IsType<IScenario<IPosition>>(scenario);

        }

        public void RunScenario()
        {
            var scenario = this.CreateDefaultScenario();
            //scenario.Ru

        }

        private IScenario<IPosition> CreateDefaultScenario()
        {
            var builder = ScenarioBuilder.Create<LiquidationScenario>()
                .WithId(1)
                .WithSpecification(new BrokerSpecification(new[] { "DB", "MS" }));


            return builder.Build();

        }

        public class Portfolio
        {
            private readonly IList<IPosition> _positions;
            private double _margin;

            public Portfolio(IList<IPosition> positions)
            {
                _positions = positions;
            }

            public void CalculateMarginData()
            {
                _margin = 0.1d;
            }

            public void CalculateMarginData2()
            {
                
            }
        }
    }
}