namespace Journey.Communication.Responses;
public class ResponseTripsJson
{
    public IList<ResponseShortTripJson> Trips { get; set; } = [];
    // IList pq é abstracao de uma interface
}
