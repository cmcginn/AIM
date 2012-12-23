
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using CodeSmith.Data.Rules;
using CodeSmith.Data.Rules.Validation;

namespace AIM.Data {
  public partial class ClientFileImportManager {
    #region Query
    // A private class for lazy loading static compiled queries.
    private static partial class Query {
      internal static readonly Func<AIM.Data.DomainContext, IClient, IQueryable<IClientFileImport>> GetClientFileImports =
System.Data.Linq.CompiledQuery.Compile(
  ( AIM.Data.DomainContext db, IClient client ) =>
      db.ClientFileImport.Where( c => c.ClientId == client.Id & !c.Processed.HasValue ) );

      internal static readonly Func<AIM.Data.DomainContext, string, IClient> GetClientFromImportFilename =
        System.Data.Linq.CompiledQuery.Compile( ( AIM.Data.DomainContext db, string filename ) =>
          db.ClientFileImport.Single( n => n.ImportedFilePath.Contains( filename ) ).Client );
      internal static readonly Func<AIM.Data.DomainContext, string, IClientFileImport> GetClientFileImportByFilename =
  System.Data.Linq.CompiledQuery.Compile( ( AIM.Data.DomainContext db, string filename ) =>
    db.ClientFileImport.Single( n => n.ImportedFilePath.Contains( filename ) ) );
    }
    #endregion
    public IClient GetClientFromImportFilename( string filename ) {
      if( Context.LoadOptions == null )
        return Query.GetClientFromImportFilename.Invoke( Context, filename );
      else
        return Entity.Single( n => n.ImportedFilePath.Contains( filename ) ).Client;
    }
    public IQueryable<AIM.Data.IClientFileImport> GetClientFileImports( IClient client ) {
      if( Context.LoadOptions == null )
        return Query.GetClientFileImports.Invoke( Context, client );
      else
        return Entity.Where( n => n.ClientId == client.Id & !n.Processed.HasValue ).AsQueryable<AIM.Data.IClientFileImport>();
    }
    public void SaveClientFileImport( string filename, int imported, int rejected ) {
      var clientFileImport = Context.ClientFileImport.Single( n => n.ImportedFilePath.Contains( filename ) );
      clientFileImport.RecordsImported = imported;
      clientFileImport.RecordsFailed = rejected;
      clientFileImport.Processed = System.DateTime.Now;
      clientFileImport.LastUpdated = System.DateTime.Now;
      Context.SubmitChanges();
    }
    public IClientFileImport GetClientFileImportByFilename( string filename ) {

      if( Context.LoadOptions == null )
        return Query.GetClientFileImportByFilename( Context, filename );
      else
        return Entity.Single( n => n.ImportedFilePath.Contains( filename ) );
    }
  }
}