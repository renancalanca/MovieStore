using MovieStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        //Ao usar o ID o entity reconhece automaticamente como Primary Key
        public int Id { get; set; }
        
        //Você consegue determinar as caracteristicas da tabela pelas annotations
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }

        //Ao usar o nome do objeto+id o entity framework reconhece como uma Foreign Key
        public byte MembershipTypeId { get; set; }
    }
}