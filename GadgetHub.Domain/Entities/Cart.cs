using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GadgetHub.Domain.Entities
{
    public class CartLine
    {
        public Gadget Gadget { get; set; }
        public int Quantity { get; set; }
    }
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public IEnumerable<CartLine> Lines
        {
            get {  return lineCollection; }
        }

        public void AddItem(Gadget myGadget, int myQuantity)
        {
            CartLine line = lineCollection.Where(p => p.Gadget.Id == myGadget.Id).FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Gadget = myGadget,
                    Quantity = myQuantity
                });
            }
            else
            {
                line.Quantity += myQuantity;
            }
        }

        public void RemoveLine(Gadget myGadget)
        {
            lineCollection.RemoveAll(l => l.Gadget.Id == myGadget.Id);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Gadget.Price * e.Quantity);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }
    }
}
