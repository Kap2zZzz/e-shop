using e_shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_shop.Concrete
{
    public class EFAskClientRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<AskClient> AskClients { get { return context.AskClients; } }

        public void SaveAsk(AskClient ask)
        {
            if (ask.AskClientID == 0)
            {
                ask.CreateDateTime = System.DateTime.Now;
                context.AskClients.Add(ask);
            }
            context.SaveChanges();
        }

        public AskClient DeleteAsk(int askId)
        {
            AskClient dbAsks = context.AskClients.Find(askId);
            if (dbAsks != null)
            {
                context.AskClients.Remove(dbAsks);
                context.SaveChanges();
            }
            return dbAsks;
        }
    }
}