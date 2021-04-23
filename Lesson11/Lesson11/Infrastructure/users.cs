using lesson11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lesson11.Infrastructure {
    public class Users {
        private  static List<User> users;
         

        public static List<User> GetUsers() {
            users  = new List<User>();
            users.Add(new User { Fullname = "Peter Nielsen", Username = "peter", Password = "p3tr", Age = 24 });
            users.Add(new User { Fullname = "Thomas Larsen", Username = "tmlar", Password = "tmlar", Age = 32 });
            users.Add(new User { Fullname = "Vibeke Hansen", Username = "vibe", Password = "vibe", Age = 22 });
            users.Add(new User { Fullname = "Susan Olsen", Username = "suol", Password = "susanol", Age = 34 });
            return users;
        }

        public static bool UsernameIsUnique(string username) {
            List<User> users = GetUsers();
            var queryResult = from User in users
                              where User.Username == username
                              select users;

            //if (queryResult.ToList().Count > 0) {
            //    return false;
            //}
            //else {
            //    return true;
            //}

            // shorter
            return queryResult.ToList().Count == 0;

        }
    }
}