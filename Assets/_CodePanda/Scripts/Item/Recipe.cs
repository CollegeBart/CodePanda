using UnityEngine;
using System.Collections.Generic;

namespace ca.codepanda
{
    public class Recipe 
    {
        public List<ItemManager.Items> _ingredients;

        public Recipe(int numberOfItems)
        {
            _ingredients = new List<ItemManager.Items>();
            List<ItemManager.Items> possibleIngredients = new List<ItemManager.Items>() {
                ItemManager.Items.Bottle,
                ItemManager.Items.Cloud,
                ItemManager.Items.Coconut,
                ItemManager.Items.Leaves,
                ItemManager.Items.Sheep,
                ItemManager.Items.Thunder,
                ItemManager.Items.Tornado,
                ItemManager.Items.Wood };

            for (int i = 0; i < numberOfItems; i++)
            {
                var indexIngredient = Random.Range(0, possibleIngredients.Count-1);
                _ingredients.Add(possibleIngredients[indexIngredient]);
                possibleIngredients.Remove(possibleIngredients[indexIngredient]);
            }

        }
    }
}