// using Microsoft.EntityFrameworkCore;
// using movie_api.Data;
// using movie_api.Models;
// using Microsoft.AspNetCore.Mvc;

// namespace movie_api.Controllers
// {
//     [ApiController]
//     [Route("v1/movie_archive")]
//     public class UserController : Controller 
//     {
//         [HttpPost]
//         [Route("/login")]    
//         public Task<ActionResult<Users>> UserLogin([FromServices] DataContext context, [FromBody] Users model) {  
        
//         var objlst = wmsEN.Usp_Login(objVM.UserName, UtilityVM.Encryptdata(objVM.Passward), "").ToList < Usp_Login_Result > ().FirstOrDefault();  
//         if (objlst.Status == -1) return new ResponseVM {  
//             Status = "Invalid", Message = "Invalid User."  
//         };  
//         if (objlst.Status == 0) return new ResponseVM {  
//             Status = "Inactive", Message = "User Inactive."  
//         };  
//         else return new ResponseVM {  
//             Status = "Success", Message = TokenManager.GenerateToken(objVM.UserName)  
//         };  
//     } 
//         [HttpGet]
//         [Route("/get/{id:int}")]
//         public async Task<ActionResult<Users>> GetMovieById([FromServices] DataContext context, int id)
//         {
//             var user = await context.Movies.FirstOrDefaultAsync(c=> c.Id == id);

//             if(movie == null) return NotFound();
            
//             await context.SaveChangesAsync();

//             return Ok(movie);    
//         }



