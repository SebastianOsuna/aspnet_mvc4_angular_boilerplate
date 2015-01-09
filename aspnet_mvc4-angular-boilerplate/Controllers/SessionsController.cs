using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using aspnet_mvc4_angular_boilerplate.Models;

namespace aspnet_mvc4_angular_boilerplate.Controllers {

    //private SessionsContext sessions = new SessionsContext();
    
    
    public class SessionsController : ApiController {

        private ApplicationContext db = new ApplicationContext();

        [AllowAnonymous]
        public object PostLogin(LoginModel user) {
            if (ModelState.IsValid) {
                // TODO: BCrypt password
                IEnumerable<User> result = db.Users.Where(u => u.Username == user.Username && u.PasswordDigest == user.Password)
                    .AsEnumerable();
                if (result.Count() == 1) {
                    User use = result.First();
                    Session newSession = new Session()
                    {
                        User = use,
                        AccessToken = use.Username
                    };
                    
                    result.First().Sessions.Add(newSession);
                    db.Sessions.Add(newSession);
                    db.SaveChanges();
                    return new { token = newSession.AccessToken, expirationDate = newSession.ExpirationDate };
                } else {

                    User newUser = new User() {
                        Username = user.Username,
                        PasswordDigest = user.Password
                    };
                    db.Users.Add(newUser);
                    db.SaveChanges();
                }
            
            }

            // If we got this far, something failed
            throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.Unauthorized, 
                new { errors = new string[] { "login.badCredentials" } }));
        }

        public ICollection<SessionDto> GetAvailableSessions(string username)
        {
            IQueryable<User> user = db.Users.Include("Sessions").Where(u => u.Username == username);
            return SessionDto.fromEntityCollection(user.First().Sessions);
        }

    }
}
