using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Data.Entities;
using RestaurantApp.Components.UI.EntityUI;

namespace RestaurantApp.Components.UI
{
    public interface IStartUI
    {
        void InitializeUI();

        void MainMenuUI<T>(IEntityUI<T> entityComm)
            where T : class, IEntity;

        void AddEntityUI<T>(IEntityUI<T> entityComm)
            where T : class, IEntity;

        void UpdateEntityUI<T>(IEntityUI<T> entityComm)
            where T : class, IEntity;

        void DisplayEntityUI<T>(IEntityUI<T> entityComm)
            where T : class,IEntity;

        void DeleteEntityUI<T>(IEntityUI<T> entityComm)
            where T : class, IEntity;
    }
}
