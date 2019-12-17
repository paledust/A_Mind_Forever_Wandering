using UnityEngine;

public class Cube : MonoBehaviour{
    public float Size;
    void Start(){
        GenerateColor();
    }
    void Update(){
        float animation = Size + Mathf.Sin(Time.time * 8f) * Size/7f;
        transform.localScale = Vector3.one * animation;
    }
    public void GenerateColor(){
        GetComponent<Renderer>().sharedMaterial.color = Random.ColorHSV();
    }
    public void Reset(){
        GetComponent<Renderer>().sharedMaterial.color = Color.white;
    }

}
