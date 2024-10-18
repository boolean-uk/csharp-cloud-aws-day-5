using cohort_backend.wwwapi.Data;
using cohort_backend.wwwapi.Models;
using Microsoft.EntityFrameworkCore;

namespace cohort_backend.wwwapi.Repository
{
    public class PostRepository : IPostRepository
    {
        private DatabaseContext _db;

        public PostRepository(DatabaseContext db)
        {
            _db = db;
        }

        // POSTS
        public async Task<Post> CreatePost(Post entity)
        {
            _db.Posts.Add(entity);
            await _db.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<Post>> GetAllPosts()
        {
            return await _db.Posts.ToListAsync();
        }

        public async Task<Post> UpdatePostById(Post entity, int postId)
        {
            var existingEntity = await _db.Posts.FirstOrDefaultAsync(p => p.Id == postId);

            if (entity == null)
            {
                throw new NotImplementedException($"Post with id {postId} does not exist.");
            }

            _db.Posts.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }

        public async Task<Post> DeletePostById(int postId)
        {
            var entity = await _db.Posts.FirstOrDefaultAsync(p => p.Id == postId);

            if (entity == null) { 
                throw new NotImplementedException($"Post with id {postId} does not exist.");
            }

            _db.Posts.Remove(entity);
            await _db.SaveChangesAsync();

            return entity;
        }

        public async Task<Post> GetPostById(int postId)
        {
            var entity = await _db.Posts.FirstOrDefaultAsync(p => p.Id == postId);

            if (entity == null) { 
                throw new KeyNotFoundException($"Post with id {postId} does not exist.");
            }

            return entity;
        }

        // COMMENTS
        public async Task<Comment> CreateComment(Comment entity)
        {
            _db.Comments.Add(entity);
            await _db.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<Comment>> GetAllCommentsInPost(int postId)
        {
            return await _db.Comments.Where(p => p.PostId == postId).ToListAsync();
        }

        public async Task<Comment> UpdateComment(Comment entity, int commentId)
        {
            throw new NotImplementedException();
        }

        public async Task<Comment> DeleteComment(int commentId)
        {
            throw new NotImplementedException();
        }
    }
}
