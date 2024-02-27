using UnityEngine;
using UnityEditor;

public class TransformTools : EditorWindow
{
    Vector3 direction;
    float distance,degree;
    string strBtnName = "Add";
    [MenuItem("ESI/Print Distance")]
    static void GetDistance(){
        Debug.Log($"Distance:{Vector3.Distance(Selection.transforms[0].position,Selection.transforms[1].position)}");
    }

    [MenuItem("ESI/Print World Position")]
    static void GetWorldPosition(){
        Debug.Log($"{Selection.activeGameObject.name} : World Position: {Selection.activeTransform.position}");
    }

    [MenuItem("ESI/Print Bound Size")]
    static void GetBoundSize(){
        Debug.Log($"{Selection.activeGameObject.name} : Size: {Selection.activeGameObject.GetComponent<SpriteRenderer>().bounds.size}");
    }


    [MenuItem("ESI/Change Local Position")]
    static void ChangeLocalPos()
    {
        EditorWindow.GetWindowWithRect(typeof(TransformTools), new Rect(0, 0, 200, 300));
    }

    void OnGUI(){
        distance = EditorGUILayout.FloatField("Distance:", distance);
        degree = EditorGUILayout.FloatField("Angle:", degree);

         if (GUILayout.Button(strBtnName) && Selection.gameObjects != null){

            for (int i = 0; i < Selection.gameObjects.Length; i++)
            {
                
                direction = new Vector2(Mathf.Cos(degree * Mathf.Deg2Rad), Mathf.Sin(degree * Mathf.Deg2Rad));
                Selection.gameObjects[i].transform.localPosition += (direction * distance);//Selection.gameObjects[i].transform.right * distance;
            }

        }


    }
}
