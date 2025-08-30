using UnityEngine;

public class Paddle : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public int id;
    public float moveSpeed = 2f;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        float movement = ProcessInput();
        Move(movement);
    }
    private float ProcessInput()
    {
        float movement = 0f;
            switch (id)
        {
            case 1:
                movement = Input.GetAxis("MovementPlayer1");
                break;
            case 2:
                movement = Input.GetAxis("MovementPlayer2");
                break;

        }
        return movement;
    }
    void Move(float movement)
    {
        Vector2 velo = rb2d.linearVelocity;
        velo.y = moveSpeed * movement;
        rb2d.linearVelocity = velo;
    }

}
