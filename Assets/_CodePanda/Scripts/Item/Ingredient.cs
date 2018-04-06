// Put this in [...]\Unity2017.3.1f1\Editor\Data\Resources\ScriptTemplates

using UnityEngine;

namespace ca.codepanda
{
	public class Ingredient : MonoBehaviour
    {
        public enum IngredientsType
        {
            Chose1 = 1,
            Chose2 = 2
        }

        public IngredientsType Type;
    }
}
