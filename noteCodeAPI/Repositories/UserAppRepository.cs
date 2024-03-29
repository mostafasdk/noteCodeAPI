﻿using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Management.SqlParser.SqlCodeDom;
using noteCodeAPI.Models;
using noteCodeAPI.Tools;

namespace noteCodeAPI.Repositories
{
    public class UserAppRepository : BaseRepository<UserApp>
    {
        public UserAppRepository(DataDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<bool> DeleteAsync(UserApp element)
        {
            _dbContext.Users.Remove(element);
            return await UpdateAsync();
        }

        public override async Task<List<UserApp>> GetAllAsync()
        {
            return await _dbContext.Users.Include(u => u.Notes).ToListAsync();
        }

        public override async Task<UserApp> GetByIdAsync(int id)
        {
            return await _dbContext.Users.Include(u => u.Notes).FirstOrDefaultAsync(u => u.Id == id);
        }

        public override async Task<bool> SaveAsync(UserApp element)
        {
            _dbContext.Users.Add(element);
            return await UpdateAsync();
        }

        public async Task<UserApp> SearchByNameAsync(string username)
        {
            return await _dbContext.Users.Include(u => u.Notes).FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
        }

        public async Task<UserApp> SearchByIDsAsync(string username, string password)
        {
            return await _dbContext.Users.Include(u => u.Notes).FirstOrDefaultAsync(u => u.Username == username && u.PasswordHashed == password);
        }

        public async Task<List<UserApp>> GetWaitingUsers()
        {
            return await _dbContext.Users.Include(u => u.Notes).Where(u => u.IsValid == false).ToListAsync();
        }

        public override Task<UserApp> GetByGuidAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
