using AttendanceAPI.Model;
using MongoDB.Driver;

namespace AttendanceAPI.Services
{
    public class MembersService : IMembersService
    {
        private readonly IMongoCollection<Member> _members;

        public MembersService(IAttendanceDBSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _members = database.GetCollection<Member>(settings.AttendanceCollectionName);
        }
        public Member Create(Member member)
        {
            _members.InsertOne(member);
            return member;
        }

        public List<Member> Get()
        {
            return _members.Find(member => true).ToList();
        }

        public Member Get(string id)
        {
            return _members.Find(member => member.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _members.DeleteOne(member => member.Id == id);
        }

        public void Update(string id, Member member)
        {
            _members.ReplaceOne(member => member.Id == id, member);
        }
    }
}
