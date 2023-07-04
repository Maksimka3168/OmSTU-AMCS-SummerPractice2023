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
        public void SpacecraftSetLocationNull(){}


        [Given(@"скорость корабля определить невозможно")]
        public void SpacecraftSetSpeedNull(){}


        [Given(@"изменить положение в пространстве космического корабля невозможно")]
        public void SpacecraftSetChangeFalse()
        {
            spaceship.setChange(false);
        }

        [Given(@"космический корабль имеет топливо в объеме (.*) ед")]
        public void SetFuel(int fuel){
            this.spaceship.setFuel(fuel);
            this.spaceship.setPosition(0, 0);
            this.spaceship.setBoostSpeed(0, 0);
        }

        [Given(@"имеет скорость расхода топлива при движении (.*) ед")]
        public void SetFuelUse(int fuelUse){
            this.spaceship.setFuelUse(fuelUse);
        }

        [Given(@"космический корабль имеет угол наклона (.*) град к оси OX")]
        public void SetAngleSlope(int angle){
            this.spaceship.setAngleSlope(angle);
        }

        [Given(@"имеет мгновенную угловую скорость (.*) град")]
        public void SetAngleSpeed(int angleSpeed){
            this.spaceship.setAngleSpeed(angleSpeed);
        }

        [Given("космический корабль, угол наклона которого невозможно определить")]
        public void SetAngleSlopeNull(){}

        [Given("мгновенную угловую скорость невозможно определить")]
        public void SetAngleSpeedNull(){}

        [Given("невозможно изменить уголд наклона к оси OX космического корабля")]
        public void SetChangeAngleFalse(){
            this.spaceship.setChangeAngle(false);
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

        [When("происходит вращение вокруг собственной оси")]
        public void SpacecraftRotate()
        {
            try{
                spaceship.Rotate();
            } catch(Exception e) {
                this.exception = e;
            }
        }

        [Then(@"новый объем топлива космического корабля равен (.*) ед")]
        public void SpacecraftFuelResult(int fuelCorrect){
            this.spaceship.getFuel().Should().Be(fuelCorrect);
        }

        [Then(@"угол наклона космического корабля к оси OX составляет (.*) град")]
        public void SpacecraftRotatedAngle(int angleCorrect){
            this.spaceship.getAngleSlope().Should().Be(angleCorrect);
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
