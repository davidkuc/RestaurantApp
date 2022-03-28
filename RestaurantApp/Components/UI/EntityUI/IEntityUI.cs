using RestaurantApp.Data.Entities;
using RestaurantApp.Data.Repositories;

namespace RestaurantApp.Components.UI.EntityUI
{
    public interface IEntityUI<T> where T : class, IEntity
    {
        void Display();
        void Update();
        List<T> Add();
        List<T> Delete();
    }
}
