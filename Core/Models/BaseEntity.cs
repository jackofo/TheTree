//using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TheTree_Core.Models
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime DateOfChange { get; set; }
    }
}
