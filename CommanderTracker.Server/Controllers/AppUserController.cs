﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CommanderTracker.Models;
using CommanderTracker.Models.DTO;
using CommanderTracker.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CommanderTracker.Server.Controllers
{
    [Tags("Auth")]
    [Route("api")]
    [ApiController]
    public class AppUserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService) : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager = userManager;
        private readonly SignInManager<AppUser> _signInManager = signInManager;
        private readonly ITokenService _tokenService = tokenService;

        [HttpPost("login")]
        public async Task<ActionResult<TokenDTO>> Login(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var appUser = await _userManager.Users.FirstOrDefaultAsync(user => user.UserName == loginDTO.UserName);

            if (appUser == null)
            {
                return Unauthorized();
            }

            var loginResult = await _signInManager.CheckPasswordSignInAsync(appUser, loginDTO.Password, false);

            if (!loginResult.Succeeded)
            {
                return Unauthorized();
            }

            var expires = DateTime.Now.AddDays(7);
            return new TokenDTO { Token = _tokenService.CreateToken(appUser, expires), Expires = expires };

        }

        [HttpPost("register")]
        public async Task<ActionResult<TokenDTO>> Register(RegisterDTO registerDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var appUser = new AppUser
                {
                    UserName = registerDTO.UserName,
                    Email = registerDTO.Email,
                };

                var createdUser = await _userManager.CreateAsync(appUser, registerDTO.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "User");

                    if (roleResult.Succeeded)
                    {
                        var expires = DateTime.Now.AddDays(7);
                        return new TokenDTO { Token = _tokenService.CreateToken(appUser, expires), Expires = expires };
                    }
                    else
                    {
                        return BadRequest(roleResult.Errors);
                    }
                }
                else
                {
                    return BadRequest(createdUser.Errors);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}