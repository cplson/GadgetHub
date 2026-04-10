using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GadgetHub.Domain.Entities;
using GadgetHub.Domain.Abstract;

namespace GadgetHub.Domain.Concrete
{
    public class EFGadgetRepository : IGadgetsRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Gadget> Gadgets
        {
            get { return context.Gadgets; }
        }

        public void SaveGadget(Gadget gadget)
        {
            if (gadget.Id == 0)
            {
                context.Gadgets.Add(gadget);
            }
            else
            {
                Gadget dbEntry = context.Gadgets.Find(gadget.Id);

                if (dbEntry != null)
                {
                    dbEntry.Name = gadget.Name;
                    dbEntry.Description = gadget.Description;
                    dbEntry.Price = gadget.Price;
                    dbEntry.Brand = gadget.Brand;
                    dbEntry.Category = gadget.Category;
                }
            }
            context.SaveChanges();
        }

        public Gadget DeleteGadget(int Id)
        {
            Console.WriteLine("EF Id: ", Id);

            Gadget dbEntry = context.Gadgets.Find(Id);
            if (dbEntry != null)
            {
                context.Gadgets.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
