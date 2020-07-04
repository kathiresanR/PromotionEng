using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine.Models
{
  public  interface IPromotionRepository
    {
        List<Promotion> GetActivePromotion();
       
    }
}
