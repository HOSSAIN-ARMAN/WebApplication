using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jespar.Model.Model;
using Jespar.Repository.Repository;


namespace Jespar.BLL.BLL
{
    public class SalesManager
    {
        SalesRepository _salesRepository = new SalesRepository();
        public bool AddSales(Sales sales)
        {
            return _salesRepository.AddSales(sales);
        }
        public List<SalesDetails> GetAllSalesDetails()
        {
            return _salesRepository.GetAllSalesDetails();
        }
        public List<Sales> GetAll()
        {
            return _salesRepository.GetAll();
        }
    }
}
