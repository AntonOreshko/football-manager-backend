namespace BusinessLayer.Configs
{
    public interface IConfigItem<T>
    {
        void Write(T data);

        T Read();

        T Get();
    }
}
