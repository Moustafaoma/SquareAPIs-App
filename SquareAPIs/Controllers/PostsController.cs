using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Square.Core.DTOs;
using Square.Core.Models;
using Square.Core.RepositoryServices;

namespace Square.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public PostsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult GetPosts()
        {
            var posts= _unitOfWork.Posts.FindAll(new[] { "Users" });
            if (posts == null)
                return NotFound("Not Posts Found..");
            return Ok(posts);
        }
        [HttpPost]
        public IActionResult CreatePost(PostDto postdto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var post = new Posts()
            {
                Title = postdto.Title,
                URL = postdto.URL,
                UsersId = postdto.UsersId

            };
            _unitOfWork.Posts.Add(post);
            _unitOfWork.Complete();
            return Ok(post);
        }
        [HttpDelete("{id}")]
        public IActionResult DeletePost(int id)
        {
            var post = _unitOfWork.Posts.Get(id);
            if (post == null)
            {
                return NotFound("Post not found.");
            }

            _unitOfWork.Posts.Delete(post);
            _unitOfWork.Complete();

            return Ok(post);
        }
        [HttpPut("{id}")]
        public IActionResult UpdatePost(int id, [FromBody] PostDto postDto)
        {
            if (postDto == null)
            {
                return BadRequest("Comment data is required.");
            }
            var post = _unitOfWork.Posts.Get(id);
            if (post == null)
                return NotFound("Not Comment Found");
           post.Title = postDto.Title;
            post.URL = postDto.URL;
            post.UsersId= postDto.UsersId;
            _unitOfWork.Posts.Update(post);
            _unitOfWork.Complete();
            return Ok(post);
        }
    }
}
