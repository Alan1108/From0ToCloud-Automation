using AttendanceAPI.Model;

namespace AttendanceAPI.Services
{
    public interface IMembersService
    {
        List<Member> Get();
        Member Get(string id);
        Member Create(Member member);
        void Update(string id, Member member);
        void Remove(string id);
    }
}
