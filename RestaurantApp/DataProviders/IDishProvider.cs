using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Entities;

namespace RestaurantApp.DataProviders
{
    public interface IDishProvider
    {
        List<Dish>? SortByPriceAsc();

        List<Dish>? SortByPriceDesc();

        List<Dish>? DishesAboveValue(decimal minPrice);

        List<Dish>? DishesBelowValue(decimal maxPrice);

    }
}
