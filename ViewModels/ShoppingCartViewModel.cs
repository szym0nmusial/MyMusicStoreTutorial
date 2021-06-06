using MyMusicStoreTutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMusicStoreTutorial.ViewModels
{
    public class ShoppingCartViewModel
 {
 public List<Cart> CartItems { get; set; }
    public decimal CartTotal { get; set; }
}
}
