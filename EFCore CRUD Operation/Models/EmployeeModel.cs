namespace EFCore_CRUD_Operation.Models
{
    public class EmployeeRequestModel
    {
        public int Id { get; set; }
        public string EmployeeCode { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string OfficeLocation { get; set; } = null!;

        public string Department { get; set; } = null!;
    }

    public class EmployeeResponseModel
    {
        public int Id { get; set; }
        public string EmployeeCode { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string OfficeLocation { get; set; } = null!;

        public string Department { get; set; } = null!;

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
