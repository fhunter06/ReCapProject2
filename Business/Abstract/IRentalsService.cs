using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalsService
    {
       
        IResult Add(Rentals rental);
        IResult Delete (Rentals rentals);
        IResult Update(Rentals rentals);
        IDataResult<List<Rentals>> GetAll();
        IDataResult<Rentals> GetById(int id);

        IDataResult<List<RentalsDetailDto>> GetRentalDetails(Expression<Func<Rentals, bool>> filter = null);
    }

    
}
