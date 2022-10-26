namespace BlazingShop.Client.Services.StatsService
{
    public interface IStatsService
    {
        Task GetVisit();
        Task IncrementVisits();
    }
}
