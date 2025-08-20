using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System.Collections.Generic; // Required for AssetDatabase

public class FolderCreator : EditorWindow
{
    private string folderName = "NewFolder";
    private string parentPath = "Assets";


    List<string> foldernames = new List<string>()
    {
        "Scripts", "Prefabs" , "Materials" , "Plugins"
    };

    [MenuItem("Tools/Create Project Folders")]
    public static void ShowWindow()
    {
        GetWindow<FolderCreator>("Create Folders");
    }

    void OnGUI()
    {
        GUILayout.Label("Create New Folder", EditorStyles.boldLabel);

        parentPath = EditorGUILayout.TextField("Parent Path:", parentPath);
        folderName = EditorGUILayout.TextField("Folder Name:", folderName);

        if (GUILayout.Button("Create Folder"))
        {
            for (int i = 0; i < foldernames.Count; i++)
            {
                CreateNewFolder(parentPath, foldernames[i]);
            }
        }  
    }

    private void CreateNewFolder(string parentFolder, string newFolderName)
    {
        if (AssetDatabase.IsValidFolder(parentFolder))
        {
            string fullPath = parentFolder + "/" + newFolderName;
            if (!AssetDatabase.IsValidFolder(fullPath))
            {
                string guid = AssetDatabase.CreateFolder(parentFolder, newFolderName);
                string newFolderPath = AssetDatabase.GUIDToAssetPath(guid);
                Debug.Log("Folder created at: " + newFolderPath);
            }
            else
            {
                Debug.LogWarning("Folder already exists at: " + fullPath);
            }
        }
        else
        {
            Debug.LogError("Parent path does not exist or is invalid: " + parentFolder);
        }
    }
}