namespace OOP22-arkanoid-csharp.Foschi.Api{

    internal interface ISpeed
    {
        double X {get;}

        double Y {get;}
        
        void sum(ISpeed vel);
    }
}