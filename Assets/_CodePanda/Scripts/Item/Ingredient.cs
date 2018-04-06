// Put this in [...]\Unity2017.3.1f1\Editor\Data\Resources\ScriptTemplates

using UnityEngine;

namespace ca.codepanda
{
	public class Ingredient : MonoBehaviour
    {
        public enum IngredientsType
        {
            Chose1 = 1,
            Chose2 = 2,
            Chose3 = 3,
            Chose4 = 4,
            Chose5 = 5,
            Chose6 = 6, 
            Chose7 = 7,
            Chose8 = 8
        }

        public IngredientsType Type;
    }
}
