namespace Foschi.Api
{
    public interface ILeaderBoard
    {
        void UpdatePoints(string name, string password, int points, int levelId);

        List<Tuple<string,int>> GetBestFive();

        int? GetPoints(string name, string password);
    }
}