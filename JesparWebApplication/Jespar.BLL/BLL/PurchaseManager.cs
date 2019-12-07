using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jespar.Model.Model;
using Jespar.Repository.Repository;


namespace Jespar.BLL.BLL
{
    public class PurchaseManager
    {
        PurchaseRepository _purchaseRepository = new PurchaseRepository();
        public bool Add(Purchase purchase)
        {
            return _purchaseRepository.Add(purchase);
        }
        public List<PurchaseDetails> GetAll()
        {
            return _purchaseRepository.GetAll();
        }
        public List<Purchase> GetPurchaseReportAll()
        {
            return _purchaseRepository.GetPurchaseReportAll();
        }
    }
}
