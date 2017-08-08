using MongoDB.Driver;
using Restful.MongoDB.Helpers;
using Restful.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restful.MongoDB
{
    public class UserData
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _db;
        protected static IMongoCollection<User> _collection;

        /// <summary>
        /// Get all users from database
        /// </summary>
        /// <returns>list of users</returns>
        public async Task<List<User>> GetAllUsers()
        {
            var users = await Task.Run(() => _collection.Find(t => true).ToListAsync());

            return users;
        }
        public async Task<User> GetLastRecordedUser()
        {
            var insertedUser = await Task.Run(() => _collection.Find(t => true)
                                         .Sort(new SortDefinitionBuilder<User>().Descending("$natural"))
                                         .FirstOrDefaultAsync()).ConfigureAwait(false);

            return insertedUser;
        }

        /// <summary>
        /// Persist a new user on database 'User'
        /// </summary>
        /// <param name="user">User data</param>
        public async void InsertUser(User user)
        {
            AutoIncrementId id = new AutoIncrementId();

            User lastUserRecordedUser = await id.GenerateId(_collection);
            user.Id = lastUserRecordedUser == null ? user.Id = 1 : user.Id = (lastUserRecordedUser.Id + 1);

            await _collection.InsertOneAsync(user);
        }
        /// <summary>
        /// Remove an user from database 'User'
        /// </summary>
        /// <param name="user">User data</param>
        public async void DeleteUser(User user)
        {
            await _collection.DeleteOneAsync(Builders<User>.Filter.Eq("Id", user.Id));
        }
        /// <summary>
        /// Update an user from database 'User'
        /// </summary>
        /// <param name="user">User data</param>
        public async void UpdateUser(User user)
        {
            var filter = Builders<User>.Filter.Eq("Id", user.Id);
            var update = Builders<User>.Update
                                       .Set("Name", user.Name)
                                       .Set("Email", user.Email)
                                       .Set("Address", user.Address);

            await _collection.UpdateOneAsync(filter, update);
        }

        /// <summary>
        /// constructor to make connection
        /// </summary>
        public UserData()
        {
            ConnectWithMongoDb();
        }

        /// <summary>
        /// Start the connection with the database and set as static
        /// </summary>
        private void ConnectWithMongoDb()
        {
            _client = new MongoClient();
            _db = _client.GetDatabase("RestfulDB");
            _collection = _db.GetCollection<User>("User");
        }
    }
}
