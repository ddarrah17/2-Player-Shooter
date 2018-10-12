using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
    public float speed = 15.0f;
    public float damage1 = 10; 

    public Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb.velocity = transform.right * speed; 
        //rb2d = GetComponent<Rigidbody2D>();

        /*var velocity = rb2d.velocity;
        velocity.x = speed;
        velocity.y = speed;
        rb2d.velocity = velocity;
        */
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        Player2Script p2 = hitInfo.GetComponent<Player2Script>();
        if (p2 != null)
        {
            p2.TakesDamage2(damage1);
            Destroy(gameObject);
        }
        else if (hitInfo.name == "Background")
        {
            Destroy(gameObject);
        } 
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
