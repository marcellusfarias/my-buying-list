﻿using MyBuyingList.Application.Common.Exceptions;
using MyBuyingList.Application.Common.Interfaces.Repositories;
using MyBuyingList.Domain.Entities;

namespace MyBuyingList.Infrastructure.Repositories;

public class BuyingListRepository : RepositoryBase<BuyingList>, IBuyingListRepository
{
    public BuyingListRepository(ApplicationDbContext context) : base(context) { }

    public void DeleteBuyingListAndItems(BuyingList buyingList)
    {
        try
        {
            if(buyingList.Items.Count > 0)
            {
                foreach(var item in buyingList.Items)
                    _context.Set<BuyingListItem>().Remove(item);                
            }

            _context.Set<BuyingList>().Remove(buyingList);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new DatabaseException(ex);
        }       
    }
}