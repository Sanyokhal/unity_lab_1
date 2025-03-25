using UnityEngine;

public class UserMovement : MonoBehaviour
{
    public float player_speed = 10.0f;
    public float jump_height = 10.0f;

    public float timeLeft = 0f;
    public float maxSprintDuration = 3.0f;
    public bool use_speed_boost = false;
    private bool onTheGround = true;
    private bool touchedFinish = false;
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
        if(Input.GetKeyDown(KeyCode.LeftShift) && timeLeft < maxSprintDuration){
            if(!use_speed_boost){
            Debug.Log("Speed boost");
            use_speed_boost = true;
            player_speed *= 2;
            }
            timeLeft += Time.deltaTime;
        }else{
            timeLeft -= Time.deltaTime;
            if(timeLeft < 0){
                timeLeft = 0f;
                if(use_speed_boost){
use_speed_boost = false;
                player_speed /=2;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onTheGround = true;
        }else if(collision.gameObject.CompareTag("Finish") && !touchedFinish){
            Debug.Log("FINISH");
            touchedFinish = true;
        }

    }
}
