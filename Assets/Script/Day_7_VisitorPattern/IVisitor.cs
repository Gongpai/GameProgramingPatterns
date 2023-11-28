namespace GDD
{
    public interface IBikeElementVisitor
    {
        void Visit(BikeShield bikeShield);
        void Visit(BikeEngine bikeEngine);
        void Visit(BikeWeapon bikeWeapon);
        void Visit(BikeColor bikeColor);
    }
}