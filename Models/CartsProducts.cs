﻿using Pasar_Maya_Api.Models;

public class CartsProducts
{
    public int CartId { get; set; }
    public Cart Cart { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; }
}
