
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNetCoreBox.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiNetCoreBox.Data{

    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context){
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Technical[]> GetAllTechnicals(bool includeStack = false)
        {
            IQueryable<Technical> tech = _context.Technicals;
            
            if (includeStack)
            {
              tech = tech.Include(s => s.Stacks);   
            }

            tech = tech.AsNoTracking().OrderBy(x => x.Id);

            return await tech.ToArrayAsync();

        }

        public async Task<Technical> GetTechnicalById(int id, bool includeStack = false)
        {
            IQueryable<Technical> tech = _context.Technicals;

            if (includeStack)
            {
              tech = tech.Include(s => s.Stacks);   
            }

            tech = tech.AsNoTracking().OrderBy(x => x.Id);

            return await tech.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Technical[]> GetTechnicalsByName(string name, bool includeStack = false)
        {
            IQueryable<Technical> tech = _context.Technicals;

            if (includeStack)
            {
              tech = tech.Include(s => s.Stacks);   
            }

            tech = tech.AsNoTracking()
            .Where(t => t.Name.Contains(name))
            .OrderBy(x => x.Id);

            return await tech.ToArrayAsync();
        }

        public async Task<Stack> GetStackById(int id)
        {
             IQueryable<Stack> stack = _context.Stacks;

            stack = stack.AsNoTracking().OrderBy(x => x.Id);

            return await stack.FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}