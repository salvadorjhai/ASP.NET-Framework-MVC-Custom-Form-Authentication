using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPProject
{
    public static class UserList
    {
        public static Dictionary<string, string[]> user = new Dictionary<string, string[]>() { 
            { "user1", ["admin","page-01","page-02"] },
            { "user2", ["editor"] }, 
            { "user3", ["viewer"] }, 
            { "user4", ["viewer","validator"] } };

    }
}