using AttendanceAPI.Model;
using AttendanceAPI.Services;
using Microsoft.AspNetCore.Mvc;
using static MongoDB.Bson.Serialization.Serializers.SerializerHelper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AttendanceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMembersService memmebrsService;

        public MembersController(IMembersService memmebrsService)
        {
            this.memmebrsService = memmebrsService;
        }
        // GET: api/<MembersController>
        [HttpGet]
        public ActionResult<List<Model.Member>> Get()
        {
            return memmebrsService.Get();
        }

        // GET api/<MembersController>/5
        [HttpGet("{id}")]
        public ActionResult<Model.Member> Get(string id)
        {
            var member = memmebrsService.Get(id);

            if (member == null)
            {
                return NotFound($"Member with Id= {id} not found");
            }
            return member;
        }

        // POST api/<MembersController>
        [HttpPost]
        public ActionResult<Model.Member> Post([FromBody] Model.Member member)
        {
            memmebrsService.Create(member);
            return CreatedAtAction(nameof(Get), new { id = member.Id }, member);
        }

        // PUT api/<MembersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Model.Member member)
        {
            var existingMember = memmebrsService.Get(id);

            if (existingMember == null)
            {
                return NotFound($"Member with Id= {id} not found");
            }
            memmebrsService.Update(id, member);
            return NoContent();
        }

        // DELETE api/<MembersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var member = memmebrsService.Get(id);

            if (member == null)
            {
                return NotFound($"Member with Id= {id} not found");
            }
            memmebrsService.Remove(member.Id);
            return Ok($"Member with Id= {id} deleted");
        }
    }
}
