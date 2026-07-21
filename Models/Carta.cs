namespace Magic {

    class Carta : IModel {

        string path = Environment.SpecialFolder.Desktop.ToString() + "carta.db";

        public Carta(string? _path) {
            if(_path != null) path = _path;

            if(!File.Exists(path)) File.Create(path);
        }
        public bool Create(string key, string value) {
            
        }
        
        public string Read(string key) {

        }
        public string[] Read() {

        }

        public bool Update(string key, string value) {

        }

        public bool Delete(string key) {

        }
    };
}