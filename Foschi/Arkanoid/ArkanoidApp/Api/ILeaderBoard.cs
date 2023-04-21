namespace ArkanoidApp.Api{
    internal interface ILeaderBoard {

        void UpdatePoints(string name, string password, int points, int levelId);

        List<Tuple<string,int>> getBestFive();

        int? getPoints(string name, string password);
    }
}