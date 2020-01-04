//using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TheTree_Core.Models
{
    public class BaseEntity
    {
		[Key]
        public int Id { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime DateOfChange { get; set; }
    }
}
