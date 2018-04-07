using UnityEngine;

namespace ca.codepanda
{
	public static class Tool 
	{
		public static bool FloatEqualToZero(float f)
        {
            return (f > Mathf.Epsilon && f < -Mathf.Epsilon);
        }
	}
}
