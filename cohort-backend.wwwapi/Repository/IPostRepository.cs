using cohort_backend.wwwapi.Models;

namespace cohort_backend.wwwapi.Repository
{
    public interface IPostRepository
    {
        // POSTS
        Task<Post> CreatePost(Post entity);
        Task<IEnumerable<Post>> GetAllPosts();
        Task<Post> UpdatePostById(Post entity, int postId);
        Task<Post> DeletePostById(int postId);
        Task<Post> GetPostById(int postId);

        // COMMENTS
        Task<Comment> CreateComment(Comment entity);
        Task<IEnumerable<Comment>> GetAllCommentsInPost(int postId);
        Task<Comment> UpdateComment(Comment entity, int commentId);
        Task<Comment> DeleteComment(int commentId);
    }
}
