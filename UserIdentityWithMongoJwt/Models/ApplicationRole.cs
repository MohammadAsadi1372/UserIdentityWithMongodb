using AspNetCore.Identity.MongoDbCore.Models;
using System;

namespace UserIdentityWithMongoJwt.Models
{

    //Add any custom field for a role
    public class ApplicationRole : MongoIdentityRole
    {
    }

    //Add any custom field for a user
    public class ApplicationUser : MongoIdentityUser
    {
        public string Name { get; set; }


        public DateTime? Birthdate { get; set; }


        public string State { get; set; }

    }
}
