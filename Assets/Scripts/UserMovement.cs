using UnityEngine;

public class UserMovement : MonoBehaviour
{
    public float player_speed = 10.0f;
    public float jump_height = 10.0f;

    private bool onTheGround = true;

    private float horizontal_input;
    private float vertical_input;
    private Rigidbody playerRB;
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontal_input = Input.GetAxis("Horizontal");
        vertical_input = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * player_speed * vertical_input);
        transform.Translate(Vector3.right * Time.deltaTime * player_speed * horizontal_input);

        if (Input.GetKeyDown(KeyCode.Space) && onTheGround)
        {
            playerRB.AddForce(Vector3.up * jump_height, ForceMode.Impulse);
            onTheGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onTheGround = true;
        }
    }
}
