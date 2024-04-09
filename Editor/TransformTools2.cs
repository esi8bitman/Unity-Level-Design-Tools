using UnityEngine;
using UnityEditor;

public class TransformTools2 : EditorWindow
{
    Vector3 pos;
    float x,y,z;
    string strBtnGetName = "Get World Pos",strBtnSetName = "Change Position";
    int i;
    [MenuItem("ESI/Change World Position")]
    static void ChangeLocalPos()
    {
        EditorWindow.GetWindowWithRect(typeof(TransformTools2), new Rect(0, 0, 220, 70),true,"Change world Position");
    }

    void OnGUI(){
        EditorGUILayout.BeginHorizontal();
        EditorGUIUtility.labelWidth = 10;
        x = EditorGUILayout.FloatField("x",x);
        y = EditorGUILayout.FloatField("y", y);
        z = EditorGUILayout.FloatField("z", z);
        
        EditorGUILayout.EndHorizontal();


        if (GUILayout.Button(strBtnSetName) && Selection.transforms != null)
        {
            pos.Set(x,y,z);
            for (i = 0; i < Selection.transforms.Length; i++)
            {
                Selection.transforms[i].position = pos;
            }

        }

        else if (GUILayout.Button(strBtnGetName) && Selection.activeTransform != null)
        {
            pos = Selection.activeTransform.position;
            x = pos.x;
            y=pos.y;
            z=pos.z;

        }


    }
}
