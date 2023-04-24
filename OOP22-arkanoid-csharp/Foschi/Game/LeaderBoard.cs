using Foschi.Api;
using Newtonsoft.Json;

namespace Foschi.Game 
{
    /// <summary>
    /// Class that manages ranking of the game.
    /// </summary>
    public class LeaderBoard : ILeaderBoard
    {
        private readonly string _path;
        private const int Max=5;

        /// <summary>
        /// costructor of this class.
        /// </summary>
        public LeaderBoard() {
            _path=Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),"aRkAnOiD_csharp.txt");
            var f = new FileInfo(_path);
            if (!File.Exists(_path) || f.Length == 0) {
                FileStream str = File.Create(_path);
                str.Close();
                WriteOnFile(LoadFromResources());
            }
        }

        /// <inheritdoc />
        public List<Tuple<string, int>> GetBestFive()
        {
            List<User> list = PlayersFromFile();
            if(list.Count() > Max) {
                list = list.GetRange(0,Max);
            }
            return list.Select(x=>new Tuple<string,int>(x._name,x.GetSumPoints())).ToList();
        }

        /// <inheritdoc />
        public int? GetPoints(string name, string password)
        {
            User? usr = PlayersFromFile().Find(x=>x._name.Equals(name) && x._password.Equals(password));
            return usr == null ? null : usr.GetSumPoints();
        }

        /// <inheritdoc />
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

        /// <summary>
        /// method to check if a player exists.
        /// </summary>
        /// <param name="usr"> name of the player</param>
        /// <param name="password"> password of the player</param>
        /// <param name="list"> list of players</param>
        /// <returns>null if not exists</returns>
        private User? CheckUser(string usr, string password, List<User> list) => list.Find(x=>x._name.Equals(usr) && x._password.Equals(password));

        /// <summary>
        /// method to write leaderboard on file.
        /// </summary>
        /// <param name="list"> list of players</param>
        private void WriteOnFile(List<User> list) => File.WriteAllText(_path, JsonConvert.SerializeObject(list));

        /// <summary>
        /// method to get list of players from file.
        /// </summary>
        /// <returns>list of players</returns>
        private List<User> PlayersFromFile() => checkIfNull(JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(_path)));

        /// <summary>
        /// method to get list of players from resources file.
        /// </summary>
        /// <returns>list of players</returns>
        private List<User> LoadFromResources() => checkIfNull(JsonConvert.DeserializeObject<List<User>>(File.ReadAllText("Resources/File.txt")));

        /// <summary>
        /// method to check if a list is null or not.
        /// </summary>
        /// <returns>the list if it is not null or an empty list</returns>
        private List<User> checkIfNull(List<User>? list) => list==null? new List<User>() : list;

        /// <summary>
        /// Class that manages informations of each palyer.
        /// </summary>
        [Serializable]
        public class User {
            public string _name {get; set;}
            public string _password {get; set;}

            public Dictionary<string,int> _points;

            /// <summary>
            /// Constructor of this class.
            /// </summary>
            /// <param name="name"> name of the player</param>
            /// <param name="password"> password of the player</param>
            public User(string name, string password)
            {
                _name=name;
                _password=password;
                _points=new Dictionary<string,int>();
            }

            /// <summary>
            /// method to get player's points.
            /// </summary>
            /// <returns>player's points</returns>
            public int GetSumPoints() => _points.Sum(x=>x.Value);

            /// <summary>
            /// method to update player's points.
            /// </summary>
            /// <param name="points"> points totalize by the player</param>
            /// <param name="levelId"> level done</param>
            public void Update(int points, int levelId) => _points[levelId.ToString()]=points;

            /// <inheritdoc />
            public override string ToString() => _name+" "+GetSumPoints();
        }
    }
}