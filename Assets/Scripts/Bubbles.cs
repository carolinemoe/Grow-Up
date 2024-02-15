using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubbles : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(this.gameObject);
        if (col.gameObject.tag == "evilBubble")
        {
            Destroy(this.gameObject);
        }
    }
    

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x + speed, rb.velocity.y);
    }
}
