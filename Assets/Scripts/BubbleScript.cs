using UnityEngine;
using System.Collections;

public class BubbleScript : MonoBehaviour {
    public float timeFiring = 0.80f;
    public float timeFull = 10.0f;
    public float speedFiring = 3.4f;
    public float speedFull = 1.0f;
    public Vector3 direction;
    public GameObject burstingBubble;
    private float timeLeftFiring;
    private float timeLeftFull;
    public bool doPop = true;
    // Use this for initialization
	void Start () {
        timeLeftFiring = timeFiring;
        timeLeftFull = timeFull;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        if (timeLeftFiring >= 0)
        {
            Vector3 move = direction;
            transform.position += move * speedFiring * Time.deltaTime;
            timeLeftFiring -= Time.deltaTime;
        }
        else
        {
            transform.FindChild("burstCollider").tag = "BubbleBurstTag";
            if (tag != "EnemyBubbleTag")
            {
                transform.tag = "BubbleFullTag";
            }
            timeLeftFull -= Time.deltaTime;
            Vector3 move = Vector3.up;
            transform.position += move * speedFull * Time.deltaTime;

            if (timeLeftFull <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnDestroy()
    {
        if (doPop)
        {
           Instantiate(burstingBubble).transform.position = transform.position;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("WallTag"))
        {
            Physics2D.IgnoreCollision(collision.transform.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        if (gameObject.CompareTag("BubbleFireTag") && collision.gameObject.GetComponent<EnemyScript>() != null)
        {
            gameObject.GetComponent<BubbleScript>().doPop = false;
            gameObject.tag = "BubbleFullTag";
            Destroy(gameObject);
            GameObject trapped = Instantiate(collision.gameObject.GetComponent<EnemyScript>().bubbled);
            trapped.transform.position = collision.transform.position;
            Destroy(collision.gameObject.gameObject);
        }
    }


    void OnApplicationQuit()
    {
        doPop = false;
    }
}
