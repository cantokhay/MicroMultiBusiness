using MicroMultiBusiness.Comment.Context;
using MicroMultiBusiness.Comment.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroMultiBusiness.Comment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    //[AllowAnonymous]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _context;

        public CommentsController(CommentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _context.UserComments.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddComment(UserComment comment)
        {
            _context.UserComments.Add(comment);
            _context.SaveChanges();
            return Ok("Created Succesfully!");
        }

        [HttpDelete]
        public IActionResult DeleteComment(int id)
        {
            var value = _context.UserComments.Find(id);
            _context.UserComments.Remove(value);
            _context.SaveChanges();
            return Ok("Deleted Succesfully!");
        }

        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var value = _context.UserComments.Find(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateComment(UserComment comment)
        {
            _context.UserComments.Update(comment);
            _context.SaveChanges();
            return Ok("Updated Succesfully!");
        }

        [HttpGet("CommentListByProductId/{id}")]
        public IActionResult CommentListByProductId(string id)
        {
            var values = _context.UserComments.Where(x => x.ProductId == id).ToList();
            return Ok(values);
        }

        [HttpGet("GetActiveCommentsCount")]
        public IActionResult GetActiveCommentsCount()
        {
            int value = _context.UserComments.Where(x => x.Status == true).Count();
            return Ok(value);
        }

        [HttpGet("GetPassiveCommentsCount")]
        public IActionResult GetPassiveCommentsCount()
        {
            int value = _context.UserComments.Where(x => x.Status == false).Count();
            return Ok(value);
        }

        [HttpGet("GetTotalCommentsCount")]
        public IActionResult GetTotalCommentsCount()
        {
            int value = _context.UserComments.Count();
            return Ok(value);
        }
    }
}