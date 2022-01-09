using System.Threading.Tasks;

namespace BlogStore.Data
{
    public interface IBlogStoreDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
