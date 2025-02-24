using Application.Catalogs.Dtos;
using Application.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Catalogs.CatalogTypes.Commands
{
    public record RemoveCatalogTypeCommand(CatalogTypeDto CatalogType):IRequest<BaseDto>;

    public class RemoveCatalogTypeHandler : IRequestHandler<RemoveCatalogTypeCommand, BaseDto>
    {
        private readonly IDatabaseContext context;
        public RemoveCatalogTypeHandler(IDatabaseContext context)
        {
            this.context = context;
        }

        public async Task<BaseDto> Handle(RemoveCatalogTypeCommand request, CancellationToken cancellationToken)
        {
            var catalogType = await context.CatalogTypes.FindAsync(request.CatalogType.Id);
            if (catalogType == null) return new BaseDto(false, new List<string> { "نوع کاتالوگ یافت نشد" });
            context.CatalogTypes.Remove(catalogType);
            await context.SaveChangesAsync(cancellationToken);
            return new BaseDto(true, new List<string> { "آیتم با موفقیت حذف شد" });
        }
    }
}
