namespace GeoPet.Services
{
    public interface ILocationService
    {
        Task<object> GetLocationByCep(string cep);
        Task<object> GetLocationByLatitudeLongitude(string latitude, string longitude);

    }
}
