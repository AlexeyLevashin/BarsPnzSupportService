using Application.Dto.Users.Responses;
using Domain.DbModels;

namespace Application.Common.Pagination;

public class PagedResponse<T>
{
    public List<T> Items { get; set; }
    public PageViewModel PageInfo { get; set; }
}