using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiNetCoreBox.Models{
    
    [Table("Stack")]
    public class Stack{
    
    [Key]    
    public int Id { get; set; }
    public string Stacks { get; set; }

    }

}