using UnityEngine;
using UnityEditor;
public class AnimationTools : EditorWindow
{
    float zarib;
    AnimationClip animClip;
    AnimationCurve curve,curve_new;
    [MenuItem("ESI/Multiply Animation Keys")]
    static void GetKeys(){
        EditorWindow.GetWindowWithRect(typeof(AnimationTools), new Rect(0, 0, 200, 300));
    }

     void OnGUI(){
        EditorGUILayout.LabelField("Clip:");
        animClip = EditorGUILayout.ObjectField(animClip, typeof(AnimationClip), true) as AnimationClip;
        
        EditorGUILayout.FloatField("Zarib:", zarib);

        if (GUILayout.Button("Process")){
            var curveBindings = AnimationUtility.GetCurveBindings (animClip);
 
               for (int i=0;i<curveBindings.Length;i++) {
                curve = AnimationUtility.GetEditorCurve(animClip, curveBindings[i]);
                    //Debug.Log (curveBindings[i].path + "-" + curveBindings[i].propertyName);
                    curve_new = new AnimationCurve();
                    for(int j=0;j<curve.keys.Length;j++){
                        //Debug.Log($"key {j}: {curve.keys[j].value}");
                        curve_new.AddKey(curve.keys[j].time,curve.keys[j].value * 1.5f);
                         //Debug.Log($"After key {j}: {curve.keys[j].value}");
                        
                    }
                    AnimationUtility.SetEditorCurve(animClip,curveBindings[i],curve_new);
                }
                

                Debug.Log("Done!");
        }
        
     }
        

}
