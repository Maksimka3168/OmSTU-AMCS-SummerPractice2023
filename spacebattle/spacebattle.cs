namespace spacebattle;
public class Spaceship
{
    private double[]? position;
    private double[]? boostspeed;
    private bool canChange = true;
    private bool canChangeAngle = true;
    private int fuel = 0;
    private int fuelUse = 0;
    private int? angleSlope;
    private int? angleSpeed;

    public Spaceship(){}

    public double[]? getPosition(){
        return this.position;
    }

    public int? getAngleSlope(){
        return this.angleSlope;
    }

    public int? getFuel(){
        return this.fuel;
    }

    public void setAngleSlope(int angleSlope){
        this.angleSlope = angleSlope;
    }

    public void setChangeAngle(bool valueChange){
        this.canChangeAngle = valueChange;
    }

    public void setAngleSpeed(int angleSpeed){
        this.angleSpeed = angleSpeed;
    }

    public void setPosition(double x, double y){
        this.position = new double[] {x, y};
    }

    public void setFuel(int fuel){
        this.fuel = fuel;
    }

    public void setFuelUse(int fuelUse){
        this.fuelUse = fuelUse;
    }

    public void setBoostSpeed(double boostX, double boostY){
        this.boostspeed = new double[] {boostX, boostY};
    }

    public void setChange(bool valueChange){
        this.canChange = valueChange;
    }

    public void Rotate(){
        if (this.canChangeAngle){
            if (this.angleSlope == null || this.angleSpeed == null){
                throw new Exception();
            } else {
                this.angleSlope += this.angleSpeed;
            }
        }else{
            throw new Exception();
        }
    }

    public void Move(){
        if (this.canChange && this.fuel - this.fuelUse >= 0){
            if (this.position == null || this.boostspeed == null){
                throw new Exception();
            }
            else {
                this.position[0] += this.boostspeed[0];
                this.position[1] += this.boostspeed[1];
                this.fuel -= this.fuelUse;
            }
        } else {
            throw new Exception();
        }
        
    }
}
