using BlazorApp.Model;

namespace BlazorApp.Dados;

public static class SeedData
{
    public static void Initialize(PizzaStoreContext db)
    {
        if (db.Pizzas.Any())
        {
            return; // Dados já foram semeados
        }
        var pizzas = new ModeloPizza[]
        {
            new ModeloPizza
            {
                Nome = "Basic Cheese Pizza",
                Descricao = "It's cheesy and delicious. Why wouldn't you want one?",
                PrecoBase = 9.99m,
                Vegetariana = true,
                Vegana = false,
                ImagemUrl = "img/pizzas/cheese.jpg",
                Tamanho = ModeloPizza.TamanhoPadrao,
            },
            new ModeloPizza
            {
                Nome = "The Baconatorizor",
                Descricao = "It has EVERY kind of bacon",
                PrecoBase = 11.99m,
                Vegetariana = false,
                Vegana = false,
                ImagemUrl = "img/pizzas/bacon.jpg",
                Tamanho = ModeloPizza.TamanhoPadrao,
            },
            new ModeloPizza
            {
                Nome = "Classic pepperoni",
                Descricao = "It's the pizza you grew up with, but Blazing hot!",
                PrecoBase = 10.50m,
                Vegetariana = false,
                Vegana = false,
                ImagemUrl = "img/pizzas/pepperoni.jpg",
                Tamanho = ModeloPizza.TamanhoPadrao,
            },
            new ModeloPizza
            {
                Nome = "Buffalo chicken",
                Descricao = "Spicy chicken, hot sauce and bleu cheese, guaranteed to warm you up",
                PrecoBase = 12.75m,
                Vegetariana = false,
                Vegana = false,
                ImagemUrl = "img/pizzas/meaty.jpg",
                Tamanho = ModeloPizza.TamanhoPadrao,
            },
            new ModeloPizza
            {
                Nome = "Mushroom Lovers",
                Descricao = "It has mushrooms. Isn't that obvious?",
                PrecoBase = 11.00m,
                Vegetariana = true,
                Vegana = true,
                ImagemUrl = "img/pizzas/mushroom.jpg",
                Tamanho = ModeloPizza.TamanhoPadrao,
            },
            new ModeloPizza
            {
                Nome = "Veggie Delight",
                Descricao = "It's like salad, but on a pizza",
                PrecoBase = 11.50m,
                Vegetariana = true,
                Vegana = true,
                ImagemUrl = "img/pizzas/salad.jpg",
                Tamanho = ModeloPizza.TamanhoPadrao,
            },
            new ModeloPizza
            {
                Nome = "Margherita",
                Descricao = "Traditional Italian pizza with tomatoes and basil",
                PrecoBase = 9.99m,
                Vegetariana = true,
                Vegana = false,
                ImagemUrl = "img/pizzas/margherita.jpg",
                Tamanho = ModeloPizza.TamanhoPadrao,
            },

        };
        db.Pizzas.AddRange(pizzas);
        db.SaveChanges();
    }
}

