using AuthenticationApi.Custom;
using AuthenticationApi.Data;
using AuthenticationApi.Data.DTOs;
using AuthenticationApi.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AccesController:ControllerBase
    {
        private readonly AutheticationContext _context;
        private readonly Utils _utils;
        public AccesController(AutheticationContext context,Utils utils)
        {
            _context = context;
            _utils = utils;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(UserDTO userDTO)
        {
            var modelUser = new User()
            {
                Email = userDTO.Email,
                Username = userDTO.Name,
                Password = _utils.GenerateHash(userDTO.Password)
            };

            await _context.Users.AddAsync(modelUser);
            await _context.SaveChangesAsync();

            if (modelUser.Id != 0)
                return Ok(new {isSuccess = true});

            return Ok(new { isSuccess = false });
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginDTO loginDTO)
        {
            var user = await _context.Users.Where(u => u.Email == loginDTO.Email && u.Password == _utils.GenerateHash(loginDTO.Password)).FirstOrDefaultAsync();
             
            if(user == null) return Ok(new { isSuccess = false, token ="" });

            return Ok(new { isSuccess = true, token = _utils.GenerateJwtToken(user), user});

        }

    }
}
