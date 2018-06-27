using BusinessLayer.Configs;

namespace BusinessLayer.Builders
{
    public static class ConfigBuilder
    {
        public static IConfigItem<T> GetConfig<T>()
        {
            var config = new JsonConfigItem<T>();

            return config;
        }
    }
}
