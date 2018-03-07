
using UnityEngine;
using UnityEditor;
using System.IO;

public class CreateDefaultFolders : ScriptableObject
{
    [MenuItem("Assets/Make Default Folders")]
    static void MenuMakeFolders()
    {
        CreateFolders();
    }

    static void CreateFolders()
    {
        string directory = Application.dataPath + "/_CodePanda/";

        Directory.CreateDirectory(directory + "Audio");
        Directory.CreateDirectory(directory + "Models");
        Directory.CreateDirectory(directory + "Materials");
        Directory.CreateDirectory(directory + "Textures");
        Directory.CreateDirectory(directory + "Scripts");
        Directory.CreateDirectory(directory + "Resources");
        Directory.CreateDirectory(directory + "Editor");
        Directory.CreateDirectory(directory + "Scripts");
        Directory.CreateDirectory(directory + "Prefabs");
        Directory.CreateDirectory(directory + "Scenes");

        Debug.Log("Created directories");
    }
}