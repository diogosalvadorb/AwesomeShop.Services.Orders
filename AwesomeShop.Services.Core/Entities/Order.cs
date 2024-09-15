using System.Collections.Generic;
using System;
using AwesomeShop.Services.Core.ValueObjects;
using System.Linq;
using AwesomeShop.Services.Core.Events;
using AwesomeShop.Services.Core.Enums;

namespace AwesomeShop.Services.Core.Entities
{
    public class Order : AggregateRoot
    {
        public Order(Customer customer, DeliveryAddress deliveryAddress, PaymentAddress paymentAddress, PaymentInfo paymentInfo, List<OrderItem> items)
        {
            Id = Guid.NewGuid();
            TotalPrice = items.Sum(i => i.Quantity * i.Price);
            Customer = customer;
            DeliveryAddress = deliveryAddress;
            PaymentAddress = paymentAddress;
            PaymentInfo = paymentInfo;
            Items = items;
            Status = OrderStatus.Started;

            CreatedAt = DateTime.Now;

            AddEvent(new OrderCreated(Id, TotalPrice, PaymentInfo, Customer.FullName, Customer.Email));
        }

        public decimal TotalPrice { get; private set; }
        public Customer Customer { get; private set; }
        public DeliveryAddress DeliveryAddress { get; private set; }
        public PaymentAddress PaymentAddress { get; private set; }
        public PaymentInfo PaymentInfo { get; set; }
        public List<OrderItem> Items { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public OrderStatus Status { get; set; }

        public void SetAsCompleted()
        {
            Status = OrderStatus.Completed;
        }

        public void SetAsRejected()
        {
            Status = OrderStatus.Rejected;
        }
    }
}
