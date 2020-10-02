using Microsoft.EntityFrameworkCore;
using Something.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Something.Persistence
{
    public class SomethingElsePersistence : ISomethingElsePersistence
    {
        private AppDbContext ctx;

        public SomethingElsePersistence(AppDbContext ctx)
        {
            this.ctx = ctx;
        }

        public void SaveSomethingElse(SomethingElse somethingElse)
        {
            ctx.SomethingElses.Add(somethingElse);
            ctx.SaveChanges();
        }

        public List<Domain.Models.SomethingElse> GetSomethingElseList()
        {
            return ctx.SomethingElses.ToList();
        }

        public List<Domain.Models.SomethingElse> GetSomethingElseIncludingSomethingList()
        {
            return ctx.SomethingElses.Include(s => s.Somethings).ToList();
        }

        public Domain.Models.SomethingElse UpdateSomethingElseByIdAddSomething(int id, Domain.Models.Something something)
        {
            var somethingElse = ctx.SomethingElses.Include(s => s.Somethings).Where(r => r.Id == id).FirstOrDefault();
            if (somethingElse == null) throw new InvalidOperationException("SomethingElse does not exist");
            somethingElse.Somethings.Add(something);
            ctx.Update(somethingElse);
            ctx.SaveChanges();
            return somethingElse;
        }
    }
}
