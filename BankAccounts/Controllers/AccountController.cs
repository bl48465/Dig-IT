using AutoMapper;
using BankAccounts.Interfaces;
using BankAccounts.Models;
using BankAccounts.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BankAccounts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO)
        {
            if (ModelState.IsValid)
            {
               if(UserExists(registerDTO.Email)){ return BadRequest("Account already exists!"); }

                var user = _mapper.Map<User>(registerDTO);
                user.UserName = registerDTO.Email.ToLower();

                var result = await _userManager.CreateAsync(user, registerDTO.Password);

                if (!result.Succeeded) return BadRequest(result.Errors);

                return new UserDTO
                {
                    Name = user.Name,
                    LastName = user.LastName,
                    Email = user.Email,
                    Token = await _tokenService.CreateToken(user)
                };
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginDTO.Email);
                if (user == null) return NotFound("User doesn't exists!");

                var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);

                if (!result.Succeeded) return Unauthorized("Incorrect password!");

                return new UserDTO
                {
                    Name = user.Name,
                    LastName = user.LastName,
                    Email = user.Email,
                    Token = await _tokenService.CreateToken(user)
                };

            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        private bool UserExists(string email)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Email == email);
            if (user == null)
                return false;
            else
                return true;
        }
    }
}
