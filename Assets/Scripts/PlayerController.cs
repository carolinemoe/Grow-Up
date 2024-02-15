using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] int health;
    [SerializeField] GameObject player;
    private float horizontal;
    [SerializeField] private float speed = 4f;
    private bool isFacingRight = true;
    private bool walking = false;
    private bool attacking = false;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject hitBox;
    bool isCurrentlyColliding;
    [SerializeField] GameObject projectile;
    public TextMeshProUGUI healthNum;


    //assign animator variable
    private void getAni()
    {
        _animator = GetComponent<Animator>();
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        isCurrentlyColliding = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        getAni();
    }

    // Update is called once per frame
    void Update()
    {

        //check if player dead
        if (health <= 0)
        {
            death();
        }

        //display health
        healthNum.text = health.ToString();

        //get movement input
        horizontal = Input.GetAxisRaw("Horizontal");


        //attack input
        if (Input.GetKeyDown("j") && !attacking)
        {
            //_animator.ResetTrigger("idle");
            // walking = false;
            //_animator.ResetTrigger("walk");
            _animator.ResetTrigger("idle");
            attack();
        }

        //player is walking
        else if (horizontal != 0) {
            _animator.ResetTrigger("idle");
            makeWalk();
        }
    
        //idle
        else if (!attacking) 
        {
            idle();
        }

        if(isCurrentlyColliding)
        {
            
        }

        //movement
        Flip();

    }

    //plays walking animation 

    private void makeWalk()
    {
        if (!walking)
        {
            _animator.SetTrigger("walk");
            walking = true;
        }
       
    }

    //either creates hitbox (melee) or fires projectile and plays attack animation
    private void attack()
    {
        Debug.Log("attacking");
        Invoke("idle", 0.5f);
        Debug.Log("attacking");
        if (!attacking)
        {
            attacking = true;
            _animator.SetTrigger("attack");
            
        }
        if(projectile!=null)
        {
            Instantiate(projectile, new Vector3(player.transform.position.x, player.transform.position.y, 0), Quaternion.identity);
        }
       
    }

   void death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void idle()
    {
        attacking = false;
        walking = false;
        _animator.ResetTrigger("walk");
        _animator.SetTrigger("idle");
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

   void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "evilBubble")
        {
            health--;
        }
        else if (col.gameObject.tag == "enemyHit")
        {
            health = health - 2;
            Debug.Log("hit");
        }
        else if (col.gameObject.tag == "bubble")
        {
            Debug.Log("bubble");
        }
    }

    private void Flip()
    {

        if (horizontal > 0f && !isFacingRight || horizontal < 0f && isFacingRight)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    
}
