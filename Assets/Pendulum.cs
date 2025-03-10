using UnityEngine;

public class Pendulum : MonoBehaviour
{
    public float speed = 2f;
    public float max_angle = 55f;
    private float startRotation;

    void Start()
    {
        startRotation = transform.rotation.eulerAngles.z;
    }

    void Update()
    {
        float rotation = max_angle * Mathf.Sin(Time.time * speed);
        transform.rotation = Quaternion.Euler(0, 0, startRotation + rotation);
    }

}