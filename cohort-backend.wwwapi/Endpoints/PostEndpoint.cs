using cohort_backend.wwwapi.DTO;
using cohort_backend.wwwapi.DTO.PostModels;
using cohort_backend.wwwapi.DTO.Response;
using cohort_backend.wwwapi.Models;
using cohort_backend.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata.Conventions;
using System.Reflection;

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
           


        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public static async Task<IResult> CreateAPost(IPostRepository repository, PostModel model)
        {

            Post post = await repository.CreatePost(new Post()
            {
                Title = model.Title,
                Content = model.Content,
                UserId = model.ContactId
            });


            PostDTO postDTO = new PostDTO()
            {
                Title = post.Title,
                Content = post.Content,
                ContactId = post.UserId

            };


            return TypedResults.Ok(postDTO);

        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public static async Task<IResult> GetAllPosts(IPostRepository repository)
        {
            GetAllResponse<PostDTO> response = new GetAllResponse<PostDTO>();
            var results = await repository.GetAllPosts();

            foreach (var post in results)
            {
                PostDTO postDTO = new PostDTO()
                {
                    Title = post.Title,
                    Content = post.Content,
                    ContactId = post.UserId
                };

                response.ResponseData.Add(postDTO);
            }

            
           
            return TypedResults.Ok(response.ResponseData);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAPost(IPostRepository repository, int id)
        {
           var post = await repository.GetPostById(id);

            PostDTO postDTO = new PostDTO()
            {
                Title = post.Title,
                Content = post.Content,
                ContactId = post.UserId
            };

            return TypedResults.Ok(postDTO);
        } 
        
       



    }
}
