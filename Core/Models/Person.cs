using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheTree_Core.Models
{
	public class Person : BaseEntity
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public string Surname { get; set; }
		
		public Relationship Parenthood { get; set; }
	}
}