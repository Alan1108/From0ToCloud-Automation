namespace AttendanceAPI.Model
{
    public class AttendanceDBSettings:IAttendanceDBSettings
    {
        public string AttendanceCollectionName { get; set; } = String.Empty;
        public string ConectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
