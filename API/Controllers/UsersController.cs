using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.DataAccess;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> Getusers()
        {
            return await _context.users.ToListAsync();
        }

        [HttpPost]
        public async Task<Users> Login([FromBody] UserModel user)
        {
            if (UsersExists(user.login))
            {
                var item = _context.users.FirstOrDefault(x => x.login == user.login);
                if (item.password == user.password)
                {

                    return item;
                }
            }

            return null;
        }

        [Route("Register")]
        [HttpPost]
        public async Task<ActionResult> Register([FromBody] UserModel user)
        {
            if (!UsersExists(user.login))
            {
                _context.users.Add(new Users()
                {
                    login = user.login,
                    password = user.password,
                    name = user.name,
                    album = user.album
                });

                await _context.SaveChangesAsync();

                return StatusCode(200);
            }
            else
                return BadRequest();
        }


        private bool UsersExists(string login)
        {
            return _context.users.Any(e => e.login == login);
        }
    }
}