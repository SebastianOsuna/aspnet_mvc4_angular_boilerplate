using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnet_mvc4_angular_boilerplate.Models {

    public class User {

        public User()
        {
            Active = true;
            Sessions = new HashSet<Session>();
        }

        public long UserId { get; set; }

        [Required]
        public string Username { get; set; }

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