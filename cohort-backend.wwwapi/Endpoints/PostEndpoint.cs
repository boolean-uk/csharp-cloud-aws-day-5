using cohort_backend.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace cohort_backend.wwwapi.Endpoints
{
    public static class PostEndpoint
    {
        public static void ConfigurePostEndpoint(this WebApplication app)
        {
            var postGroup = app.MapGroup("/post");

            app.MapPost("/", CreateAPost);
            app.MapGet("/", GetAllPosts);
            app.MapGet("/{id}", GetAPost);
            app.MapPut("/{id}", UpdateAPost);
            app.MapDelete("/{id}", DeleteAPost);


        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public static async Task<IResult> CreateAPost(IPostRepository repository)
        {
            return TypedResults.Ok();

        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public static async Task<IResult> GetAllPosts(IPostRepository repository)
        {
           
            return TypedResults.Ok();
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAPost(IPostRepository repository, int id)
        {
           
            return TypedResults.Ok();
        } 
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> UpdateAPost(IPostRepository repository, int id)
        {
           
            return TypedResults.Ok();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteAPost(IPostRepository repository, int id)
        {
           
            return TypedResults.Ok();
        }




    }
}
