using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NTUT_Resturant_Finding_Assistant
{
    [Route("Resturants")]
    [ApiController]
    public class ResturantController : Controller
    {
        private readonly AppDbContext _db;
        public ResturantController(AppDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<ActionResult<List<Resturant>>> GetResturant()
        {
            return (await _db.Resturants.ToListAsync()).OrderByDescending(x => x.Id).ToList();
        }
    }
}