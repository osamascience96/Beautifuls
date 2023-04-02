using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beautifuls.Models
{
    public class Ratings
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }
    }
}