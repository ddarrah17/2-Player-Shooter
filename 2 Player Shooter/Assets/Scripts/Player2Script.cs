using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player2Script : MonoBehaviour {
    Vector3 speed = new Vector3(0.05f, 0.0f, 0.0f);
    public float rotationSpeed = 1.3f;
    public KeyCode MoveForward = KeyCode.UpArrow;
    public KeyCode MoveBackward = KeyCode.DownArrow;
    public KeyCode rotateRight = KeyCode.RightArrow;
    public KeyCode rotateLeft = KeyCode.LeftArrow;
    public float health2 = 100;
    public Image healthbar;
    public GUISkin layout;
    public bool gameOver2 = false; 

    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start () {
        gameObject.AddComponent<PolygonCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(rotateLeft))
        {
            RotateLeft();
        }
        if (Input.GetKey(rotateRight))
        {
            RotateRight();
        }
        if (Input.GetKey(MoveForward))
        {
            transform.Translate(-speed);
        }
        if (Input.GetKey(MoveBackward))
        {
            transform.Translate(speed);
        }
        if(gameOver2 == true && Input.GetKey(KeyCode.Space)){
            GameRestart();
        }
    }

    Vector3 RotateLeft()
    {
        transform.Rotate(Vector3.forward * rotationSpeed);
        //rb.transform.Rotate(Vector3.forward * rotationSpeed);
        return Vector3.forward * rotationSpeed;
    }
    Vector3 RotateRight()
    {
        transform.Rotate(Vector3.back * rotationSpeed);
        //rb.transform.Rotate(Vector3.back * rotationSpeed);
        return Vector3.back * rotationSpeed;
    }

    public void TakesDamage2(float damage)
    {
        health2 -= damage;
        healthbar.fillAmount = health2 / 100f;

        if (health2 <= 0)
        {
            Player2Death();
            gameOver2 = true; 
        }
    }

    private void OnGUI()
    {
        GUI.skin = layout;
        if (health2 <= 0)
        {
            GUI.Label(new Rect(Screen.width / 2 - 190, 200, 2000, 5000), "PLAYER ONE WINS");
            GUI.Label(new Rect(Screen.width / 2 - 300, 400, 3000, 7000), "Press 'Space' to Restart.");
        }
    }

    void GameRestart()
    {
        transform.position = new Vector3(8, 0, -1);
        health2 = 100;
        healthbar.fillAmount = health2 / 100f;

    }

    void Player2Death()
    {
        transform.position = new Vector3(10000, 10000, 0);
    }
}
