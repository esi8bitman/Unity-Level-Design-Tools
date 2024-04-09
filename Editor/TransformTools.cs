using UnityEngine;
using UnityEditor;

public class TransformTools : EditorWindow
{
    Vector3 direction;
    float distance,degree;
    int i,num = 1;
    GameObject gameObjectTemp;
    string strName,strBtnChange = "Change",strBtnAdd = "Add";
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

        if (GUILayout.Button(strBtnChange) && Selection.gameObjects != null){

            for (int i = 0; i < Selection.gameObjects.Length; i++)
            {
                
                direction = new Vector2(Mathf.Cos(degree * Mathf.Deg2Rad), Mathf.Sin(degree * Mathf.Deg2Rad));
                Selection.gameObjects[i].transform.localPosition += (direction * distance);//Selection.gameObjects[i].transform.right * distance;
            }

        }

        num = EditorGUILayout.IntField("How Many Copy:", num);
        if (GUILayout.Button(strBtnAdd) && Selection.gameObjects != null){
            if(Selection.gameObjects.Length>1) Debug.Log("Just Select one game object and set how many you want!!!...Thanks ^_^");
            else{
                strName = Selection.activeGameObject.name;
                for(i=0;i<num;i++){
                    gameObjectTemp = Instantiate(Selection.activeGameObject,Selection.activeGameObject.transform.parent);
                    
                    direction = new Vector2(Mathf.Cos(degree * Mathf.Deg2Rad), Mathf.Sin(degree * Mathf.Deg2Rad));
                    gameObjectTemp.transform.localPosition += (direction * distance);
                    gameObjectTemp.name = $"{strName}({i})";
                    Selection.activeGameObject = gameObjectTemp;
                }
            }
        }
        


    }
}
