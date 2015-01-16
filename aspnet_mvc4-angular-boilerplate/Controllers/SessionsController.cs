using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using aspnet_mvc4_angular_boilerplate.Models;
using aspnet_mvc4_angular_boilerplate.Filters;

namespace aspnet_mvc4_angular_boilerplate.Controllers { 

    public class SessionsController : ApiController {

        private ApplicationContext db = new ApplicationContext();

        [AllowAnonymous]
        public object PostLogin(LoginModel user) {
            if (ModelState.IsValid) {
                IEnumerable<User> result = db.Users.Where(u => u.Username == user.Username).AsEnumerable();
                if (result.Count() == 1) {
                    User use = result.First();
                    bool auth = BCrypt.Net.BCrypt.Verify(user.Password, use.PasswordDigest);
                    if( auth )
                    {
                        Session newSession = new Session()
                        {
                            User = use,
                            AccessToken = use.Username
                        };
                    
                        result.First().Sessions.Add(newSession);
                        db.Sessions.Add(newSession);
                        db.SaveChanges();
                        return new { token = newSession.AccessToken, expirationDate = newSession.ExpirationDate };
                    }
                    
                } else {

                    User newUser = new User() {
                        Username = user.Username
                    };
                    newUser.SetPassword(user.Password);
                    db.Users.Add(newUser);
                    db.SaveChanges();
                }
            
            }

            // If we got this far, something failed
            throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.Unauthorized, 
                new { errors = new string[] { "login.badCredentials" } }));
        }

        public void DeleteLogout(string token)
        {
            IEnumerable<Session> sessions = db.Sessions.Where(s => s.AccessToken == token).AsEnumerable();
            foreach(Session s in sessions) {
                db.Sessions.Remove(s);
            }
            db.SaveChanges();
        }

        [HandleAuthentication]
        public ICollection<SessionDto> GetAvailableSessions(string username)
        {
            IQueryable<User> user = db.Users.Include("Sessions").Where(u => u.Username == username);
            return SessionDto.fromEntityCollection(user.First().Sessions);
        }

    }
}
