using System.IO;
using Newtonsoft.Json;

namespace BusinessLayer.Configs
{
    public class JsonConfigItem<T> : IConfigItem<T>
    {
        private string _path = @"Configs\";

        private T _data;

        public void Write(T data)
        {
            File.WriteAllText(_path + typeof(T) + ".json", JsonConvert.SerializeObject(data));
        }

        public T Read()
        {
            _data = JsonConvert.DeserializeObject<T>(File.ReadAllText(_path + typeof(T) + ".json"));
            return _data;
        }

        public T Get()
        {
            if (_data == null)
            {
                _data = Read();
            }
            return _data;
        }
    }
}
