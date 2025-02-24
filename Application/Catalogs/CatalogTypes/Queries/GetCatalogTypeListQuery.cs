using Application.Catalogs.CatalogTypes.Dtos;
using Application.Context;
using Application.Dtos;
using AutoMapper;
using Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Catalogs.CatalogTypes.Queries
{
    public record GetCatalogTypeListQuery(int? ParentCatalogTypeId, int Page, int PageSize) : IRequest<PaginatedItemDto<CatalogTypeListDto>>;

    public class GetCatalogTypeListHandler : IRequestHandler<GetCatalogTypeListQuery, PaginatedItemDto<CatalogTypeListDto>>
    {
        private readonly IDatabaseContext context;
        private readonly IMapper mapper;

        public GetCatalogTypeListHandler(IDatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<PaginatedItemDto<CatalogTypeListDto>> Handle(GetCatalogTypeListQuery request, CancellationToken cancellationToken)
        {
            int totalCount = 0;
            var model = context.CatalogTypes
                .Where(p => p.ParentCatalogTypeId == request.ParentCatalogTypeId)
                .PagedResult(request.Page, request.PageSize, out totalCount);

            var result = await mapper.ProjectTo<CatalogTypeListDto>(model).ToListAsync(cancellationToken);

            return new PaginatedItemDto<CatalogTypeListDto>(request.Page, request.PageSize, totalCount, result);
        }
    }
}
