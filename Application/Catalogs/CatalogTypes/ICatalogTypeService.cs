using Application.Catalogs.Dtos;
using Application.Context;
using Application.Dtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Catalogs.CatalogTypes
{
    public interface ICatalogTypeService
    {
        BaseDto<CatalogTypeDto> Add(CatalogTypeDto catalogType);
        BaseDto Remove(int Id);
        BaseDto<CatalogTypeDto> Edit(CatalogTypeDto catalogType);
        BaseDto<CatalogTypeDto> FindById(int Id);
        PaginatedItemDto<CatalogTypeDto> GetList(int? parentId, int page, int pageSize);
    }

    public class CatalogTypeService : ICatalogTypeService
    {
        private readonly IDatabaseContext context;
        private readonly IMapper mapper;

        public CatalogTypeService(IDatabaseContext context)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public BaseDto<CatalogTypeDto> Add(CatalogTypeDto catalogType)
        {
            throw new NotImplementedException();
        }

        public BaseDto<CatalogTypeDto> Edit(CatalogTypeDto catalogType)
        {
            throw new NotImplementedException();
        }

        public BaseDto<CatalogTypeDto> FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public PaginatedItemDto<CatalogTypeDto> GetList(int? parentId, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public BaseDto Remove(int Id)
        {
            throw new NotImplementedException();
        }
    }

    public class CatalogTypeDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int? ParentCatalogTypeId { get; set; }
    }
}
