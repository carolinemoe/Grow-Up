using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilBubbles : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("enemy");
        Physics2D.IgnoreCollision(enemy.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //Destroy(this.gameObject);
        if (col.gameObject.tag == "bubble")
        {
            Destroy(this.gameObject);
        }
        if (col.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }

    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x - speed, rb.velocity.y);
    }
}
