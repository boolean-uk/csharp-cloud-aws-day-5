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
        Task<Comment> CreateCommentInPost(Comment entity, int postId);
        Task<IEnumerable<Comment>> GetAllCommentsInPost(int postId);
        Task<Comment> UpdateCommentInPost(Comment entity, int postId);
        Task<Comment> DeleteCommentInPost(int commentId, int postId);
    }
}
