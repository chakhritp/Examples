using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Restful.Service.Entities;
using Restful.MongoDB;

namespace Restful.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class RestService : IRestService
    {
        public async Task<List<User>> GetAllUsers()
        {
            UserData data = new UserData();

            return await data.GetAllUsers();
        }

        public async Task<User> GetLastRecordedUser()
        {
            UserData data = new UserData();

            return await data.GetLastRecordedUser();
        }

        public void InsertUser(User user)
        {
            UserData data = new UserData();

            data.InsertUser(user);
        }

        public void DeleteUser(User user)
        {
            UserData data = new UserData();

            data.DeleteUser(user);
        }

        public void UpdateUser(User user)
        {
            UserData data = new UserData();

            data.UpdateUser(user);
        }
    }
}
