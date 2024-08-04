﻿namespace SignalRWebUI.Dtos.ProductDtos
{
	public class ResultProductDto
	{
		public int ProductID { get; set; }
		public string ProductName { get; set; }
		public string ProductDescription { get; set; }
		public decimal ProductPrice { get; set; }
		public string ImageUrl { get; set; }
		public bool ProductStatus { get; set; }
		public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
