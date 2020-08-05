using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Promotions
{
    public class ComboOffer : IPromotion
    {
        public IEnumerable<char> ComboSku { get; private set; }
        public decimal FlatPrice { get; private set; }

        public ComboOffer(IEnumerable<char> comboSku, decimal flatAmount)
        {
            ComboSku = comboSku;
            FlatPrice = flatAmount;
        }

        public Cart Calculate(Cart cart)
        {
            throw new NotImplementedException();
        }
    }
}
