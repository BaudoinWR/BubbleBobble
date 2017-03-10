using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
    private static readonly object _syncRoot = new Object();
    protected Animator animator;
    public GameObject bubbled;
    public float speed = 3.0f;
    public Vector3 direction = Vector3.left;
    // Use this for initialization
    protected void Start()
    {
        animator = GetComponent<Animator>();
    }

    protected void FixedUpdate () {
        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
        if (GetComponent<Rigidbody2D>().velocity.y < -2)
        {
            velocity.y = -2;
            GetComponent<Rigidbody2D>().velocity = velocity;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("WallTag"))
        {
            direction = (direction == Vector3.left) ? Vector3.right : Vector3.left;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
