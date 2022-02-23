

using System.Text.Json;

namespace RestaurantApp.Entities.Extensions
{
    public static class EntitiesExtensions
    {

        public static T? Copy<T>(this T itemToCopy) where T : IEntity
        {

            var json = JsonSerializer.Serialize<T>(itemToCopy);
            return JsonSerializer.Deserialize<T>(json);
        
        }

    }
}
