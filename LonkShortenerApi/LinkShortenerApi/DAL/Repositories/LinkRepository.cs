using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Base;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories;

public class LinkRepository : Repo<Link, int>, ILinkRepository
{
    public LinkRepository(ApplicationDbContext context)
        :base(context)
    {
        
    }
}
