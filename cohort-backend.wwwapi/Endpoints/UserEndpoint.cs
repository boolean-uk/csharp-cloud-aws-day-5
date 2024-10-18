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
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetUsers(IUserRepository repository)
        {
            var users = await repository.GetUsers();
            if (users != null)
            {

            }
          return TypedResults.Ok();
        }
    }
}
