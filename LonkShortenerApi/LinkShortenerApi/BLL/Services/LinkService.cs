using AutoMapper;
using BLL.DTO;
using BLL.Services.Base;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using LinkShortenerApi.BLL.DTO;
using System.Text.Json;

namespace BLL.Services;

public class LinkService : Crud<Link, CreateLinkDTO>, ILinkService
{
    private readonly IMapper mapper;
    private readonly ILinkRepository repo;

    public LinkService(IMapper mapper, ILinkRepository repo)
        : base(mapper, repo)
    {
        this.mapper = mapper;
        this.repo = repo;
    }
    public async new Task<Link> AddAsync(CreateLinkDTO dto, int userId)
    {
        var client = new HttpClient();
        Link proccessedLink = new Link();

        proccessedLink.InitialUrl = dto.InitialUrl;
        proccessedLink.UserId = userId;
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri("https://url-shortener-service.p.rapidapi.com/shorten"),
            Headers =
            {
                { "x-rapidapi-key", "7e1c129c19mshcb1c97363c15879p1ee493jsn823740fce30c" },
                { "x-rapidapi-host", "url-shortener-service.p.rapidapi.com" },
            },
            Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "url", "https://google.com/" },
            }),
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ReturnedLink>(body);

            proccessedLink.ProccessedUrl = result.result_url;
        }
        return await repo.AddAsync(proccessedLink);
    }
}
