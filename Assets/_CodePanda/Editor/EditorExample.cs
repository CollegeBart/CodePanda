using UnityEngine;
using UnityEditor;

namespace ca.codepanda
{
    //[CustomEditor(typeof(Example))]
    public class EditorExample : Editor 
	{
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            //Example mTarget = (Example)target;

            if (GUILayout.Button("Click me"))
            {
                //ShitHappens with mTarget
            }
        }
    }
}
