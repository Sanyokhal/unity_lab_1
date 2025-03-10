using UnityEngine;

public class Rotate : MonoBehaviour
{
        public float rotate_speed = 10f;

         void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, rotate_speed * Time.deltaTime);
    }

}