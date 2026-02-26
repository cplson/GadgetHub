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
    }
}
