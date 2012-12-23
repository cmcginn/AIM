using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AIM.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AIM.Common.Types;
using AIM.Common.Services;
using System.Xml.Linq;
using System.Diagnostics.Contracts;
using System.Collections.Specialized;
namespace AIM.Administration.Models
{

    #region Models
    public class ClientParametersObject
    {
        public virtual XElement GetClientParameters
        {
            get
            {
                XElement result = new XElement("Parameters");
                return result;
            }
        }
    }
    public class ClientType
    {
        int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        string _TypeName;

        public string TypeName
        {
            get { return _TypeName; }
            set { _TypeName = value; }
        }
    }
    public class ClientModel : IClient
    {
        #region IClient Members
        public Guid Id { get; set; }
        string _Email;
        [Required]
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        [Required]
        public int ImportTypeId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Active { get; set; }
        public XElement ClientParameters { get; set; }
        public ClientParametersObject ClientParametersObject { get; set; }
        public int AccountId { get; set; }
        public string ApiKey { get; set; }
        [Required]
        public string Company { get; set; }
        public ImportType ImportType { get; set; }
        public System.Data.Linq.EntitySet<Contact> ContactList { get; set; }
        public bool EnableUpdates { get; set; }
        public bool IsDeleted { get; set; }
        public System.Data.Linq.EntitySet<ClientFileImport> ClientFileImportList { get; set; }
        public ClientProperties ClientProperties { get; set; }
        string _AllClientsPassword;
        public virtual string AllClientsPassword
        {
            get { return _AllClientsPassword; }
            set { _AllClientsPassword = value; }
        }
        #endregion
    }
    public class NewClientModel : ClientModel
    {

        string _AllClientsPassword;
        [Required]
        public override string AllClientsPassword
        {
            get { return _AllClientsPassword; }
            set { _AllClientsPassword = value; }
        }

        string _GroupName;
        [Required]
        public string GroupName
        {
            get { return _GroupName; }
            set { _GroupName = value; }
        }
        string _Newsletter;
        [Required]
        public string Newsletter
        {
            get { return _Newsletter; }
            set { _Newsletter = value; }
        }

        string _Address;

        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        string _CityStateZip;

        public string CityStateZip
        {
            get { return _CityStateZip; }
            set { _CityStateZip = value; }
        }
        string _Phone;

        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }
        string _Fullname;

        public string Fullname
        {
            get { return _Fullname; }
            set { _Fullname = value; }
        }
        private string _Website;

        public string Website
        {
            get { return _Website; }
            set { _Website = value; }
        }


    }

    public class MindBodyParameters : ClientParametersObject
    {
        public MindBodyParameters() { }
        public MindBodyParameters(XElement clientParameters)
        {

            StudioID = clientParameters.Element("StudioID") != null ?
                clientParameters.Element("StudioID").Value : String.Empty;
            Sourcename = clientParameters.Element("Sourcename") != null ?
                clientParameters.Element("Sourcename").Value : String.Empty;
            Password = clientParameters.Element("Password") != null ?
                clientParameters.Element("Password").Value : String.Empty;

        }
        [Required(ErrorMessage = "The Studio ID Field is Required")]
        public string StudioID { get; set; }
        [Required]
        public string Sourcename { get; set; }
        [Required]
        public string Password { get; set; }

        public override XElement GetClientParameters
        {
            get
            {
                XElement value = new XElement("Parameters");
                value.Add(new XElement("StudioID", StudioID));
                value.Add(new XElement("Sourcename", Sourcename));
                value.Add(new XElement("Password", Password));
                return value;
            }
        }
    }
    #endregion

    #region Services
    public class ClientService
    {
        public List<ClientModel> GellAllClients()
        {
            List<ClientModel> result = null;
            using (DomainContext ctx = new DomainContext())
            {
                Manager mgr = new Manager(ctx);
                ClientManager clientManager = new ClientManager(mgr);
                ImportTypeManager importTypeManager = new ImportTypeManager(mgr);
                result = clientManager.GetAll().Select(n => new ClientModel
                {
                    Id = n.Id,
                    IsDeleted = n.IsDeleted,
                    AccountId = n.AccountId,
                    Active = n.Active,
                    EnableUpdates = n.EnableUpdates,
                    ApiKey = n.ApiKey,
                    Company = n.Company,
                    Created = n.Created,
                    Updated = n.Updated,
                    ImportTypeId = n.ImportTypeId,
                    ImportType = importTypeManager.GetByKey(n.ImportTypeId),
                    ClientParameters = n.ClientParameters,
                    ClientParametersObject = n.ImportTypeId == 1 ? new MindBodyParameters(n.ClientParameters) : new ClientParametersObject()
                }).ToList();

            }
            return result;
        }
        public ClientModel GetClientModelByID(Guid ID)
        {
            ClientModel result = null;
            using (DomainContext ctx = new DomainContext())
            {
                Manager mgr = new Manager(ctx);
                ClientManager clientManager = new ClientManager(mgr);
                ImportTypeManager importTypeManager = new ImportTypeManager(mgr);
                var client = clientManager.GetByKey(ID);
                if (client != null)
                {
                    result = new ClientModel
                    {
                        Id = client.Id,
                        AccountId = client.AccountId,
                        EnableUpdates = client.EnableUpdates,
                        Active = client.Active,
                        ApiKey = client.ApiKey,
                        Company = client.Company,
                        Created = client.Created,
                        Updated = client.Updated,
                        ImportTypeId = client.ImportTypeId,
                        ImportType = importTypeManager.GetByKey(client.ImportTypeId),
                        ClientParameters = client.ClientParameters,
                        ClientParametersObject = client.ImportTypeId == 1 ? new MindBodyParameters(client.ClientParameters) : new ClientParametersObject()
                        
                    };
                    if (client.ClientProperties != null)
                    {
                        result.Email = client.ClientProperties.AllClientsUsername;
                        result.AllClientsPassword = client.ClientProperties.AllClientsPassword;
                    }
                }
            }
            return result;
        }
        ClientParametersObject GetClientParametersObject(ClientModel model, NameValueCollection requestParameters)
        {
            ClientParametersObject result = new ClientParametersObject();
            if (model.ImportTypeId == 1)
            {
                MindBodyParameters parameters = new MindBodyParameters();
                parameters.StudioID = requestParameters["ClientParametersStudioID"];
                parameters.Sourcename = requestParameters["ClientParametersSourcename"];
                parameters.Password = requestParameters["ClientParametersPassword"];
                result = parameters;
            }
            return result;
        }
        public void SaveClient(ClientModel model, NameValueCollection requestParameters)
        {
            using (DomainContext ctx = new DomainContext())
            {
                Manager mgr = new Manager(ctx);
                ClientManager clientManager = new ClientManager(mgr);



                var existing = clientManager.GetByKey(model.Id);
                
               
                if (existing != null)
                {
                    if (existing.ClientProperties == null)
                    {
                        existing.ClientProperties = new ClientProperties();
                    }
                    existing.ClientProperties.AllClientsUsername = model.Email;
                    existing.ClientProperties.AllClientsPassword = model.AllClientsPassword;
                    existing.AccountId = model.AccountId;
                    existing.EnableUpdates = model.EnableUpdates;
                    existing.Active = model.Active;
                    existing.ApiKey = model.ApiKey;
                    existing.Company = model.Company;
                    existing.ClientParameters = GetClientParametersObject(model, requestParameters).GetClientParameters;
                    ctx.SubmitChanges();
                }
            }
        }
        public List<IImportType> GetAllClientTypes()
        {
            List<IImportType> result = null;
            using (DomainContext ctx = new DomainContext())
            {
                Manager mgr = new Manager(ctx);
                ImportTypeManager importTypeManager = new ImportTypeManager(mgr);
                result = importTypeManager.GetAll().ToList();
            }
            return result;
        }
        public void CreateNewClient(NewClientModel newClientModel, NameValueCollection requestParameters)
        {
            if (newClientModel.ImportTypeId < 1)
                throw new System.Exception("You must select an Import Type");

            if (String.IsNullOrEmpty(newClientModel.GroupName))
                throw new System.Exception("You must select a Group Name");

            newClientModel.ClientParametersObject = GetClientParametersObject(newClientModel, requestParameters);

            XElement result = AllClientsService.CreateAccount(newClientModel.Email, newClientModel.AllClientsPassword, newClientModel.GroupName, newClientModel.Newsletter, newClientModel.Fullname, newClientModel.Company, newClientModel.Address, newClientModel.CityStateZip, newClientModel.Phone, newClientModel.Website, newClientModel.ImportTypeId, newClientModel.EnableUpdates, newClientModel.Active, newClientModel.ClientParametersObject.GetClientParameters);
            if (result.Descendants("errors").Count() > 0)
                throw new AIM.Common.AccountSetupException(result.Elements("errors").First().Value);


        }
        public void DeleteClient(Guid Id)
        {
            using (DomainContext ctx = new DomainContext())
            {
                Manager mgr = new Manager(ctx);
                ClientManager clientManager = new ClientManager(mgr);
                var existing = clientManager.GetByKey(Id);
                if (existing != null)
                {
                    clientManager.DeleteClient(existing);
                    ctx.SubmitChanges();
                }
            }
        }
        public object GetClientParametersObject(ClientModel model)
        {
            object result = null;
            switch (model.ImportTypeId)
            {
                case 1:
                    result = new MindBodyParameters
                    {
                        StudioID = model.ClientParameters.Element("StudioID").Value,
                        Sourcename = model.ClientParameters.Element("Sourcename").Value,
                        Password = model.ClientParameters.Element("Password").Value
                    };
                    break;
                default:
                    break;
            }
            return result;
        }
        public object GetClientParametersObject(int importType)
        {
            return new MindBodyParameters();
        }
    }
    #endregion

    #region Validation
    #endregion

}