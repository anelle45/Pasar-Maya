﻿namespace Pasar_Maya_Api.Models
{
	public class UserArea
	{
        public string UserId { get; set; }
		public int AreaId { get; set; }
		public User User { get; set; }
		public Area Area { get; set; }
	}
}
