using UnityEngine;
using UnityEditor;

public class DuplicateTransforms : EditorWindow
{
    const string strBtnCopy = "Copy Transform Values",strBtnPaste = "Paste Transform Values";
    Transform[] allTransforms;

    Vector3[] allPoses,allScales;
    Quaternion[] allRotes;
    int i;

    [MenuItem("ESI/Duplicate All Transforms")]
    static void DuplicateTransform()
    {
        EditorWindow.GetWindowWithRect(typeof(DuplicateTransforms), new Rect(0, 0, 200, 300));
    }

    void OnGUI(){

        if (GUILayout.Button(strBtnCopy) && Selection.activeGameObject != null){
            allTransforms = Selection.activeGameObject.GetComponentsInChildren<Transform>();
            allPoses = new Vector3[allTransforms.Length];
            allScales = new Vector3[allTransforms.Length];
            allRotes = new Quaternion[allTransforms.Length];

            for (i = 0; i < allTransforms.Length; i++){
                //Debug.Log($"{base_transforms[i].name} - {base_transforms[i].localPosition}");
                allPoses[i] = allTransforms[i].position;
                allScales[i] = allTransforms[i].localScale;
                allRotes[i] = allTransforms[i].rotation;
            }
        }

        else if (GUILayout.Button(strBtnPaste) && Selection.activeGameObject != null){
            
            allTransforms = Selection.activeGameObject.GetComponentsInChildren<Transform>();
            if(allTransforms.Length != allPoses.Length)
                Debug.Log("it is not match!!");
            else
            {

            for (i = 0; i < allTransforms.Length; i++){
                allTransforms[i].position = allPoses[i];
                allTransforms[i].localScale = allScales[i];
                allTransforms[i].rotation = allRotes[i];
            }

            Debug.Log("Copied all Transform propertise!");
            }
        }


    }

}
