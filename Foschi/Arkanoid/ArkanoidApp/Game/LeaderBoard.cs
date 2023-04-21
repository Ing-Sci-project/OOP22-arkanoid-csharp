using ArkanoidApp.Api;

namespace ArkanoidApp.Game{
    public class LeaderBoard : ILeaderBoard
    {
        private string _path;
        private static readonly int MAX=5;

        public LeaderBoard(){
            _path=Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),"ArKaNoId.txt");
            var info = new FileInfo(_path);
            if(!File.Exists(_path) || info.Length==0) {
                FileStream str = File.Create(_path);
                str.Close();
                this.writeOnFile(this.loadFromResources());
            }
        }
        public List<Tuple<string, int>> getBestFive()
        {
            throw new NotImplementedException();
        }

        public int? getPoints(string name, string password)
        {
            throw new NotImplementedException();
        }

        public void UpdatePoints(string name, string password, int points, int levelId)
        {
            throw new NotImplementedException();
        }

        private User? checkUser(string name, string password, List<User> list){
            
        }

        private void writeOnFile(List<User> list){

        }

        private List<User> loadFromResources(){

        }

        private List<User> playersFromFile(){

        }

        [Serializable]
        public class User{

        }
    }
}