namespace cohort_backend.wwwapi.DTO.Response
{
    public class GetAllResponse<T> where T : class
    {
        public List<T> ResponseData { get; set; } = new List<T>();
    }
}
