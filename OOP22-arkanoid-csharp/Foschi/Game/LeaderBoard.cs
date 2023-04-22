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
            throw new NotImplementedException();
        }

        private void Writeonfile(List<User> list) 
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
        class User {
            public string _name {get;}
            public string _password {get;}

            public IDictionary<string,int> _points;

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