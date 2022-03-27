using RestaurantApp.Components.DataProviders;
using RestaurantApp.Data.Entities;
using RestaurantApp.Data.Repositories;
using RestaurantApp.Components.UI.EntityUI;
using RestaurantApp.Data.Repositories.RepositoryExtensions;
using RestaurantApp.Components.Audit;

namespace RestaurantApp.Components.UI.EntityUI
{
    public class DishUI : BaseEntityUI<Dish>
    {
        private readonly IDishProvider _provider;
        private readonly ISupplyProvider _supplyProvider;
        private readonly IRepository<Supply> _supplyRepository;

        public DishUI(IRepository<Dish> baseRepository
            , IRepository<Supply> supplyRepository
            , IDishProvider provider
            , ISupplyProvider supplyProvider
            , IAuditWriter auditWriter) : base(baseRepository, auditWriter)
        {
            _provider = provider;
            _supplyProvider = supplyProvider;
            _supplyRepository = supplyRepository;
        }
       
        public override List<Dish> Add()
        {
            Console.WriteLine();
            Console.WriteLine("---   Add dish  ---");
            Console.WriteLine();
            var dishesToAdd = new List<Dish>();
            while (true)
            {
                Console.WriteLine("Enter name");
                var dishName = Console.ReadLine();
                Console.WriteLine("Enter price");
                var price = decimal.Parse(Console.ReadLine());
                DisplayIngredients();
                var ingredients = ChooseIngredients();
                var newDish = CreateDish(dishName: dishName, price: price, ingredients: ingredients);
                dishesToAdd.Add(newDish);
                Console.WriteLine();
                Console.WriteLine("1 - Add another dish");
                Console.WriteLine("q - exit");
                Console.WriteLine();
                var addDishChoice = Console.ReadLine();

                if (addDishChoice == "q")
                {
                    break;
                }
            }
            RepositoryExtensions.AddBatch(_baseRepository, dishesToAdd);
            return dishesToAdd;
        }
        private ICollection<Supply> ChooseIngredients()
        {
            ICollection<Supply> ingredientCollection = new List<Supply>();
            DisplayIngredients();
            Console.WriteLine("Enter ingredients");
            while (true)
            {
                var chosenIngredient = ChooseEntityByID(_supplyRepository);
                ingredientCollection.Add(chosenIngredient);

                Console.WriteLine("1 - Add more ingredients");
                Console.WriteLine("q - exit");

                var chooseIngredientsChoice = Console.ReadLine();
                if (chooseIngredientsChoice == "q")
                {
                    break;
                }
            }

            return ingredientCollection;
        }

        private void DisplayIngredients()
        {
            Console.WriteLine();
            var groupedIngredients = _supplyProvider.GetIngredientsGroupedByCategory();
            foreach (var category in groupedIngredients)
            {
                Console.WriteLine(category.Key);
                foreach (var ingredient in category)
                {
                    Console.WriteLine(ingredient.ToString());
                }
            }
            Console.WriteLine();
        }

        private Dish CreateDish(string dishName, decimal price, ICollection<Supply> ingredients)
        {
            var newDish = new Dish
            {
                Name = dishName,
                Price = price,
                Supplies = ingredients
            };

            return newDish;
        }

        public override List<Dish> Delete()
        {
            Console.WriteLine();
            Console.WriteLine("---   Delete dish  ---");
            Console.WriteLine();
            var dishesToDelete = new List<Dish>();
            while (true)
            {
                DisplayDishes(_baseRepository);
                var dishToDelete = ChooseEntityByID(_baseRepository);
                dishesToDelete.Add(dishToDelete);
                Console.WriteLine();
                Console.WriteLine("1 - Add another dish to delete list");
                Console.WriteLine("q - exit");
                Console.WriteLine();
                var deleteDishChoice = Console.ReadLine();

                if (deleteDishChoice == "q")
                {
                    break;
                }
            }

            RepositoryExtensions.DeleteBatch(_baseRepository, dishesToDelete);
            return dishesToDelete;
        }

        public override void Display()
        {
            Console.WriteLine();
            Console.WriteLine("---   Display dish data  ---");
            Console.WriteLine();
            while (true)
            {
                Console.WriteLine("1 - Get dish information");
                Console.WriteLine("2 - Get dishes above value");
                Console.WriteLine("3 - Get dishes below value");
                Console.WriteLine("4 - Get dishes sorted by price asc");
                Console.WriteLine("5 - Get dishes sorted by price desc");
                Console.WriteLine("6 - Get all dishes");
                Console.WriteLine("7 - Get dish ingredients");
                Console.WriteLine("q - Exit");

                Console.WriteLine();
                var userInput = Console.ReadLine();

                if (userInput == "q")
                {
                    return;
                }

                switch (userInput)
                {
                    case "1":
                        DisplayDishInfo();
                        break;
                    case "2":
                        DisplayDishesAboveValue();
                        break;
                    case "3":
                        DisplayDishesBelowValue();
                        break;
                    case "4":
                        DisplayDishesSortedByPriceAsc();
                        break;
                    case "5":
                        DisplayDishesSortedByPriceDesc();
                        break;
                    case "6":
                        DisplayDishes(_baseRepository);
                        break;
                    case "7":
                        DisplayDishIngredients();
                        break;
                    default:
                        break;
                }
            }

        }

        private void DisplayDishIngredients()
        {
            var chosenDish = ChooseEntityByID(_baseRepository);
            var dishIngredients = _provider.GetDishIngredients(chosenDish);
            foreach (var dish in dishIngredients)
            {
                Console.WriteLine(dish.ToString());
            }
        }

        private void DisplayDishesSortedByPriceDesc()
        {
            var sortedDishes = _provider.SortByPriceDesc();
            foreach (var dish in sortedDishes)
            {
                Console.WriteLine(dish.ToString());
            }
        }



        private void DisplayDishesSortedByPriceAsc()
        {
            var sortedDishes = _provider.SortByPriceAsc();
            foreach (var dish in sortedDishes)
            {
                Console.WriteLine(dish.ToString());
            }
        }

        private void DisplayDishesBelowValue()
        {
            Console.WriteLine("Enter value");
            var maxValue = decimal.Parse(Console.ReadLine());
            var dishesBelowValue = _provider.DishesBelowValue(maxValue);
            foreach (var dish in dishesBelowValue)
            {
                Console.WriteLine(dish.ToString);
            }
        }

        private void DisplayDishesAboveValue()
        {
            Console.WriteLine("Enter value");
            var minValue = decimal.Parse(Console.ReadLine());
            var dishesAboveValue = _provider.DishesAboveValue(minValue);
            foreach (var dish in dishesAboveValue)
            {
                Console.WriteLine(dish.ToString);
            }
        }

        private void DisplayDishInfo()
        {
            var chosenDish = ChooseEntityByID(_baseRepository);
            Console.WriteLine(chosenDish.ToString());
        }

        public override void Update()
        {
            Console.WriteLine();
            Console.WriteLine("---   Update dish   ---");
            Console.WriteLine();
            while (true)
            {
                DisplayDishes(_baseRepository);
                var chosenDish = ChooseEntityByID(_baseRepository);
                Console.WriteLine();
                Console.WriteLine("What data do you wish to modify?");
                Console.WriteLine("1 - Name");
                Console.WriteLine("2 - Price");
                Console.WriteLine("3 - Ingredients");
                Console.WriteLine("4 - exit");
                Console.WriteLine();
                var updateDishChoice = Console.ReadLine();

                if (updateDishChoice == "4")
                {
                    return;
                }
                else
                {
                    switch (updateDishChoice)
                    {
                        case "1":
                            Console.WriteLine("Enter new dish name");
                            var newDishName = Console.ReadLine();
                            chosenDish.Name = newDishName;
                            break;
                        case "2":
                            Console.WriteLine("Enter new price");
                            var newPrice = decimal.Parse(Console.ReadLine());
                            chosenDish.Price = newPrice;
                            break;
                        case "3":
                            Console.WriteLine("1 - Add ingredients");
                            Console.WriteLine("2 - Delete ingredients");
                            var updateDishIngredientsChoice = Console.ReadLine();

                            switch (updateDishIngredientsChoice)
                            {
                                case "1":
                                    AddIngredients(chosenDish);
                                    break;
                                case "2":
                                    DeleteIngredients(chosenDish);
                                    break;
                                default:
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                    _baseRepository.Update(chosenDish);
                }


            }
        }

        private void DeleteIngredients(Dish chosenDish)
        {
            var ingredientsToDelete = new List<Supply>();
            Console.WriteLine("Choose ingredients to delete");
            while (true)
            {
                var dishIngredients = _provider.GetDishIngredients(chosenDish);
                Console.WriteLine();
                foreach (var ingredient in dishIngredients)
                {
                    Console.WriteLine(ingredient.ToString());
                }
                Console.WriteLine();
                var chosenIngredientID = int.Parse(Console.ReadLine());
                var chosenIngredient = chosenDish.Supplies.SingleOrDefault(p => p.Id == chosenIngredientID);
                ingredientsToDelete.Add(chosenIngredient);
                chosenDish.Supplies.Remove(chosenIngredient);
                Console.WriteLine("1 - Delete another ingredient");
                Console.WriteLine("2 - exit");

                var chooseIngredientsChoice = Console.ReadLine();
                if (chooseIngredientsChoice == "2")
                {
                    break;
                }
            }
            DeleteIngredientBatch(chosenDish, ingredientsToDelete);

        }

        private void DeleteIngredientBatch(Dish chosenDish, List<Supply> ingredientsToDelete)
        {
            foreach (var ingredient in ingredientsToDelete)
            {
                chosenDish.Supplies.Remove(ingredient);
            }
        }

        private void AddIngredients(Dish chosenDish)
        {
            var ingredientsToAdd = ChooseIngredients();
            AddIngredientBatch(chosenDish, ingredientsToAdd);
        }

        private void AddIngredientBatch(Dish chosenDish, ICollection<Supply> ingredientsToAdd)
        {
            foreach (var ingredient in ingredientsToAdd)
            {
                chosenDish.Supplies.Add(ingredient);
            }
        }

        protected override void OnEntityAdded(object? sender, Dish item)
        {
            var message = $"Dish {item.Name} added by {nameof(_baseRepository)}";
            Console.WriteLine(message);
            _auditWriter.AddToAuditBatch(message);
        }

        protected override void OnEntityRemoved(object? sender, Dish item)
        {
            var message = $"Dish {item.Name} removed by {nameof(_baseRepository)}";
            Console.WriteLine(message);
            _auditWriter.AddToAuditBatch(message);
        }

        protected override void OnEntityUpdated(object? sender, Dish item)
        {
            var message = $"Dish {item.Name} at ID: {item.Id} updated by {nameof(_baseRepository)}";
            Console.WriteLine(message);
            _auditWriter.AddToAuditBatch(message);
        }
    }


}

