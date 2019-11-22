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
    }
}
