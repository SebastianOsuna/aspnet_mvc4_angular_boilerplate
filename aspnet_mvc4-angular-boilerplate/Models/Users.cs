using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BCrypt.Net;

namespace aspnet_mvc4_angular_boilerplate.Models {

    

    public class User {

        public const string SALT = "&^77/";    

        private string _passwordDigest;

        public User()
        {
            Active = true;
            Sessions = new HashSet<Session>();
        }

        public long UserId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string PasswordDigest 
        {
            get
            {
                return _passwordDigest;
            }
            private set
            {
                this._passwordDigest = value;
            }
        }

        public bool Active { get; set; }
        public ICollection<Session> Sessions { get; set; }

        public void SetPassword(string password)
        {
            this._passwordDigest = BCrypt.Net.BCrypt.HashString(password, 12);
        }
        
    }

    public class LoginModel {

        public string Username { get; set; }
        public string Password { get; set; }

    }

}