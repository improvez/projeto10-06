using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto10_06
{
    public class UserRepositor
    {
        public void Save(User user) {
            user.Id = this.GetNextId();
            DataSet.Users.Add(user);
        }

        public User Retrieve(int id) {
            return DataSet.Users.FirstOrDefault(u => u.Id == id);
        }

        public List<User> Retrieve() {
            return DataSet.Users;
        }

        public List<User> RetrieveByUsername(string username) {
            return DataSet.Users.Where(u => u.Username.Contains(username)).ToList();
        }

        public void Update(User user) {
            var existingUser = Retrieve(user.Id);
            if (existingUser != null) {
                existingUser.Username = user.Username;
                existingUser.Email = user.Email;
            }
        }

        public void Delete(int id) {
            var user = Retrieve(id);
            if (user != null) {
                DataSet.Users.Remove(user);
            }
        }

        private int GetNextId() {
            return DataSet.Users.Any() ? DataSet.Users.Max(u => u.Id) + 1 : 1;
        }
    }
}
