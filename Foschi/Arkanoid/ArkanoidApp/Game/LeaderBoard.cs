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
                this.WriteOnFile(this.LoadFromResources());
            }
        }

        public List<Tuple<string, int>> GetBestFive()
        {
            List<User> list = PlayersFromFile();
            if(list.Count() > MAX) {
                list = list.GetRange(0,MAX);
            }
            return list.Select(x=> new Tuple<string,int>(x._name,x.getPoints())).ToList();
        }

        public int? GetPoints(string name, string password)
        {
            User? usr = PlayersFromFile().Find(x=>x._name.Equals(name) && x._password.Equals(password));
            return usr==null ? null : usr.getPoints();
        }

        public void UpdatePoints(string name, string password, int points, int levelId)
        {
            List<User> list = PlayersFromFile();
            User? check = CheckUser(name,password);
            if(check!=null){
                check.update(points,levelId);
            } else {
                User usr = new User(name, password);
                usr.update(points,levelId);
                list.Add(usr);
            }
            list.Sort((x,y)=>y.getPoints().CompareTo(x.getPoints()));
            WriteOnFile(list);
        }

        private User? CheckUser(string name, string password, List<User> list){
            return list.Find(x=>x._name.Equals(name) && x._password.Equals(password));
        }

        private void WriteOnFile(List<User> list){

        }

        private List<User> LoadFromResources(){

        }

        private List<User> PlayersFromFile(){

        }

        [Serializable]
        public class User{
            public string _name {get;}
            public string _password {get;}
            public Dictionary<string,int> _points;

            public User(string name, string password){
                _name=name;
                _password=password;
                _points=new Dictionary<string,int>();
            }

            public int getPoints()
            {
                return _points.Sum(x=>x.Value);
            }

            public void update(int points, int levelId)
            {
                _points[levelId.ToString()]=points;
            }

            public override string ToString()
            {
                return _name+" "+getPoints();
            }
        }
    }
}