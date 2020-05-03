using BookStore_API.Contracts;
using BookStore_API.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_API.Services
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _dbContxt;

            public AuthorRepository(ApplicationDbContext dbContext)
        {
            _dbContxt = dbContext;
        }
        public async Task<bool> Create(Author entity)
        {
           await _dbContxt.Authors.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Author entity)
        {
            _dbContxt.Remove(entity);
            return await Save();
        }

        public async Task<bool> DoesExist(int id)
        {
            return await _dbContxt.Authors.AnyAsync(q => q.Id == id);
        }

        public async Task<IList<Author>> FindAll()
        {
            var authors = await _dbContxt.Authors.ToArrayAsync();

            return authors;
        }

        public async Task<Author> FindById(int id)
        {
            var author = await _dbContxt.Authors.FindAsync(id);

            return author;
        }

        public async Task<bool> Save()
        {
            var changes = await _dbContxt.SaveChangesAsync();

            return changes > 0;
        }

        public async Task<bool> Update(Author entity)
        {
            _dbContxt.Update(entity);

            return await Save();
        }
    }
}
