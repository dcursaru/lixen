using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Xunit;
using Moq;


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
        }


//        [Fact]
        [Theory]
        [InlineData("MS", true)]
        [InlineData("DB", true)]
        [InlineData("", false)]
        [InlineData("BA", false)]
        public void aaa(string broker, bool expected)
//        public void aaa()
        {
            // Arrange
            var spec = new BrokerSpecification("MS", "DB", "GS");
            var position = new Position(broker, "1");
            
            // Act
            var result = spec.IsSatisfiedBy(position);
            
            // Assert
            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData("MS", true)]
        [InlineData("DB", false)]
        public void bbb(string broker, bool expected)
        {
            // Arrange
            var spec = new BrokerSpecification("MS", "DB", "GS").And(new BrokerSpecification("MS"));
            var position = new Position(broker, "1");
            
            // Act
            var result = spec.IsSatisfiedBy(position);
            
            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ccc()
        {
            var list = new List<IPosition>
            {
                new Position("MS", "1"),
                new Position("DB", "2"),
                new Position("GS", "3"),
                new Position("BA", "4")
            };
            
            var brokerSpec = new BrokerSpecification("MS").Or(new BrokerSpecification("GS"));
            var result = list.Where(a => brokerSpec.IsSatisfiedBy(a)).ToList();
            var result2 = list.Where(brokerSpec.ToExpression().Compile()).ToList();
        }

        [Fact]
        public void ddd()
        {
            var list = new List<PricingScenario>
            {
                new PricingScenario(1, "S1", DateTime.Today, 100.0m),
                new PricingScenario(2, "S2", DateTime.Today, 150.0m),
                new PricingScenario(3, "S3", DateTime.Today, 190.0m),
                new PricingScenario(4, "S4", DateTime.Today, 200.0m),
            };
            var recentScenarioSpec = new MostRecentScenariosSince(DateTime.Today);
            var result = list.Where(a => recentScenarioSpec.IsSatisfiedBy(a));
            var result2 = list.Where(recentScenarioSpec.ToExpression().Compile());
        }

        public class PricingScenario
        {
            public PricingScenario(int id, string name, DateTime asOfDate, decimal premium)
            {
                Id = id;
                Name = name;
                AsOfDate = asOfDate;
                Premium = premium;
            }

            public int Id { get; }
            public string Name { get;}
            public DateTime AsOfDate { get; }
            public decimal Premium { get; }
            
            
        }
        
        public class MostRecentScenariosSince : AbstractSpecification<PricingScenario>
        {
            private readonly DateTime _startDate;
        
            public MostRecentScenariosSince(DateTime startDate)
            {
                _startDate = startDate;
            }
        
            public override Expression<Func<PricingScenario, bool>> ToExpression()
            {
                return p => p.AsOfDate > _startDate;
            }
        }
    }
}