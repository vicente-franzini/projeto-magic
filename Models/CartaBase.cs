namespace Magic {

    class CartaBase : IModel {

        private string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "CartaBase.db");

        public CartaBase(string? _path) {
            path = _path ?? path;

            if(!File.Exists(path)) File.Create(path).Close();
        }

        public CartaBase() {
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
            } catch (Exception e) {
                Console.WriteLine(e);
                return false;
            }
        }
        
        public string Read(string key) {
            try {
                foreach(string s in File.ReadAllText(path).Split('\n')) {
                    if(s.Split('§')[0] == key) return s.Split('§')[1];
                }

                return "";
            } catch (Exception e) {
                Console.WriteLine(e);
                return "";
            }
        }
        public string[] Read() {
            try {
                List<string> reply = new List<string>();

                foreach(string s in File.ReadAllText(path).Split('\n')) {
                    if(s.Split('§').Length > 1)
                        reply.Add(s.Split('§').Last());
                }

                return reply.ToArray();
            } catch (Exception e) {
                Console.WriteLine(e);
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
            } catch (Exception e) {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool Delete(string key) {
            try {
                List<String> db = new List<string>();

                foreach(string str in File.ReadAllText(path).Split('\n')) {
                    if(str.Split('§')[0] == key) continue;

                    db.Add(str);
                }

                File.WriteAllText(path, String.Join('\n', db));
                return true;
            } catch (Exception e) {
                Console.WriteLine(e);
                return false;
            }
        }
    };
}