using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ReviewsProject.Data.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string EmailAddress { get; set; }

        public int MarketUID { get; set; }

        public string FirstName { get; set; }

        public DateTime? WeddingDay { get; set; }

        public bool Validated { get; set; }
    }
}