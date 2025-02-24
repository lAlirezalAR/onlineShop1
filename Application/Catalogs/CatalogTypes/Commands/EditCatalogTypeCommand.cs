using Application.Catalogs.Dtos;
using Application.Context;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Catalogs.CatalogTypes.Commands
{
    public record EditCatalogTypeCommand(CatalogTypeDto CatalogType) : IRequest<BaseDto<CatalogTypeDto>>;

    public class EditCatalogTypeCommandHandler : IRequestHandler<EditCatalogTypeCommand, BaseDto<CatalogTypeDto>>
    {
        private readonly IDatabaseContext context;
        private readonly IMapper mapper;
        public EditCatalogTypeCommandHandler(IDatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<BaseDto<CatalogTypeDto>> Handle(EditCatalogTypeCommand request, CancellationToken cancellationToken)
        {
            var model = context.CatalogTypes.FindAsync(request.CatalogType.Id);
            if (model == null) return new BaseDto<CatalogTypeDto>(false, new List<string> { "نوع کاتالوگ یافت نشد" }, null);
            mapper.Map(request.CatalogType, model);
            await context.SaveChangesAsync(cancellationToken);
            return new BaseDto<CatalogTypeDto>(true, new List<string> { "ویرایش با موفقیت انجام شد" }, mapper.Map<CatalogTypeDto>(model));
        }
    }
}
