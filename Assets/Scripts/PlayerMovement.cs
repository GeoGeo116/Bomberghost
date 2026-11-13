using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;    // The speed that the player will move at.
    Vector3 movement;      // The vector to store the direction of the player's movement
    Rigidbody playerRigidbody;      // Reference to the player's rigidbody.
    Animator anim; //Reference to the animator component

    // Use this for initialization
    void Start () {
        // Set up references.
        playerRigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    } 

    void Update()
    {   // Store the input axes.
        float h = Input.GetAxisRaw("Horizontal")*-1;
        float v = Input.GetAxisRaw("Vertical")*-1;

        // Move the player around the scene.
        Move(h, v);
        Turning();
    } 

    void Move(float h, float v)
    {
        // Set the movement vector based on the axis input.
        movement.Set(h, 0f, v);

        // Normalise the movement vector and make it proportional to the speed per second
        movement = movement.normalized * speed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        playerRigidbody.MovePosition(transform.position + movement);

        Animating(h,v);
    } 

    void Turning()
    {
            if (Input.GetKey(KeyCode.W))
            { //Up 
                GetComponent<Transform>().rotation = Quaternion.Euler(0, 180, 0);
            }
            if (Input.GetKey(KeyCode.A))
            { //Up 
                GetComponent<Transform>().rotation = Quaternion.Euler(0, 90, 0);
            }
            if (Input.GetKey(KeyCode.S))
            { //Up 
                GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
            }
            if (Input.GetKey(KeyCode.D))
            { //Up 
                GetComponent<Transform>().rotation = Quaternion.Euler(0, -90, 0);
            }
    } 

    void Animating(float h, float v){
        bool walking = h != 0f || v!=0f;
        anim.SetBool("isWalking", walking);
    }

}
