using System;
using System.Collections.Generic;
using System.Text;

namespace TheTree_Core.Models
{
	public class Person : BaseEntity
	{
		//[Required]
		public string Name;
		//[Required]
		public string Surname;
		public Relationship ParenthoodId;
	}
}