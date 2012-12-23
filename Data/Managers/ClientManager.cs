
using System;

using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CodeSmith.Data.Rules;
using CodeSmith.Data.Rules.Validation;

namespace AIM.Data
{
    public partial class ClientManager
    {
        #region Query
        // A private class for lazy loading static compiled queries.
        private static partial class Query
        {
            internal static readonly Func<AIM.Data.DomainContext, IQueryable<AIM.Data.IClient>> GetActive =
                System.Data.Linq.CompiledQuery.Compile(
                    (AIM.Data.DomainContext db) =>
                        db.Client.Where(c => c.Active));
            internal static readonly Func<AIM.Data.DomainContext, IQueryable<AIM.Data.IClient>> GetAll =
                System.Data.Linq.CompiledQuery.Compile(
                    (AIM.Data.DomainContext db) =>
                        db.Client);
            internal static readonly Func<AIM.Data.DomainContext, string, AIM.Data.IClient> GetByCompany =
                System.Data.Linq.CompiledQuery.Compile(
                (AIM.Data.DomainContext db, string company) => db.Client.Where(c => c.Company.ToLower() == company.ToLower()).Single());
        }
        #endregion

        public IClient GetNewClient()
        {
          Guid id = Guid.NewGuid();
          IClient result = new Client {
            Id = id,
            ClientProperties = new ClientProperties { ClientId = id }
          };
            Context.Client.InsertOnSubmit(result as Client);
            return result;
        }

        public IQueryable<AIM.Data.IClient> GetActive()
        {
            if (Context.LoadOptions == null)
                return Query.GetActive.Invoke(Context);
            else
                return Entity.Where(n => n.Active).AsQueryable<IClient>();
        }

        public IQueryable<AIM.Data.IClient> GetAll()
        {
            if (Context.LoadOptions == null)
                return Query.GetAll.Invoke(Context);
            else
                return Entity.AsQueryable<IClient>();
        }
        public IClient GetByCompany(string company)
        {
            if (Context.LoadOptions == null)
                return Query.GetByCompany.Invoke(Context, company);
            else
                return Entity.Where(c => c.Company.ToLower() == company.ToLower()).Single();
        }
        public void DeleteClient(IClient client)
        {
            Context.Client.Single(n => n.Id == client.Id).IsDeleted = true;
            Context.SubmitChanges();
        }

    }
}