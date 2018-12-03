using MovieStore.Models;
using MovieStore.Models.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieStore.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatorioooooooo!!!")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        //[Min18IfAMember]
        public DateTime? Birth { get; set; }

        public byte MembershipTypeId { get; set; }
    }
}