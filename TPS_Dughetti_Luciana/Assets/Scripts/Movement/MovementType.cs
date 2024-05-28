public class MovementType
{
    public static readonly MovementType Walk = new(1.0f);
    public static readonly MovementType Run = new(2.0f);

    private float speed;

    private MovementType(float speed)
    {
        this.speed = speed;
    }

    public float GetMovementSpeed()
    {
        return speed;
    }
}