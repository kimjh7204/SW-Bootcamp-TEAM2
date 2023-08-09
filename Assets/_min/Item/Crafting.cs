using System;
using System.Collections.Generic;

// 아이템 클래스
class Item
{
    public string Name { get; private set; }

    public Item(string name)
    {
        Name = name;
    }
}

// 크래프팅 레시피 클래스
class CraftingRecipe
{
    public Item Result { get; private set; }
    public List<Item> Ingredients { get; private set; }

    public CraftingRecipe(Item result, List<Item> ingredients)
    {
        Result = result;
        Ingredients = ingredients;
    }
}

// 크래프팅 시스템 클래스
class CraftingSystem
{
    private List<CraftingRecipe> recipes;

    public CraftingSystem()
    {
        recipes = new List<CraftingRecipe>();
    }

    public void AddRecipe(CraftingRecipe recipe)
    {
        recipes.Add(recipe);
    }

    public Item Craft(List<Item> ingredients)
    {
        foreach (CraftingRecipe recipe in recipes)
        {
            bool canCraft = true;

            foreach (Item ingredient in recipe.Ingredients)
            {
                if (!ingredients.Contains(ingredient))
                {
                    canCraft = false;
                    break;
                }
            }

            if (canCraft)
            {
                foreach (Item ingredient in recipe.Ingredients)
                {
                    ingredients.Remove(ingredient);
                }

                return recipe.Result;
            }
        }

        return null; // 조합할 수 없는 경우
    }
}

class Program
{
    static void Main(string[] args)
    {
        Item wood = new Item("Wood");
        Item stone = new Item("Stone");
        Item axe = new Item("Axe");
        
        CraftingRecipe axeRecipe = new CraftingRecipe(axe, new List<Item> { wood, stone });

        CraftingSystem craftingSystem = new CraftingSystem();
        craftingSystem.AddRecipe(axeRecipe);

        List<Item> playerInventory = new List<Item> { wood, stone };

        Item craftedItem = craftingSystem.Craft(playerInventory);
        if (craftedItem != null)
        {
            Console.WriteLine($"Crafted {craftedItem.Name}!");
        }
        else
        {
            Console.WriteLine("Cannot craft anything with the available ingredients.");
        }
    }
}
