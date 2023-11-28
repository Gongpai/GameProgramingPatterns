namespace GDD
{
    public interface IVisitableBikeElement
    {
        void Accept(IBikeElementVisitor visitor);
    }
}