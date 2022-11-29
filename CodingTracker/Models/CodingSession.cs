namespace CodingTracker.Models
{
    internal class CodingSession
    {
        internal DateTime StartTime { get; set; }
        internal DateTime EndTime { get; set; }
        internal TimeSpan Duration { get; set; }
        internal int Id { get; set; }
    }


}
