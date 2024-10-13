using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace ASPProject.Models
{
    public class Student
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string midlename { get; set; }

        public string fullname
        {
            get { return string.Join(" ", new[] { firstname, lastname, midlename }.Where(x=> string.IsNullOrWhiteSpace(x) ==false && x.Trim().Length>0).ToArray()); }
        }

        [DataType(DataType.EmailAddress)]
        public string username { get; set; }

        [DataType(DataType.Password)]
        public string password { get; set; }

        [DataType(DataType.Date)]
        public DateTime? dob { get; set; }
        public int age
        {
            get
            {
                if (dob.HasValue)
                {
                    if(DateTime.Now.Month > dob.Value.Month) // simple
                    {
                        return DateTime.Now.Year - dob.Value.Year;
                    } else
                    {
                        return DateTime.Now.Year - dob.Value.Year - 1;
                    }
                } else {
                    return 0;
                }
            }
        }

        [DataType(DataType.Date)]
        public DateTime? date_enrolled { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? date_accepted { get; set; }
    }
}