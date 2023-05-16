namespace AttendanceAPI.Model
{
    public interface IAttendanceDBSettings
    {
        string AttendanceCollectionName { get; set;}
        string ConectionString { get; set;}
        string DatabaseName { get; set;}  

    }
}
