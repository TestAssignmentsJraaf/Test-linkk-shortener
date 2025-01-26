using AutoMapper;
using BLL.DTO;
using BLL.Services.Base;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace BLL.Services;

public class LinkService : Crud<Link, CreateLinkDTO>, ILinkService
{
    public LinkService(IMapper mapper, ILinkRepository repo)
        : base(mapper, repo)
    {

    }
}
