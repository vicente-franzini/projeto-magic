namespace Magic {

    class Estoque : IModel {

        private string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Estoque.db");

        public Estoque(string _path) {
            path = _path;

            if(!File.Exists(path)) File.Create(path).Close();
        }

        public Estoque() {
            if(!File.Exists(path)) File.Create(path).Close();
        }
        public bool Create(string key, string value) {
            try {
                foreach(string s in File.ReadAllText(path).Split('\n')) {
                    if(s.Split('§')[0] == key) return false;
                }

                File.AppendAllText(
                    path,
                    key.Replace('§',' ') + '§' + value.Replace('§',' ') + '\n'
                );

                return true;
            } catch {
                
                return false;
            }
        }
        
        public string Read(string key) {
            try {
                foreach(string s in File.ReadAllText(path).Split('\n')) {
                    if(s.Split('§')[0] == key) return s.Split('§').Last();
                }

                return "";
            } catch {
                
                return "";
            }
        }
        public string[] Read() {
            try {
                List<String> reply = new List<String>();

                foreach(string s in File.ReadAllText(path).Split('\n')) {
                    if(s.Split('§').Length > 1)
                        reply.Add(s.Split('§').Last());
                }

                return reply.ToArray();
            } catch {
                
                return [];
            }
        }

        public bool Update(string key, string value) {
            try {
                string[] db = File.ReadAllText(path).Split('\n');

                for(int i = 0; i < db.Length; i++) {
                    if(db[i].Split('§')[0] != key) continue;

                    db[i] = key + '§' + value.Replace('§', ' ');
                    File.WriteAllText(path, String.Join('\n', db));
                    return true;
                }

                return false;
            } catch {
                
                return false;
            }
        }

        public bool Delete(string key) {
            try {
                List<String> db = new List<String>();
                int diff = 0;

                foreach(string str in File.ReadAllText(path).Split('\n')) {
                    diff++;
                    if(str.Split('§')[0] == key) continue;

                    diff--;
                    db.Add(str);
                }

                File.WriteAllText(path, String.Join('\n', db));
                return diff != 0;
            } catch {
                
                return false;
            }
        }
    };
}