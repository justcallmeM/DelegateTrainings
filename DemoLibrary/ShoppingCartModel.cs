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
        public decimal GenerateTotal(MentionDiscount mentionSubtotal, 
            Func<List<ProductModel>, decimal, decimal> calculateDiscountetTotal, //Func returns a value
            Action<string> tellUserWeAreDiscounting) //Action returns a void
        {
            decimal subTotal = Items.Sum(x => x.Price);

            mentionSubtotal(subTotal); // calling the method mentionDiscount and passing in the subTotal (loosly coupled, because genrateTotal doesnt know anything about mentionDiscount).

            tellUserWeAreDiscounting("We are applying your discount.");

            return calculateDiscountetTotal(Items, subTotal);
        }

        //delegates are great when we for example need to complete multiple methods in one method. We can either Alert the system as we do it here
        //or do multiple methods with multiple returns. But the returns are generated and processed inside that one method, which wraps all of the other methods.
    }
}
