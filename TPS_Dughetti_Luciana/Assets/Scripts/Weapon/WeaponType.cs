public class WeaponType 
{
    public static readonly WeaponType Melee = new(1);
    public static readonly WeaponType Pistol = new(2);
    public static readonly WeaponType Rifle = new(3);

    private readonly int animIndex;

    private WeaponType(int animLayer)
    {
        this.animIndex = animLayer;
    }

    public int GetAnimStateIndex()
    {
        return animIndex;
    }
}
