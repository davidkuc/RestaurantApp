﻿using RestaurantApp.Entities;

namespace RestaurantApp.DataProviders
{
    public interface IOrderProvider
    {
        List<Order>? SortByOrderDateTimeAsc();

        List<Order>? SortByOrderDateTimeDesc();

        List<Order>? OrdersAboveValue(decimal minPrice);

        List<Order>? OrdersBelowValue(decimal maxPrice);

        string GetOrderInfo(int id);

        List<Order>? GetOrdersToGo();

        List<Order>? GetOrdersOnSite();

        List<Order>? GetCompletedOrders();

        List<Order>? GetUncompletedOrders();

        decimal? GetOrderValue(int id);

        List<IGrouping<int, Order>>? GroupByEmployee();

    }
}
