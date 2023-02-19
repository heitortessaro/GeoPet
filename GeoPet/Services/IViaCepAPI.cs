namespace GeoPet.Services
{
    public interface IViaCepAPI
    {
        Task<object> GetLocation(string cep);
    }
}
