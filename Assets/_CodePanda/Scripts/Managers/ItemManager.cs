using UnityEngine;
using System.Collections.Generic;
using System;

namespace ca.codepanda
{

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

        private GameManager _gameManager;
        [SerializeField] private Transform[] _spawnPositions;

        public GameObject[] _prefabs;
        private Recipes _recipes = new Recipes();

        public float _spawnRandomize = 1.5f;
        public int _itemsToSpawn = 20;
        private string _RECIPES_TAG = "Recipes";

        private int[] _cauldronIndexes;

        public Transform[] _cauldrons;
        public SpriteRenderer[] _cauldronSprites;
        private int _timesSpawnedItemWasNotInTheRecipe;

        private void Start()
        {
            RefreshRecipes();
            _gameManager = References.Instance._gameManager;
            _timesSpawnedItemWasNotInTheRecipe = 0;
            InitCauldron();
        }

        private void InitCauldron()
        {
            _cauldronIndexes = new int[2] { 0, 0 };
            UpdateCauldronSprites();
        }

        public void FillCauldron(Transform cauldron, Item type, int playerIndex)
        {
            int rewardScore = 0;
            int teamIndex = (playerIndex) % 2;
            if (cauldron == _cauldrons[teamIndex])
            {
                if (type._type == _recipes[0]._ingredients[_cauldronIndexes[teamIndex]])
                {
                    if (_cauldronIndexes[teamIndex] != _recipes[0]._ingredients.Count-1)
                        _cauldronIndexes[teamIndex]++;
                    else
                    {
                        _cauldronIndexes = new int[2] { 0, 0 };

                        rewardScore += 50 * _recipes[0]._ingredients.Count;
                        RefreshRecipes();
                    }
                    rewardScore = 50;
                }
            }
            else if (cauldron != _cauldrons[teamIndex])
            {
                if (type._type != _recipes[0]._ingredients[_cauldronIndexes[teamIndex]])
                {
                    if (_cauldronIndexes[(teamIndex + 1) % 2] > 0)                    
                        _cauldronIndexes[(teamIndex + 1) % 2]--;
                    
                    rewardScore = 25;
                }
            }

            _gameManager.AddScore(rewardScore, teamIndex);

            UpdateCauldronSprites();
        }

        private void UpdateCauldronSprites()
        {
            var ingredientSprite = _prefabs[(int)_recipes[0]._ingredients[_cauldronIndexes[0]]].GetComponentInChildren<SpriteRenderer>().sprite;
            _cauldronSprites[0].sprite = ingredientSprite;

            ingredientSprite = _prefabs[(int)_recipes[0]._ingredients[_cauldronIndexes[1]]].GetComponentInChildren<SpriteRenderer>().sprite;
            _cauldronSprites[1].sprite = ingredientSprite;
        }

        public void SpawnNewItem()
        {
            int _newItem;

            if (_timesSpawnedItemWasNotInTheRecipe >= 2)
                _newItem = (int)_recipes[0]._ingredients[UnityEngine.Random.Range(0, _recipes[0]._ingredients.Count - 1)];
            else
                _newItem = UnityEngine.Random.Range(0, _prefabs.Length);

            GameObject go = Instantiate(_prefabs[_newItem], References.Instance._dynamic);
            int _newPos = UnityEngine.Random.Range(0, _spawnPositions.Length);

            if (!_recipes[0]._ingredients.Contains(go.GetComponent<Item>()._type))
                _timesSpawnedItemWasNotInTheRecipe += 1;
            else
                _timesSpawnedItemWasNotInTheRecipe = 0;

            go.transform.position = _spawnPositions[_newPos].position + (Vector3)UnityEngine.Random.insideUnitCircle * _spawnRandomize;
        }

        internal void RefreshRecipes()
        {
            var recipesSpriteContainer = GameObject.FindGameObjectWithTag(_RECIPES_TAG);

            if (_recipes.Count==0)
                recipesSpriteContainer.GetComponent<Animator>().SetTrigger("Open");
            else
                recipesSpriteContainer.GetComponent<Animator>().SetTrigger("FlipPage");

            _recipes.Refresh();
            foreach (Recipe recipe in _recipes)
            {
                for (int i = 0; i < recipe._ingredients.Count; i++)
                {
                    var ingredientSprite = _prefabs[(int)recipe._ingredients[i]].GetComponentInChildren<SpriteRenderer>().sprite;
                    var spritePlaceholder = recipesSpriteContainer.transform.Find("PlaceHolderIngredient" + (i + 1));
                    var spriteRenderer = spritePlaceholder.gameObject.GetComponent<SpriteRenderer>();
                    spriteRenderer.sprite = ingredientSprite;
                }
            }
        }
    }
}
