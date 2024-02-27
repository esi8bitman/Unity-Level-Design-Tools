using UnityEngine;
using UnityEditor;

public class BatchRename : EditorWindow
{
    string baseName,btnName = "Do it!";

    [MenuItem("ESI/Vice Versa Selections")]
    static void ViceVersaOrders()
    {
        int ind = Selection.transforms.Length;
        for (int j = 0; j < Selection.transforms.Length; j++)
            {
                ind--;
                Selection.transforms[j].SetSiblingIndex(ind);
            }
    }

    [MenuItem("ESI/Rename All Selections")]
    static void ObjectsBatchRename()
    {
        EditorWindow.GetWindowWithRect(typeof(BatchRename), new Rect(0, 0, 200, 50));
    }

    void OnGUI(){
        baseName = EditorGUILayout.TextField("Base Name:", baseName);

         if (GUILayout.Button(btnName) && Selection.activeGameObject != null){

            for (int j = 0; j < Selection.gameObjects.Length; j++)
            {
                Selection.gameObjects[j].name = $"{baseName} ({j})";
            }

        }


    }
}

