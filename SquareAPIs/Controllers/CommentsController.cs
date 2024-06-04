using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Square.Core.DTOs;
using Square.Core.Models;
using Square.Core.RepositoryServices;

namespace Square.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CommentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        public IActionResult CreateComment(CommentDto commentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var comment = new Comments()
            {
               UserId = commentDto.UserId,
               Comment= commentDto.Comment,
               PostId = commentDto.PostId,
            };
            _unitOfWork.Comments.Add(comment);
            _unitOfWork.Complete();
            return Ok(comment);

        }
        [HttpGet]
        public IActionResult GetAllComments()
        {
            var comments = _unitOfWork.Comments.FindAll("User", "Post"); 

            return Ok(comments);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id)
        {
            var comment = _unitOfWork.Comments.Get(id);
            if (comment == null)
            {
                return NotFound("Post not found.");
            }

            _unitOfWork.Comments.Delete(comment);
            _unitOfWork.Complete();

            return Ok(comment);
        }
        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var comment= _unitOfWork.Comments.Get(id);
            if (comment == null)
                return NotFound("Not comment found");
            return Ok(comment);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateComment(int id,[FromBody] CommentDto commentDto)
        {
            if (commentDto == null)
            {
                return BadRequest("Comment data is required.");
            }
            var comment=_unitOfWork.Comments.Get(id);
            if (comment == null)
                return NotFound("Not Comment Found");
            comment.Comment=commentDto.Comment;
            comment.UserId = commentDto.UserId;
            comment.PostId = commentDto.PostId;
            _unitOfWork.Comments.Update(comment);
            _unitOfWork.Complete();
            return Ok(comment);
        }


    }
}
