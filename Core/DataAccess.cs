using Core.DataBase;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;

namespace Core
{
    public class DataAccess
    {

        public static List<User> GetUsers() => PassLockEntities.GetContext().Users.ToList();
        public static List<Role> GetRoles() => PassLockEntities.GetContext().Roles.ToList();
        public static List<Login> GetLogins() => PassLockEntities.GetContext().Logins.ToList();

        public static Role GetRole(string name) => GetRoles().FirstOrDefault(x => x.name == name);

        public static User GetUser(string login, string password)
        {
            return GetUsers().FirstOrDefault(x => x.login == login && x.password == password);
        }

        public static void SaveUser(User user)
        {
            if (user.id == 0)
                PassLockEntities.GetContext().Users.Add(user);

            PassLockEntities.GetContext().SaveChanges();
        }

        public static void SaveLogin(Login login)
        {
            if(login.id == 0) 
                PassLockEntities.GetContext().Logins.Add(login);

            PassLockEntities.GetContext().SaveChanges();
        }

        public static void RemoveLogin(Login login)
        {
            if (login.id != 0)
                PassLockEntities.GetContext().Logins.Remove(login);
            PassLockEntities.GetContext().SaveChanges();
        }
    }
}
