﻿using MyBuyingList.Application.Common.Interfaces.Repositories;
using MyBuyingList.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MyBuyingList.Application.Common.Exceptions;
using static Dapper.SqlMapper;

namespace MyBuyingList.Infrastructure.Repositories;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context) { }

    //Make this async
    public IEnumerable<User> GetActiveUsers()
    {
        try
        {
            //if you want to use Dapper for performance issues, see below
            //_context.QueryAsync(ct, "SELECT * FROM users WHERE Active = 'true';");
            var result = _context.Set<User>().Where(x => x.Active).ToList();
            return result;
        }
        catch (Exception ex)
        {
            throw new DatabaseException(ex);
        }
    }

    //test this
    public void LogicalExclusion(User user)
    {
        try
        {
            user.Active = false;
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new DatabaseException(ex);
        }
    }
}
