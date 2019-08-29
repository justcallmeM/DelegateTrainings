using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoLibrary
{
    //its up to me if I want to use a delegate like "MentionDiscount" with the initialization
    //or a Func, which desn't need an initialization (but it doesn't work with "out").
    public class ShoppingCartModel
    {
        public delegate void MentionDiscount(decimal subTotal); //definition for a delegate <- kind of like an interface.
        public List<ProductModel> Items { get; set; } = new List<ProductModel>();

        //passing in the arbitrary delegate method
        public decimal GenerateTotal(MentionDiscount mentionDiscount,
            Func<List<ProductModel>, decimal, decimal> calculateDiscountetTotal)
        {
            decimal subTotal = Items.Sum(x => x.Price);

            mentionDiscount(subTotal); // calling the method mentionDiscount and passing in the subTotal (loosly coupled, because genrateTotal doesnt know anything about mentionDiscount).

            return calculateDiscountetTotal(Items, subTotal);
        }
    }
}
