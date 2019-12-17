using UnityEngine;
using UnityEditor;

public class CubeWindow : EditorWindow{
    Color color;

    [MenuItem("Window/Cube")]
    public static void ShowWindow(){
        GetWindow<CubeWindow>("Cube");
    }

    void OnGUI(){
        GUILayout.Label("Color the Selected Objects", EditorStyles.boldLabel);

        color = EditorGUILayout.ColorField("Color", color);

        if(GUILayout.Button("Colorize")){
            Colorrize();
        }
    }

    void Colorrize(){
        foreach(GameObject obj in Selection.gameObjects){
            Renderer renderer = obj.GetComponent<Renderer>();
            if(renderer != null) renderer.sharedMaterial.color = color;
        }
    }
}
