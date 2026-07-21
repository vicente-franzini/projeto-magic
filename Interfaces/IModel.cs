
namespace Magic {
    interface IModel {
        bool Create(string key, string value);
        
        string Read(string key);
        string[] Read();

        bool Update(string key, string value);

        bool Delete(string key);
        
    }
}