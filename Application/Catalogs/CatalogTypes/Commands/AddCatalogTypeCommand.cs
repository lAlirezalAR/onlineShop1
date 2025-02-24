using Application.Catalogs.Dtos;
using Application.Context;
using AutoMapper;
using Domain.Catalog;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Catalogs.CatalogTypes.Commands
{
    public record AddCatalogTypeCommand(CatalogTypeDto CatalogType) : IRequest<BaseDto<CatalogTypeDto>>;

    public class AddCatalogTypeCommandHandler : IRequestHandler<AddCatalogTypeCommand, BaseDto<CatalogTypeDto>>
    {
        private readonly IDatabaseContext context;
        private readonly IMapper mapper;
        public AddCatalogTypeCommandHandler(IDatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<BaseDto<CatalogTypeDto>> Handle(AddCatalogTypeCommand request, CancellationToken cancellationToken)
        {
            var model = mapper.Map<CatalogType>(request.CatalogType);
            await context.CatalogTypes.AddAsync(model, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return new BaseDto<CatalogTypeDto>(true, new List<string> { $"تایپ {model.Type} با موفقیت ثبت شد" }, mapper.Map<CatalogTypeDto>(model));
        }
    }
}
