using cohort_backend.wwwapi.Data;
using cohort_backend.wwwapi.Models;

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
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Post>> GetAllPosts()
        {
            throw new NotImplementedException();
        }

        public async Task<Post> UpdatePostById(Post entity, int postId)
        {
            throw new NotImplementedException();
        }

        public async Task<Post> DeletePostById(int postId)
        {
            throw new NotImplementedException();
        }

        public async Task<Post> GetPostById(int postId)
        {
            throw new NotImplementedException();
        }

        // COMMENTS
        public async Task<Comment> CreateCommentInPost(Comment entity, int postId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Comment>> GetAllCommentsInPost(int postId)
        {
            throw new NotImplementedException();
        }

        public async Task<Comment> UpdateCommentInPost(Comment entity, int postId)
        {
            throw new NotImplementedException();
        }

        public async Task<Comment> DeleteCommentInPost(int commentId, int postId)
        {
            throw new NotImplementedException();
        }
    }
}
