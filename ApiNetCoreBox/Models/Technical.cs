using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiNetCoreBox.Models{

    [Table("Technicals")]
    public class Technical{

        [Key]        
        public int Id { get; set; }

        [Required(ErrorMessage="Este Campo é Obrigatório!")]
        public string Name { get; set; }

        [Required(ErrorMessage="Este Campo é Obrigatório!")]
        public string CPF {get; set;}


        [Required(ErrorMessage="Este Campo é Obrigatório!")]
        [EmailAddress]
        [RegularExpression(".+\\@.+\\..+",ErrorMessage = "Informe um email válido...")]
        public string Email { get; set; }


        [Required(ErrorMessage="Este Campo é Obrigatório!")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime BirthDate {get; set;}


        [Required(ErrorMessage="Este Campo é Obrigatório!")]
        public string Address { get; set; }


        [Required(ErrorMessage="Este Campo é Obrigatório!")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime ChangeDate { get; set; }


        [Required(ErrorMessage="Este Campo é Obrigatório!")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime CreateDate { get; set; }

        public virtual List<Stack> Stacks {get; set;}



    }

}