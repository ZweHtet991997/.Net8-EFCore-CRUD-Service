﻿using EFCore_CRUD_Operation.Models;

namespace EFCore_CRUD_Operation.Mapper
{
    public static class EntityMapper
    {
        public static TblEmployee ToEntity(this EmployeeRequestModel model)
        {
            return new TblEmployee
            {
                EmployeeCode = model.EmployeeCode,
                FullName = model.FullName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                OfficeLocation = model.OfficeLocation,
                Department = model.Department,
                CreatedDate = DateTime.Now

            };
        }

        public static TblEmployee ToEntity(this EmployeeRequestModel model, TblEmployee entity)
        {
            entity.EmployeeCode = model.EmployeeCode;
            entity.FullName = model.FullName;
            entity.Email = model.Email;
            entity.PhoneNumber = model.PhoneNumber;
            entity.OfficeLocation = model.OfficeLocation;
            entity.Department = model.Department;
            entity.UpdatedDate = DateTime.Now;
            return entity;
        }
    }
}
