using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Promotions
{
    public interface IPromotion
    {

        Cart Calculate(Cart cart);
    }
}
