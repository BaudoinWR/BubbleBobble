using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
    private static readonly object _syncRoot = new Object();

    public GameObject bubbled;
    public float speed = 3.0f;
    public Vector3 direction = Vector3.left;
    // Use this for initialization
    void Start()
    {
        if (direction == Vector3.right)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    // Update is called once per frame
    void Update () {
	
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
