using Application.Catalogs.Dtos;
using Application.Context;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Catalogs.CatalogTypes.Queries
{
    public record GetCatalogTypeByIdQuery(CatalogTypeDto CatalogType) : IRequest<BaseDto<CatalogTypeDto>>;

    public class GetCatalogTypeByIdHandler : IRequestHandler<GetCatalogTypeByIdQuery, BaseDto<CatalogTypeDto>>
    {
        private readonly IDatabaseContext context;
        private readonly IMapper mapper;
        public GetCatalogTypeByIdHandler(IDatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<BaseDto<CatalogTypeDto>> Handle(GetCatalogTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await context.CatalogTypes.FindAsync(request.CatalogType.Id);
            if (data == null) return new BaseDto<CatalogTypeDto>(false, new List<string> { "نوع کاتالوگ یافت نشد" }, null);
            return new BaseDto<CatalogTypeDto>(true, null, mapper.Map<CatalogTypeDto>(data));
        }
    }
}
