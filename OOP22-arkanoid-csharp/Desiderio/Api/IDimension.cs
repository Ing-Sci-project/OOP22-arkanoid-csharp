namespace OOP22_arkanoid_csharp.Desiderio.Api
{
    public interface IDimension
    {
        double Height { get; set; }
        double Width { get; set; }

        void IncreaseWidth(double value);
    }
}