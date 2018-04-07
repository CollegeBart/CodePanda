using UnityEngine;
using System.Collections.Generic;
using System;

namespace ca.codepanda
{
    public class Recipes : List<Recipe>
    {
        private const int _numberOfRecipes = 1;
        private const int _minItemsInRecipes = 2;
        public const int _maxItemsInRecipes = 4;


        public void Refresh()
        {
            Clear();
            List<int> itemsInRecipes = new List<int>();
            for (int i = 0; i < _numberOfRecipes; i++)
                itemsInRecipes.Add(UnityEngine.Random.Range(_minItemsInRecipes, _maxItemsInRecipes));

            itemsInRecipes.Sort();

            for (int i = 0; i < _numberOfRecipes; i++)
                Add(new Recipe(itemsInRecipes[i]));

        }
    }
}
