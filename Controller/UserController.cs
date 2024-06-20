using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto10_06
{
    public class UserController
    {
        private UserRepositor userRepositor;
        public UserController() {
            userRepositor = new UserRepositor();
        }

        public void Insert(User user) {
            userRepositor.Save(user);
        }

        public User Get(int id) {
            return userRepositor.Retrieve(id);
        }

        public List<User> Get() {
            return userRepositor.Retrieve();
        }

        public List<User> GetByUsername(string username) {
            return userRepositor.RetrieveByUsername(username);
        }

        public void Update(User user) {
            userRepositor.Update(user);
        }

        public void Delete(int id) {
            userRepositor.Delete(id);
        }
    }
}
