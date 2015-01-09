using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspnet_mvc4_angular_boilerplate.Models {

    public class Session {

        public Session() {
            this.ExpirationDate = DateTime.Now.AddHours(2);
            // TODO: Generate token
        }

        public int SessionId { get; set;  }

        public long UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        public string AccessToken { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }
    }

}