using Foschi.Api;
using Newtonsoft.Json;

namespace Foschi.Game 
{
    public class LeaderBoard : ILeaderBoard
    {
        private string _path;
        private readonly int MAX=5;

        public LeaderBoard() {
            _path=Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),"aRkAnOiD_csharp.txt");
            var f = new FileInfo(_path);
            if (!File.Exists(_path) || f.Length == 0) {
                FileStream str = File.Create(_path);
                str.Close();
                WriteOnFile(LoadFromResources());
            }
        }
        public List<Tuple<string, int>> GetBestFive()
        {
            List<User> list = PlayersFromFile();
            if(list.Count() > MAX) {
                list = list.GetRange(0,MAX);
            }
            return list.Select(x=>new Tuple<string,int>(x._name,x.GetSumPoints())).ToList();
        }

        public int? GetPoints(string name, string password)
        {
            User? usr = PlayersFromFile().Find(x=>x._name.Equals(name) && x._password.Equals(password));
            return usr == null ? null : usr.GetSumPoints();
        }

        public void UpdatePoints(string name, string password, int points, int levelId)
        {
            List<User> list = PlayersFromFile();
            User? check = CheckUser(name,password,list);
            if(check != null) {
                check.Update(points,levelId);
            } else {
                User usr = new User(name,password);
                usr.Update(points,levelId);
                list.Add(usr);
            }
            list.Sort((x,y)=>y.GetSumPoints().CompareTo(x.GetSumPoints()));
            WriteOnFile(list);
        }

        private User? CheckUser(string usr, string password, List<User> list) => list.Find(x=>x._name.Equals(usr) && x._password.Equals(password));

        private void WriteOnFile(List<User> list) 
        {
            File.WriteAllText(_path, JsonConvert.SerializeObject(list));
        }

        private List<User> PlayersFromFile() {
            List<User>? list = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(_path));
            return list==null? new List<User>() : list;
        }

        private List<User> LoadFromResources() 
        {
            List<User>? list = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText("Resources/File.txt"));
            return list==null? new List<User>() : list;
        }

        [Serializable]
        public class User {
            public string _name {get; set;}
            public string _password {get; set;}

            public Dictionary<string,int> _points;

            public User(string name, string password)
            {
                _name=name;
                _password=password;
                _points=new Dictionary<string,int>();
            }

            public int GetSumPoints() => _points.Sum(x=>x.Value);

            public void Update(int points, int levelId)
            {
                _points[levelId.ToString()]=points;
            }

            public override string ToString() => _name+" "+GetSumPoints();
        }
    }
}