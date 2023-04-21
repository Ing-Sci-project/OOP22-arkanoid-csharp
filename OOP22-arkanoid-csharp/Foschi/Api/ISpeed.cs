namespace  Foschi.Api{

    public interface ISpeed
    {
        double X {get;}

        double Y {get;}

        void sum(ISpeed vel);
    }
}