using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class OrderEdit : EditorWindow
{
    string strBtnName = "Add";
    int addNum;
    [MenuItem("ESI/Get Min&Max Oder Name")]
    static void MinMax()
    {
        int min = 0,max = 0;

        if (Selection.gameObjects.Length > 0)
        {
            for (int i = 0; i < Selection.gameObjects.Length; i++)
            {
                List<SpriteRenderer> allSPRenderers = Selection.gameObjects[i].GetComponentsInChildren<SpriteRenderer>().ToList<SpriteRenderer>();

                max = allSPRenderers.Max(x => x.sortingOrder);
                min = allSPRenderers.Min(x => x.sortingOrder);
                Debug.Log($"Max:{min} - Max:{max}");

                Selection.gameObjects[i].name += $" ({min},{max})";
            }

        }
    }

    [MenuItem("ESI/Add to All Oders")]
    static void AddNumber()
    {
        EditorWindow.GetWindowWithRect(typeof(OrderEdit), new Rect(0, 0, 200, 50));
    }

    void OnGUI(){
        addNum = EditorGUILayout.IntField("HowMuch:", addNum);

         if (GUILayout.Button(strBtnName) && Selection.activeGameObject != null){

            for (int j = 0; j < Selection.gameObjects.Length; j++)
            {
                SpriteRenderer[] allSPRenderers = Selection.gameObjects[j].GetComponentsInChildren<SpriteRenderer>();
                for (int i = 0; i < allSPRenderers.Length; i++)
                    allSPRenderers[i].sortingOrder += addNum;
            }

        }


    }
}
