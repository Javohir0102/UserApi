using Microsoft.EntityFrameworkCore;
using STX.EFxceptions.SqlServer;
using UserApi.Models.User;

namespace UserApi.Brokers
{
    public partial class StorageBroker : EFxceptionsContext, IStorageBroker
    {
        private readonly IConfiguration configuration;
        public StorageBroker(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.Database.Migrate();
        }


        public async ValueTask<T> InsertAsync<T>(T entity) where T : class
        {
            await this.Set<T>().AddAsync(entity);
            await this.SaveChangesAsync();

            return entity;
        }

        public IQueryable<T> SelectAllAsync<T>() where T : class
        {
            return this.Set<T>();
        }

        public async ValueTask<T> UpdateAsync<T>(T entity) where T : class
        {
            this.Set<T>().Update(entity);
            await this.SaveChangesAsync();

            return entity;
        }

        public async ValueTask<T> DeleteAsync<T>(T entity) where T : class
        {
            this.Set<T>().Remove(entity);
            await this.SaveChangesAsync();

            return entity;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionPath = this.configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionPath);
        }

    }
}
