using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Targv20Shop.Core.Dtos;
using Targv20Shop.Core.ServiceInterface;
using Targv20Shop.Data;
using Targv20Shop.Models.Cars;
using Targv20Shop.Models.Files;

namespace Targv20Shop.Controllers
{
    public class CarsController : Controller
    {

        private readonly Targv20ShopDbContext _context;
        private readonly ICarsService _carsService;
        private readonly IFileServices _fileService;

        public CarsController
            (
                Targv20ShopDbContext context,
                ICarsService carsService,
                IFileServices fileService
            )
        {
            _context = context;
            _carsService = carsService;
            _fileService = fileService;
        }

        [HttpGet]
        public IActionResult Index()

        {
            var result = _context.Cars
                .Select(x => new CarsListViewModel
                {
                    Id = x.Id,
                    Creator = x.Creator,
                    Name = x.Name,
                    DateCreated = x.DateCreated,
                    Price = x.Price,
                    CreatedAt = x.CreatedAt,
                    ModifiedAt = x.ModifiedAt
                });

            return View(result);
        }

        [HttpGet]
        public IActionResult Add()
        {
            CarsViewModel model = new CarsViewModel();

            return View("Edit", model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CarsViewModel model)
        {
            var dto = new CarsDto()
            {
                Id = model.Id,
                Creator = model.Creator,
                Name = model.Name,
                DateCreated = model.DateCreated,
                Price = model.Price,
                CreatedAt = model.CreatedAt,
                ModifiedAt = model.ModifiedAt,
                Files = model.Files,
                ExistingFilePaths = model.ExistingFilePaths
                .Select(x => new ExistingFilePathDto
                {
                    PhotoId = x.PhotoId,
                    FilePath = x.FilePath,
                    CarsId = x.CarsId
                }).ToArray()
            };

            var result = await _carsService.Add(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var cars = await _carsService.Edit(id);
            if (cars == null)
            {
                return NotFound();
            }

            var photos = await _context.ExistingFilePath
                .Where(x => x.CarsId == id)
                .Select(y => new ExistingFilePathViewModel
                {
                    FilePath = y.FilePath,
                    PhotoId = y.Id
                })
                .ToArrayAsync();


            var model = new CarsViewModel();

            model.Id = cars.Id;
            model.Creator = cars.Creator;
            model.Name = cars.Name;
            model.DateCreated = cars.DateCreated;
            model.Price = cars.Price;
            model.CreatedAt = cars.CreatedAt;
            model.ModifiedAt = cars.ModifiedAt;
            model.ExistingFilePaths.AddRange(photos);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CarsViewModel model)
        {
            var dto = new CarsDto()
            {
                Id = model.Id,
                Creator = model.Creator,
                Name = model.Name,
                DateCreated = model.DateCreated,
                Price = model.Price,
                CreatedAt = model.CreatedAt,
                ModifiedAt = model.ModifiedAt,
                Files = model.Files,
                ExistingFilePaths = model.ExistingFilePaths
                .Select(x => new ExistingFilePathDto
                {
                    PhotoId = x.PhotoId,
                    FilePath = x.FilePath,
                    CarsId = x.CarsId
                })
            };

            var result = await _carsService.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var cars = await _carsService.Delete(id);

            if (cars == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveImage(ExistingFilePathViewModel model)
        {
            var dto = new ExistingFilePathDto()
            {
                FilePath = model.FilePath
            };

            var image = await _fileService.RemoveImage(dto);
            if (image == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
