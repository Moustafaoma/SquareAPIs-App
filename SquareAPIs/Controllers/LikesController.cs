using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Square.Core.DTOs;
using Square.Core.Models;
using Square.Core.RepositoryServices;

namespace Square.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public LikesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        public IActionResult CreateLike(LikeDto likeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var like = new Likes()
            {
                UserId = likeDto.UserId,
                PostId = likeDto.PostId,
            };
            _unitOfWork.Likes.Add(like);
            _unitOfWork.Complete();
            return Ok(like);

        }
        [HttpDelete("{id}")]

        public IActionResult DeleteLike(int id)
        {
            var like = _unitOfWork.Likes.Get(id);
            if (like == null)
            {
                return NotFound("Post not found.");
            }

            _unitOfWork.Likes.Delete(like);
            _unitOfWork.Complete();

            return Ok(like);
        }
    }
}
