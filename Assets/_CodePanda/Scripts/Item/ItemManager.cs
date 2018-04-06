using UnityEngine;
using System.Collections.Generic;

public class ItemManager : MonoBehaviour
{
    public enum Items
    {
        Bottle,
        Cloud,
        Coconut,
        Leaves,
        Sheep,
        Thunder,
        Tornado,
        Wood
    }

    private List<Items> _itemsInRecipe;
    private List<Items> _recipe;

    private const int _itemsLength = 7;
    private const int _ingredientsInRecipe = 12;

    public void Start()
    {
        _recipe = new List<Items>();

        for (int i = 0; i < _ingredientsInRecipe; i++)
        {
            if (_recipe.Count >= 3)
            {
                int _newItem = Random.Range(0, 2);
                _recipe.Add(_recipe[_newItem]);
            }
            else
            {
                int _newItem = Random.Range(0, _itemsLength);
                _recipe.Add((Items)_newItem);
            }
        }

        for (int i = 0; i < _recipe.Count; i++)
        {
            Debug.Log(_recipe[i].ToString());
        }
    }



}
