using Restful.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Restful.Service
{
    [ServiceContract]
    interface IRestService
    {
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Task<List<User>> GetAllUsers();

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare, Method = "POST", 
                    RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void InsertUser(User user);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare, Method = "DELETE",
                    RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        //TODO: receber somento um Id
        void DeleteUser(User user);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Bare, Method = "PUT",
                    RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        //TODO: receber somento um Id
        void UpdateUser(User user);

        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Task<User> GetLastRecordedUser();
    }
}
