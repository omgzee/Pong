using UnityEngine;

public class BalllScript : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float maxInitialangle = 0.67f;
    public float controlSpeed = 4f;
    private float maxStartY = 4f;
    private float startX = 0f;
    public float speedMultiplier = 1.5f;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitialPush();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitialPush()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Vector2 dir = Vector2.left;
        if (Random.value<0.5f) { dir=Vector2.right; }
        dir.y = Random.Range(-maxInitialangle,maxInitialangle);
        rb2d.linearVelocity = dir * controlSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreZone scoreZone = collision.GetComponent<ScoreZone>();
        
        if (scoreZone != null)
        {
            ResetBall();
            InitialPush();
            GameManager.instance.OnScoreZoneReached(scoreZone.id);
        }
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Paddle paddle = collision.collider.GetComponent<Paddle>();
        if (paddle)
        {
            rb2d.linearVelocity *= speedMultiplier;
        }
    }

    private void ResetBall()
    {
        float startY = Random.Range(-maxStartY, maxStartY);
        Vector2 position = new Vector2(startX, startY);
        transform.position = position;
    }
}
