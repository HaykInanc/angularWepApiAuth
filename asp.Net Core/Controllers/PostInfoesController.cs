using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostInfoesController : ControllerBase
    {
        private readonly dataContext _context;

        public PostInfoesController(dataContext context)
        {
            _context = context;
        }

        // GET: api/PostInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostInfo>>> GetPostInfo()
        {
            return await _context.PostInfo.ToListAsync();
        }

        // GET: api/PostInfoes/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<PostInfo>> GetPostInfo(int id)
        {
            var postInfo = await _context.PostInfo.FindAsync(id);

            if (postInfo == null)
            {
                return NotFound();
            }

            return postInfo;
        }

        // PUT: api/PostInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostInfo(int id, PostInfo postInfo)
        {
            if (id != postInfo.id)
            {
                return BadRequest();
            }

            _context.Entry(postInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PostInfoes
        [HttpPost]
        public async Task<ActionResult<PostInfo>> PostPostInfo(PostInfo postInfo)
        {
            _context.PostInfo.Add(postInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPostInfo", new { id = postInfo.id }, postInfo);
        }

        // DELETE: api/PostInfoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PostInfo>> DeletePostInfo(int id)
        {
            var postInfo = await _context.PostInfo.FindAsync(id);
            if (postInfo == null)
            {
                return NotFound();
            }

            _context.PostInfo.Remove(postInfo);
            await _context.SaveChangesAsync();

            return postInfo;
        }

        private bool PostInfoExists(int id)
        {
            return _context.PostInfo.Any(e => e.id == id);
        }
    }
}
