
namespace Sum_Cubits_Application.Infrastructure.Database
{
    public class BaseEntty
    {
        public int Id { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? Deleted { get; set; }
    }
}
