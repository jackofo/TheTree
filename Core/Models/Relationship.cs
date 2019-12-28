using System;
using System.Collections.Generic;
using System.Text;

namespace TheTree_Core.Models
{
	public class Relationship : BaseEntity
	{
		//[Required]
		public Person HusbandId;
		//[Required]
		public Person WifeId;
		public bool IsActual; //current state of marriage -> false - divorced; true - ?actual?
	}
}
