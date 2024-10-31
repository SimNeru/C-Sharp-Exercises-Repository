namespace ServiceContracts
{
    public interface ICitiesService
    {
        Guid ServiceInstanceId { get; }

        // scrivo solo la firma dei metodi che prevedo di implementare
        List<string> GetCitiesMethod();

    }
}
