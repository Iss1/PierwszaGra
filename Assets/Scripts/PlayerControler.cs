using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour {

    private Rigidbody2D myrigitbody2D;

    public float MoveSpeed, JumpHeight;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;
    private bool doubleJump;
    private Animator anim;
    private float moveVelocity;

    public Transform firePoint;
    public GameObject ninjaStar;

    public float knockback;
    public float knockbackLength;
    public float knockbackCount;
    public bool knockFromRigth;

    public bool onLadder;
    public float climbSpeed;
    private float climbVelocity;
    private float gravityStore;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        myrigitbody2D = GetComponent<Rigidbody2D>();
        gravityStore = myrigitbody2D.gravityScale;
	}
	
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

	// Update is called once per frame
	void Update ()
    {
        if (grounded)
            doubleJump = false;

        anim.SetBool("Grounded", grounded);

        if (Input.GetButtonDown("Jump") && grounded)
            Jump();
            //GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
        if (Input.GetButtonDown("Jump") && !doubleJump && !grounded)
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
            Jump();
            doubleJump = true;
        }

        moveVelocity = MoveSpeed * Input.GetAxisRaw("Horizontal");

        if (knockbackCount <= 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
        } else
        {
            if(knockFromRigth)
            {
                myrigitbody2D.velocity = new Vector2(-knockback, knockback);
            }
            if(!knockFromRigth)
                myrigitbody2D.velocity = new Vector2(knockback, knockback);
            knockbackCount -= Time.deltaTime;
        }

        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

        if (GetComponent<Rigidbody2D>().velocity.x > 0)
            transform.localScale = new Vector3(1f, 1f, 1f);
        else if (GetComponent<Rigidbody2D>().velocity.x < 0)
            transform.localScale = new Vector3(-1f, 1f, 1f);

        if(Input.GetButtonDown("Fire1"))
        {
            Instantiate(ninjaStar, firePoint.position, firePoint.rotation);
        }

        if (anim.GetBool("Sword"))
            anim.SetBool("Sword",false);

        if (Input.GetButtonDown("Fire2"))
        {
            anim.SetBool("Sword", true);
        }

        if(onLadder)
        {
            myrigitbody2D.gravityScale = 0f;
            climbVelocity = climbSpeed * Input.GetAxisRaw("Vertical");
            myrigitbody2D.velocity = new Vector2(myrigitbody2D.velocity.x, climbVelocity);
        }
        if(!onLadder)
        {
            myrigitbody2D.gravityScale = gravityStore;
        }
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.tag == "MovingPlatform")
        {
            transform.parent = other.transform;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }
}
