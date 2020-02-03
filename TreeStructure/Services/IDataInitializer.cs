using System.Threading.Tasks;

namespace TreeStructure.Services
{
    public interface IDataInitializer
    {
        Task SeedAsync();
    }
}
