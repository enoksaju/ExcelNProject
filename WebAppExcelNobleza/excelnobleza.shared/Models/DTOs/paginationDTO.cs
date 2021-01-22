using System;
using System.Collections.Generic;
using System.Text;

namespace excelnobleza.shared.Models.DTOs
{
public 	class paginationDTO
	{
		public int Page { get; set; } = 1;
		public int QuantityPerPage { get; set; } = 10;
	}
}
