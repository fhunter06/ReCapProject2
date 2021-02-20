﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConserns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            

            return new ErrorResult(Messages.BrandInvalid);
        }
        public IResult Update(Brand brand)
        {
            if (brand.BrandName.Length >= 2)
            {
                _brandDal.Update(brand);
                return new SuccessResult(Messages.BrandUpdated);
            }

            return new ErrorResult(Messages.BrandInvalid);
        }

        public IResult Delete(Brand brand)
        {
            foreach (var _brand in _brandDal.GetAll())
            {
                if (_brand.BrandId == brand.BrandId)
                {
                    _brandDal.Delete(_brand);
                    return new SuccessResult(Messages.BrandDeleted);
                }
            }
            return new ErrorResult(Messages.BrandInvalid);
        }


        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandListed);
        }

        public IDataResult<Brand> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == brandId));
        }

      
    }
}
