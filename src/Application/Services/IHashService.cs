namespace Application.Services
{
    public interface IHashService
    {
        void Create(string value, out byte[] hashedValue, out byte[] key);
        bool Verify(string value, byte[] hashedValueToCompare, byte[] keyToCompare);
    }
}
