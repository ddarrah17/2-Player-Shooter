using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript2 : MonoBehaviour
{
    public float speed = -15.0f;
    public float damage2 = 10;

    public Rigidbody2D rb2;

    // Use this for initialization
    void Start()
    {
        rb2.velocity = transform.right * speed;
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
        Player1Script p1 = hitInfo.GetComponent<Player1Script>();
        if (p1 != null)
        {
            p1.TakesDamage1(damage2);
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
