using MovieStore.Models.Validators;
using System;
using System.ComponentModel.DataAnnotations;

namespace MovieStore.Models
{
    public class Customer
    {
        //Ao usar o ID o entity reconhece automaticamente como Primary Key]
        public int Id { get; set; }

        //Você consegue determinar as caracteristicas da tabela pelas annotations
        //Para mostrar a mensagem de erro que eu desejo
        [Required(ErrorMessage ="O nome é obrigatorioooooooo!!!")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
        
        //Aparecerá o nome que você colocar ao utilizar os razor For Ex: @Html.LabelFor, 
        [Display(Name = "Date of Birth")]
        //Adicionar Validação Custom
        [Min18IfAMember]
        public DateTime? Birth { get; set; }

        public MembershipType MembershipType { get; set; }
        //Ao usar o nome do objeto+id o entity framework reconhece como uma Foreign Key
        public byte MembershipTypeId { get; set; }
    }
}