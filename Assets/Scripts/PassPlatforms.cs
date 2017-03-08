using UnityEngine;
using System.Collections;

public class PassPlatforms : MonoBehaviour {
    Rigidbody2D rb;
    ArrayList ignoring = new ArrayList();
    // Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        ArrayList keep = new ArrayList();
        foreach (GameObject obj in ignoring)
        {
            if (rb.transform.position.y > obj.transform.position.y)
            {
                Physics2D.IgnoreCollision(obj.transform.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);
            }
            else
            {
                keep.Add(obj);
            }
        }
        ignoring = keep;
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BrickDisableTag") && rb.transform.position.y < collision.transform.position.y)
        {
            Physics2D.IgnoreCollision(collision.transform.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            ignoring.Add(collision.gameObject);
        }
    }

 /*   void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BrickDisableTag") )
        {
            Physics2D.IgnoreCollision(collision.transform.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);
        }
    }
    


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("BrickDisableTag"))
        {
            Physics2D.IgnoreCollision(collider.transform.parent.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("BrickEnableTag"))
        {
            Physics2D.IgnoreCollision(collider.transform.parent.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);
        }
        if (collider.gameObject.CompareTag("BrickDisableTag") && !(rb.velocity.y > 0))
        {
            Physics2D.IgnoreCollision(collider.transform.parent.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);
        }
    }
    */
}
