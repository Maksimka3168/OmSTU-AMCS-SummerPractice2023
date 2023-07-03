namespace spacebattle;
public class Spaceship
{
    private double[]? position;
    private double[]? boostspeed;
    private bool canChange = true;

    public Spaceship(){}

    public double[]? getPosition(){
        return this.position;
    }

    public void setPosition(double x, double y){
        this.position = new double[] {x, y};
    }

    public void setBoostSpeed(double boostX, double boostY){
        this.boostspeed = new double[] {boostX, boostY};
    }

    public void setChange(bool valueChange){
        this.canChange = valueChange;
    }

    public void Move(){
        if (this.canChange){
            if (position == null || boostspeed == null){
                throw new Exception();
            }
            else {
                this.position[0] += this.boostspeed[0];
                this.position[1] += this.boostspeed[1];
            }
        } else {
            throw new Exception();
        }
        
    }
}
