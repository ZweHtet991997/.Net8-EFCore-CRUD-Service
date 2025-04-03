using AppDbContext;
using EFCore.BulkExtensions;
using EFCore_CRUD_Operation.Mapper;
using EFCore_CRUD_Operation.Models;

namespace EFCore_CRUD_Operation.Services
{
    public class EmplyeeServices
    {
        private readonly EFDbContext _context;

        public EmplyeeServices(EFDbContext context)
        {
            _context = context;
        }

        #region SingleOperations
        public async Task<bool> CreateEmployee(EmployeeRequestModel model)
        {
            try
            {
                await _context.AddAsync(model.ToEntity());
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateEmployee(EmployeeRequestModel model)
        {
            try
            {
                var employee = await _context.TblEmployees.FindAsync(model.Id);
                if (employee == null) return false;

                _context.Update(model.ToEntity(employee));
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<EmployeeResponseModel>> GetEmployeeList()
        {
            try
            {
                List<EmployeeResponseModel> employeeListResponseModel = new List<EmployeeResponseModel>();
                var employeeList = await _context.TblEmployees.Select(x => new EmployeeResponseModel
                {
                    Id = x.Id,
                    EmployeeCode = x.EmployeeCode,
                    FullName = x.FullName,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    OfficeLocation = x.OfficeLocation,
                    Department = x.Department,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate
                }).ToListAsync();
                employeeListResponseModel = employeeList;
                return employeeListResponseModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            try
            {
                var employee = await _context.TblEmployees.FindAsync(id);
                if (employee == null) return false;

                _context.TblEmployees.Remove(employee);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region BulkOperations

        public async Task<bool> BulkCreateEmployeeAsync(List<EmployeeRequestModel> employeeList)
        {
            try
            {
                await _context.BulkInsertAsync(employeeList.ToListEntity());
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> BulkUpdateEmployeeAsync(List<EmployeeRequestModel> employeeList)
        {
            try
            {
                await _context.BulkUpdateAsync(employeeList.ToListEntity());
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> BulkDeleteEmployeeAsync(string department)
        {
            try
            {
                var employeeToDelete = await _context.TblEmployees
                    .Where(x => x.Department == department).ToListAsync();

                if (employeeToDelete.Count > 0)
                {
                    await _context.BulkDeleteAsync(employeeToDelete);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
    }
}
