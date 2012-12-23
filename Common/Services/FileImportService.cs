using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;
using AIM.Data;
using AIM.Common.Types.AllClients;
namespace AIM.Common.Services {
  public class FileImportService {
    public static List<FileInfo> GetClientImportFiles(IClient client) {
      List<FileInfo> result = new List<FileInfo>();
      using( DomainContext ctx = new DomainContext() ) {
        Manager mgr = new Manager( ctx );
        ClientFileImportManager clientFileImportManager = new ClientFileImportManager( mgr );
        var imports = clientFileImportManager.GetClientFileImports( client );
        imports.Select( n => new FileInfo( n.ImportedFilePath ) ).ToList().ForEach( n => {
            result.Add( n );
        } );
      }
      return result;
    }
    public static List<AllClientsContact> GetAllClientsContactsFromFile( FileInfo file) {
      var result = new List<AllClientsContact>();
      var doc = XDocument.Load( file.FullName );
      var root = new XmlRootAttribute();      
      root.IsNullable = true;
      XmlSerializer serializer = new XmlSerializer(typeof(AllClientsContact),root);
      var clients = doc.Descendants( "AllClientsContact" ).Select( n => CommonService.FromXml( typeof( AllClientsContact ), n.ToString(),serializer ) as AllClientsContact);
      result.AddRange(clients.ToList());
      return result;
    }
    public static IClient GetClientFromImportFile( FileInfo file ) {
      IClient result = null;
      using( DomainContext ctx = new DomainContext() ) {
        Manager mgr = new Manager( ctx );
        ClientFileImportManager clientFileImportManager = new ClientFileImportManager( mgr );
        result = clientFileImportManager.GetClientFromImportFilename( file.Name );
      }
      return result;
    }
    public static void ClientImportPostProcess( FileInfo file, int imported, int rejected ) {
      using( DomainContext ctx = new DomainContext() ) {
        Manager mgr = new Manager( ctx );
        ClientFileImportManager clientFileImportManager = new ClientFileImportManager( mgr );
        clientFileImportManager.SaveClientFileImport( file.Name, imported, rejected );
      }
    }
    public static IClientFileImport GetClientFileImportFromFile( FileInfo file) {
      IClientFileImport result = null;
    
      using( DomainContext ctx = new DomainContext() ) {      
        Manager mgr = new Manager( ctx );
        ClientFileImportManager clientFileImportManager = new ClientFileImportManager( mgr );
        result = clientFileImportManager.GetClientFileImportByFilename( file.Name );
        result.Client = result.Client;
      }
      return result;
    }
  }
}
