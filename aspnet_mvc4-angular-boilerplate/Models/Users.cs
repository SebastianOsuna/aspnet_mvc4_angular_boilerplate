using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using aspnet_mvc4_angular_boilerplate.Utils;

namespace aspnet_mvc4_angular_boilerplate.Models {

    public class User {

        public static string _SALT = "&^77/";

        private string _passwordDigest;

        public User()
        {
            Active = true;
            Sessions = new HashSet<Session>();
        }

        public long UserId { get; set; }

        [Required]
        public string Username
        {
            get
            {
                return _passwordDigest;
            }
            set
            {
                this._passwordDigest = BCrypt.HashPassword(value, _SALT);
            }
        }

        [Required]
        public string PasswordDigest { get; set; }

        public bool Active { get; set; }
        public ICollection<Session> Sessions { get; set; }
        
    }

    public class LoginModel {

        public string Username { get; set; }
        public string Password { get; set; }

    }

}