using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalsManager : IRentalsService
    {
        IRentalsDal _rentalsDal;
        public RentalsManager (IRentalsDal rentalsDal)
        {
            _rentalsDal = rentalsDal;
        }
        public IResult Add(Rentals rental)
        {
            var result = CheckReturnDate(rental.CarId);
            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }
            _rentalsDal.Add(rental);
            return new SuccessResult(result.Message);

        }

        public IResult CheckReturnDate(int carId)
        {
            var resutl = _rentalsDal.GetRentalDetails(x => x.CarId == carId);
            //  if (result.Count > 0 && result.Count(x => x.ReturnDate == null) > 0)
            //{
            //    return new ErrorResult(Messages.RentalAddedError);
            //}
            //return new SuccessResult(Messages.RentalAdded);

            if (resutl.Count> 0 && resutl.Count(x => x.ReturnDate > DateTime.Now)>0)
            {
                return new ErrorResult(Messages.RentalAddedError);
            }

            return new SuccessResult(Messages.RentalAdded);
        }

        public IDataResult<List<Rentals>> GetAll()
        {
            return new SuccessDataResult<List<Rentals>>(_rentalsDal.GetAll());
        }

        public IDataResult<List<CarDetailDto>> GetRentalDetailsDto(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_rentalsDal.GetRentalDetails(x => x.CarId = carId));
        }

        public IResult UpdateReturnDate(int carId)
        {
            var result = _rentalsDal.GetAll();
            var updatedRentals = result.LastOrDefault();
            if (updatedRentals.ReturnDate!=null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
