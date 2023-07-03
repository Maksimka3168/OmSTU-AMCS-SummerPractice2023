using TechTalk.SpecFlow;
using FluentAssertions;
using spacebattle;

namespace XUnit.Tests
{
    [Binding]
    public sealed class UnitTest1
    {
        private readonly ScenarioContext _context;
        private Spaceship spaceship = new Spaceship();
        private Exception? exception;

        public UnitTest1(ScenarioContext context)
        {
            _context = context;
        }


        [Given(@"космический корабль находится в точке пространства с координатами \((.*), (.*)\)")]
        public void SpacecraftSetLocation(double x, double y)
        {
            spaceship.setPosition(x, y);
        }


        [Given(@"имеет мгновенную скорость \((.*), (.*)\)")]
        public void SpacecraftSetSpeed(double boostX, double boostY)
        {
            spaceship.setBoostSpeed(boostX, boostY);
        }


        [Given(@"космический корабль, положение в пространстве которого невозможно определить")]
        public void SpacecraftSetLocationNull()
        {}


        [Given(@"скорость корабля определить невозможно")]
        public void SpacecraftSetSpeedNull()
        {}


        [Given(@"изменить положение в пространстве космического корабля невозможно")]
        public void SpacecraftSetChangeFalse()
        {
            spaceship.setChange(false);
        }


        [When(@"происходит прямолинейное равномерное движение без деформации")]
        public void SpacecraftMove()
        {
            try{
                spaceship.Move();
            } catch(Exception e) {
                this.exception = e;
            }
        }

        [Then(@"космический корабль перемещается в точку пространства с координатами \((.*), (.*)\)")]
        public void SpacecraftMovedCoord(double correctX, double correctY)
        {
            double[] correctPosition = {correctX, correctY};
            spaceship.getPosition().Should().BeEquivalentTo(correctPosition);
        }

        [Then(@"возникает ошибка Exception")]
        public void ErrorException ()
        {
            this.exception.Should().NotBeNull();
        }
    }
}
