using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheTree_Core.Models
{
	public class Relationship : BaseEntity
	{
		[Required]
		public Person Husband;
		[Required]
		public Person Wife;
		[Required]
		public bool IsActual; //current state of marriage -> false - divorced; true - ?actual?
	}
}
