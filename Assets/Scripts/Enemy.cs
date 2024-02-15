using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour
{
    private bool attacking = false;
    private Animator _animator;
    private float playerEnemyDistance;
    [SerializeField] int health;
    [SerializeField] float attackSpeed;
    [SerializeField] float attackDistance;
    [SerializeField] GameObject projectile;
    public GameObject player;
   

    // Start is called before the first frame update
    void Start()
    {
         player = GameObject.FindGameObjectWithTag("Player");
        //get animator
        getAni();

    }

    // Update is called once per frame
    void Update()
    {
       
        //get player enemy distance
        playerEnemyDistance = (Math.Abs(player.transform.position.x - this.gameObject.transform.position.x));
        Debug.Log(playerEnemyDistance);

        //trigger attack sequence if player close enough
        while ((playerEnemyDistance <= attackDistance)&& !attacking)
        {
            attacking = true;
            InvokeRepeating("Attack", 1.0f, attackSpeed);
        }

        if(playerEnemyDistance > attackDistance)
        {
            attacking=false;
        }
        Debug.Log(attacking);
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
        if (!attacking)
        {
            _animator.ResetTrigger("attack");
            if (!_animator.GetBool("idle"))
            {
                _animator.SetBool("idle", true);
            }
        }
        if (attacking)
        {
            _animator.SetBool("idle", false);
        }


    }



    /*void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "bubble")
        {
            health--;
        }
        else if (col.gameObject.tag == "hit")
        {
            health = health - 2;
            Debug.Log("hit");
        }
    }*/

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "bubble")
        {
            health--;
        }
        else if (col.gameObject.tag == "hit")
        {
            health = health - 2;
            Debug.Log("hit");
        }
    }

    void Attack()
    {
        if (attacking)
        {
            _animator.SetTrigger("attack");
            if (projectile != null)
            {
                projectile = Instantiate(projectile, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0), Quaternion.identity);

            }
        }
    }

    private void getAni()
    {
        _animator = GetComponent<Animator>();
    }

    
}
