using System;
using System.Collections.Generic;
using GadgetHub.Domain.Entities;

namespace GadgetHub.Domain.Abstract
{
    public interface IGadgetsRepository
    {
        IEnumerable<Gadget> Gadgets { get; }
        void SaveGadget(Gadget gadget);

        Gadget DeleteGadget(int Id);
    }
}
