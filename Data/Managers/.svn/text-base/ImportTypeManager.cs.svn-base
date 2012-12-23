
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CodeSmith.Data.Rules;
using CodeSmith.Data.Rules.Validation;

namespace AIM.Data
{
    public partial class ImportTypeManager
    {       
        #region Query
        // A private class for lazy loading static compiled queries.
        private static partial class Query
        {
            internal static Func<AIM.Data.DomainContext,IQueryable<AIM.Data.IImportType>> GetAll = 
                 System.Data.Linq.CompiledQuery.Compile(
                 (AIM.Data.DomainContext db) =>
                      db.ImportType);
        } 
        #endregion

        public IQueryable<AIM.Data.IImportType> GetAll()
        {
            if (Context.LoadOptions == null)
                return Query.GetAll.Invoke(Context);
            else
                return Entity.AsQueryable<IImportType>();
        }
    }
}