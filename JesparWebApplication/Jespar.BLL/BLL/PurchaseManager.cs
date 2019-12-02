using Jespar.Model.Model;
using Jespar.Repository.Repository;
using System.Collections.Generic;

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
    }
}
