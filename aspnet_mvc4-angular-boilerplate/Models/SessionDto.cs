using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspnet_mvc4_angular_boilerplate.Models
{
    public class SessionDto
    {

        public string AccessToken {get; set;}
        public int SessionId { get; set; }
        public DateTime ExpirationDate { get; set; }

        public static SessionDto fromEntity(Session s) {
            return new SessionDto
            {
                AccessToken = s.AccessToken,
                ExpirationDate = s.ExpirationDate,
                SessionId = s.SessionId
            };
        }

        public static ICollection<SessionDto> fromEntityCollection(ICollection<Session> s)
        {
            List<SessionDto> dtos = new List<SessionDto>();
            for (int i = 0; i < s.Count; i++ )
            {
                dtos.Add(SessionDto.fromEntity(s.ElementAt(i)));
            }
            return dtos;
        }

    }
}