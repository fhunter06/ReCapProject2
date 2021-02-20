using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConserns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        [ValidationAspect(typeof(RentalsValidator))]
        public IResult Add(Rentals rentals)
        {
            ValidationTool.Validate(new RentalsValidator(), rentals);

            _rentalsDal.Add(rentals);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rentals rentals)
        {
            _rentalsDal.Delete(rentals);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rentals>> GetAll()
        {
            return new SuccessDataResult<List<Rentals>>(_rentalsDal.GetAll());
            
        }

        public IDataResult<Rentals> GetById(int id)
        {
            
            return new SuccessDataResult<Rentals>(_rentalsDal.Get(I => I.Id == id));
        }

        public IDataResult<List<RentalsDetailDto>> GetRentalDetails(Expression<Func<Rentals, bool>> filter = null)
        {
            return new SuccessDataResult<List<RentalsDetailDto>>(_rentalsDal.GetCarDetails(filter), Messages.ReturnetRental);
        }

        public IResult Update(Rentals rentals)
        {
            _rentalsDal.Update(rentals);
            return new SuccessResult(Messages.UpdatedRental);
        }
    }
       
}
