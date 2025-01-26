using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Base;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class UserRepository : Repo<User, int>, IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
        : base(context)
    {
        _context = context;
    }
    public async Task<User?> GetByUsername(string username)
    {
        return await _context.Users.FirstOrDefaultAsync(x =>
                     x.Username.ToLower() == username.ToLower());
    }

    public async Task<bool> UserExists(string username)
    {
        return await _context.Users.AnyAsync(x =>
            x.Username.ToLower() == username.ToLower());
    }
}
