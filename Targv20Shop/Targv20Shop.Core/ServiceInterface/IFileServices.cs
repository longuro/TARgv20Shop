﻿using System.Threading.Tasks;
using Targv20Shop.Core.Domain;
using Targv20Shop.Core.Dtos;

namespace Targv20Shop.Core.ServiceInterface
{
    public interface IFileServices : IApplicationService
    {
        string ProcessUploadedFile(ProductDto dto, Product product);
        string ProcessUploadedFile(CarsDto dto, Cars cars);
        Task<ExistingFilePath> RemoveImage(ExistingFilePathDto dto);
        Task<ExistingFilePath> RemoveImages(ExistingFilePathDto[] dto);
    }
}
