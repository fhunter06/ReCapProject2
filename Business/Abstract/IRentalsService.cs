using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalsService
    {
        IDataResult<List<Rentals>> GetAll();
        IDataResult<List<CarDetailDto>> GetRentalDetailsDto(int carId);
        IResult Add(Rentals rental);
        IResult CheckReturnDate(int carId);
        IResult UpdateReturnDate(int carId);
    }

    
}
