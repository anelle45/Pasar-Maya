namespace Pasar_Maya_Api.Models
{
	public class CommodityArea
	{
        public int CommodityId { get; set; }
		public int AreaId { get; set; }
		public Commodity Commodity { get; set; }
		public Area Area { get; set; }
	}
}
