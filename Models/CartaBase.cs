namespace Magic {

    class CartaBase : IModel {

        private string path = Environment.SpecialFolder.Desktop.ToString() + "CartaBase.db";

        public CartaBase(string? _path) {
            path = _path ?? path;

            if(!File.Exists(path)) File.Create(path).Close();
        }

        public CartaBase() {
            if(!File.Exists(path)) File.Create(path).Close();
        }
        public bool Create(string values) {
            try {
                foreach(string s in File.ReadAllText(path).Split('\n')) {
                    if(s.Split('§')[0] == values.Split('§')[0]) return false;
                }

                File.AppendAllText(
                    path,
                    values + '\n'
                );

                return true;
            } catch (Exception e) {
                Console.WriteLine(e);
                return false;
            }
        }
        
        public Carta? Read(string key) {
            try {
                Carta c = new Carta();

                foreach(string s in File.ReadAllText(path).Split('\n')) {
                    if(s.Split('§')[0] == key){
                        c.InputValuesString(s);
                        return c;
                    }
                }

                return;
            } catch (Exception e) {
                Console.WriteLine(e);
                return;
            }
        }
        public Carta[] Read() {
            try {
                string[] db = File.ReadAllText(path).Split('\n');
                Carta[] cartas = new Carta[db.Length];
                int i = 0;

                foreach(string s in db) {
                    if(s.Split('§').Length > 1){
                        cartas[0].InputValuesString(s);
                        i++;
                    }
                }

                return cartas;
            } catch (Exception e) {
                Console.WriteLine(e);
                return [];
            }
        }

        public bool Update(string values) {
            try {
                string[] db = File.ReadAllText(path).Split('\n');

                for(int i = 0; i < db.Length; i++) {
                    if(db[i].Split('§')[0] != values.Split('§')[0]) continue;

                    db[i] = values;
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