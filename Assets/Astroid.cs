using UnityEngine;

public class Astroid : MonoBehaviour
{
    public float r = 2f;
    public float speed = 1f;
    private float time;
     private Vector3 startPosition;
    void Start(){
         startPosition = transform.position;
    }
    void Update()
    {
        time += speed * Time.deltaTime;
        float x = r * Mathf.Pow(Mathf.Cos(time), 3);
        float z = r * Mathf.Pow(Mathf.Sin(time), 3);
        transform.position = startPosition  + new Vector3(x, 5, z);
    }
}