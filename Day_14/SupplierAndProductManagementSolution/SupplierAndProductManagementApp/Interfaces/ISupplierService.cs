using SupplierAndProductManagementApp.Models.DTOs;
using SupplierAndProductManagementApp.Models;

namespace SupplierAndProductManagementApp.Interfaces
{
    public interface ISupplierService
    {

        List<Supplier> GetAllSuppliers();

        Supplier AddANewSupplier(Supplier supplier);
        Supplier UpdatePhone(SupplierPhoneDTO supplier);


    }
}
