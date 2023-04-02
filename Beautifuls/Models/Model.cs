using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beautifuls.Models
{
    public class Model
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public string DirPath { get; set; }
        public int Age { get; set; }
        public int Gender { get; set; }
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}