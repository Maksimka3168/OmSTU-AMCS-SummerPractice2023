namespace spacebattle;
public class Spaceship
{
    private double[] position = new double[] { 0, 0 };
    private double[] boostspeed = new double[] {1, 1};
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

    public void respawnSpaceShip(){
        this.position = new double[] { 0, 0 };
        this.boostspeed = new double[] {1, 1};
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
