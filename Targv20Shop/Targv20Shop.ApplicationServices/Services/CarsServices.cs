using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Targv20Shop.Core.Domain;
using Targv20Shop.Core.Dtos;
using Targv20Shop.Core.ServiceInterface;
using Targv20Shop.Data;

namespace Targv20Shop.ApplicationServices.Services
{
    public class CarsServices : ICarsService
    {
        private readonly Targv20ShopDbContext _context;
        private readonly IFileServices _file;


        public CarsServices
            (
                Targv20ShopDbContext context,
                IFileServices file
            )
        {
            _context = context;
            _file = file;
        }

        public async Task<Cars> Edit(Guid id)
        {
            var result = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<Cars> Add(CarsDto dto)
        {
            Cars cars = new Cars();


            cars.Id = Guid.NewGuid();
            cars.Creator = dto.Creator;
            cars.Name = dto.Name;
            cars.DateCreated = dto.DateCreated;
            cars.Price = dto.Price;
            cars.CreatedAt = DateTime.Now;
            cars.ModifiedAt = DateTime.Now;
            _file.ProcessUploadedFile(dto, cars);

            await _context.Cars.AddAsync(cars);
            await _context.SaveChangesAsync();

            return cars;
        }

        public async Task<Cars> Update(CarsDto dto)
        {
            Cars cars = new Cars();


            cars.Id = dto.Id;
            cars.Creator = dto.Creator;
            cars.Name = dto.Name;
            cars.DateCreated = dto.DateCreated;
            cars.Price = dto.Price;
            cars.CreatedAt = dto.CreatedAt;
            cars.ModifiedAt = dto.ModifiedAt;

            _file.ProcessUploadedFile(dto, cars);

            _context.Cars.Update(cars);
            await _context.SaveChangesAsync();

            return cars;
        }

        public async Task<Cars> Delete(Guid id)
        {
            var cars = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.Cars.Remove(cars);
            await _context.SaveChangesAsync();



            return cars;
        }



    }
}
