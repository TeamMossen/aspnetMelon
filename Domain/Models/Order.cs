using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Order
{
    internal Order()
    {
    }
    public Order(int orderId, string firstName, string lastName, string phoneNumber, string address, string zipCode, string city, string state, DateTime orderPlaced, decimal orderTotal, ICollection<OrderDetail> orderDetails)
    {
        OrderId = orderId;
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Address = address;
        ZipCode = zipCode;
        City = city;
        State = state;
        OrderPlaced = orderPlaced;
        OrderTotal = orderTotal;
        OrderDetails = orderDetails;
    }

    [BindNever]
    public int OrderId { get; set; } = default!;

    [Required(ErrorMessage = "Please enter first name")]
    [Display(Name = "First Name")]
    [StringLength(25)]
    public string FirstName { get; set; } = default!;

    [Required(ErrorMessage = "Please enter last name")]
    [Display(Name = "Last Name")]
    [StringLength(50)]
    public string LastName { get; set; } = default!;

    [Required(ErrorMessage = "Please enter address")]
    [Display(Name = "Street Address")]
    [StringLength(100)]
    public string Address { get; set; } = default!;

    [Required(ErrorMessage = "Please enter city")]
    public string City { get; set; } = default!;

    [Required(ErrorMessage = "Please enter state")]
    public string State { get; set; } = default!;

    [Required(ErrorMessage = "Please enter zip code")]
    [StringLength(5, MinimumLength = 5)]
    public string ZipCode { get; set; } = default!;

    [Required(ErrorMessage = "Please enter phone number")]
    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber { get; set; } = default!;
    public ICollection<OrderDetail>? OrderDetails { get; set; }

    [BindNever]
    [ScaffoldColumn(false)]
    public decimal OrderTotal { get; set; } = default!;

    [BindNever]
    [ScaffoldColumn(false)]
    public DateTime OrderPlaced { get; set; } = default!;

}