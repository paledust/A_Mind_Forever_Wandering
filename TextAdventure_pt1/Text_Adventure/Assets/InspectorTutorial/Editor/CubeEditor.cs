using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Cube))]
public class CubeEditor : Editor{
    public override void OnInspectorGUI(){
        Cube cube = target as Cube;

        GUILayout.Label("Size Setting",EditorStyles.boldLabel);
            cube.Size = EditorGUILayout.Slider("Size", cube.Size, .1f, 2f);
            cube.transform.localScale = Vector3.one * cube.Size;

        GUILayout.Label("Color Setting",EditorStyles.boldLabel);
        GUILayout.BeginHorizontal();

            if(GUILayout.Button("Generate Color")){
                cube.GenerateColor();
            }
            if(GUILayout.Button("Reset")){
                cube.Reset();
            }

        GUILayout.EndHorizontal();
    }
}
