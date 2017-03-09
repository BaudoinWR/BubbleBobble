using UnityEngine;
using System.Collections;

public class ZenChanScript : EnemyScript {
    public uint jumpRate = 50;
    public float jumpForce = 300.0f;

    // Use this for initialization
    void Start () {
        speed = 3.0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    new void FixedUpdate()
    {
        base.FixedUpdate();
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb.velocity.y != 0)
        {
            return;
        }
        float r = Random.Range(0, jumpRate);
        if (r > jumpRate - 1)
        {
            rb.AddForce(new Vector2(0, jumpForce));
        }
        else
        {
            Vector3 move = direction;
            transform.position += move * speed * Time.deltaTime;
        }
    }
}
