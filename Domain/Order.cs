﻿
namespace Domain;
public class Order
{
    public int Id { get; set; }
    public Product Product { get; set; }
    public DateTime OrderTime { get; set; }
}