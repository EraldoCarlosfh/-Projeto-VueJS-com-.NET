
using System.Threading.Tasks;
using ApiNetCoreBox.Models;

namespace ApiNetCoreBox.Data{

    public interface IRepository{

        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangeAsync();

        //Task<Technical[]> GetAllTechnicals();
        //Task<Technical> GetTechnicalById(int id);
        //Task<Technical[]> GetTechnicalsByName(string name);

        

        //caso queira fazer em duas tabelas ai precisa usar esse metodos para incluir as stacks(stacks)
        Task<Technical[]> GetAllTechnicals(bool includeStacks = false);
        Task<Technical> GetTechnicalById(int id, bool includeStacks = false);

        Task<Stack> GetStackById(int id);

        Task<Technical[]> GetTechnicalsByName(string name, bool includeStack = false);

    }
}