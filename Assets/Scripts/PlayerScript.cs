using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    public float speed = 5.0f;
    public float jumpForce = 300.0f;
    private Vector3 direction;
    private Animator animator;
    Rigidbody2D rb;
    public GameObject bubble;
    public float bubbleRate = 0.2f;
    private float bubbleCooldown = 0.0f;
    private float jumpCooldown = 0.0f;
    private bool isdead = false;
    private float deadtime = 0.0f;
    private float reviveCooldown = 5.0f;
    private Vector3 startingPosition;
    float distToGround;

    public GameObject pad;
    private PadScript padScript;

	// Use this for initialization
	void Start () {
        distToGround = GetComponent<Collider2D>().bounds.extents.y;
        direction = Vector3.right;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        pad = GameObject.Find("Pad");
        if (pad == null)
        {
            padScript = new PadScript();
        } else
        {
            padScript = pad.GetComponent<PadScript>();
        }
        
        startingPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        if (velocity.y < -2)
        {
            velocity.y = -2;
            rb.velocity = velocity;
        }

        animator.SetBool("shooting", false);
        animator.SetBool("inair", false);
        
        if (isdead) { DoDeath(); return; }
        if (Input.GetKey(KeyCode.LeftArrow) || padScript.CheckTouch("LeftTag"))
        {
            DoLeft();
        }
        else if (Input.GetKey(KeyCode.RightArrow) || padScript.CheckTouch("RightTag"))
        {
            DoRight();
        }
        else
        {
            animator.SetBool("running", false);
        }
        if (Input.GetKey(KeyCode.UpArrow) || padScript.CheckTouch("JumpTag"))
        {
            DoJump();
        }
        if (Input.GetKey(KeyCode.Space) || padScript.CheckTouch("BubbleButtonTag"))
        {
            DoBubble();
        }
        if (bubbleCooldown >= 0)
        {
            bubbleCooldown -= Time.deltaTime;
        }
        if (jumpCooldown >= 0)
        {
            jumpCooldown -= Time.deltaTime;
        }
        if (rb.velocity.y != 0)
        {
            animator.SetBool("inair", true);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyScript>() != null && !isdead)
        {
            animator.SetBool("isdying", true);
            //animator.Play("death");
            isdead = true;
            deadtime = reviveCooldown;
            gameObject.layer = LayerMask.NameToLayer("Dying");
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("BubbleTopTag")
            && !collider.transform.parent.gameObject.CompareTag("BubbleFireTag")
            && rb.velocity.y <= 0
            && (Input.GetKey(KeyCode.UpArrow) || padScript.CheckTouch("JumpTag")))
        {
            Vector2 v = rb.velocity;
            v.y = 0;
            rb.velocity = v;
        }
    }

    public void DoBubble()
    {
        if (bubbleCooldown <= 0)
        {
            GameObject newBubble = Instantiate(bubble);
            newBubble.transform.position = transform.position;
            BubbleScript bubbleScript = newBubble.GetComponent<BubbleScript>();
            bubbleScript.direction = direction;
            bubbleCooldown = bubbleRate;
            animator.SetBool("shooting", true);
        }
    }

    public void DoJump()
    {
        if (rb.velocity.y == 0 && jumpCooldown <= 0)
        {
            jumpCooldown = 0.2f;
            rb.AddForce(new Vector2(0, jumpForce));
        }
    }

    public void DoLeft()
    {
        direction = Vector3.left;
        Vector3 move = direction;
        transform.position += move * speed * Time.deltaTime;
        if (transform.localScale.x < 0)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
        animator.SetBool("running", true);
    }

    public void DoRight()
    {
        direction = Vector3.right;
        Vector3 move = direction;
        transform.position += move * speed * Time.deltaTime;
        if (transform.localScale.x > 0)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
        animator.SetBool("running", true);
    }

    public void DoDeath()
    {
        deadtime -= Time.deltaTime;
        if (deadtime <= 0)
        {
            isdead = false;
            transform.position = startingPosition;
            gameObject.layer = LayerMask.NameToLayer("Default");
            animator.gameObject.SetActive(true);
        }
    }

}
