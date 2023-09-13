using SupplierAndProductManagementApp.Interfaces;
using SupplierAndProductManagementApp.Models;

namespace SupplierAndProductManagementApp.Repositories
{
    public class SupplierRepository : IRepository<int, Supplier>
    {


        private readonly ApplicationContext _context;

        public SupplierRepository(ApplicationContext context)
        {
            _context = context;
        }
        public Supplier Add(Supplier item)
        {
            // throw new NotImplementedException();
            _context.suppliers.Add(item);
            _context.SaveChanges();
            return item;


        }

        public Supplier Delete(int key)
        {
            //throw new NotImplementedException();
            var supplier = Get(key);
            if (supplier != null)
            {
                _context.suppliers.Remove(supplier);
                _context.SaveChanges();
                return supplier;
            }
            return null;

        }

        public Supplier Get(int key)
        {
            //throw new NotImplementedException();
            var supplier = _context.suppliers.FirstOrDefault(sup => sup.Id == key);
            return supplier;
        }

        public List<Supplier> GetAll()
        {
            // throw new NotImplementedException();
            return _context.suppliers.ToList();

        }
        public Supplier Update(Supplier item)
        {
            // throw new NotImplementedException();
            _context.Entry<Supplier>(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return item;
        }
    }
}
