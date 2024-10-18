using cohort_backend.wwwapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace cohort_backend.wwwapi.Endpoints
{
    public static class UserEndpoint
    {
        public static void ConfigureUserEndpoint(this WebApplication app)
        {
            var userGroup = app.MapGroup("/users");

            userGroup.MapGet("/", GetUsers);
            userGroup.MapGet("/{id}", GetUserById);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetUsers(IUserRepository repository)
        {  
          return TypedResults.Ok(await repository.GetUsers());
        }

        [Route("/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetUserById(IUserRepository repository, int id)
        {
            var user = await repository.GetUserById(id);

            if (user == null) 
            {
                return TypedResults.NotFound();
            }

            return TypedResults.Ok(user);
        }
    }
}
