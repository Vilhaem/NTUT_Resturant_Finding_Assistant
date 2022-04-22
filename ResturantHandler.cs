// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;

// namespace NTUT_Resturant_Finding_Assistant
// {
//     [ApiController]
//     [Route("Resturant")]
//     public class ResturantHandler : Controller
//     {
//         private readonly ResturantStoreContext _db;
//         public ResturantHandler(ResturantStoreContext db)
//         {
//             _db = db;
//         }

//         [HttpGet]
//         public async Task<ActionResult<List<Resturant>>> GetResturants()
//         {
//             return (await _db.Resturants.ToListAsync()).OrderByDescending(r => r.Rating).ToList();
//         }
//     }
// }