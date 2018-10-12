using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1Script : MonoBehaviour {
    Vector3 speed = new Vector3(0.05f, 0.0f, 0.0f);
    public float rotationSpeed = 1.3f; 
    public KeyCode MoveForward = KeyCode.W;
    public KeyCode MoveBackward = KeyCode.S;
    public KeyCode rotateRight = KeyCode.D;
    public KeyCode rotateLeft = KeyCode.A;
    public float health1 = 100;
    public Image healthbar; 
    private Rigidbody2D rb2d;
    public GUISkin layout;
    public bool gameOver1 = false; 
    
    // Use this for initialization
    void Start () {
        gameObject.AddComponent<PolygonCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(rotateLeft)){
            RotateLeft();
        }
        if(Input.GetKey(rotateRight)){
            RotateRight();
        }
        if(Input.GetKey(MoveForward)){
            transform.Translate(speed); 
        }
        if(Input.GetKey(MoveBackward)){
            transform.Translate(-speed);
        }
        if (gameOver1 == true && Input.GetKey(KeyCode.Space))
        {
            GameRestart();
        }
    }

    Vector3 RotateLeft()
    {
        transform.Rotate(Vector3.forward*rotationSpeed);
        //rb.transform.Rotate(Vector3.forward * rotationSpeed);
        return Vector3.forward * rotationSpeed; 
    }
    Vector3 RotateRight()
    {
        transform.Rotate(Vector3.back*rotationSpeed);
        //rb.transform.Rotate(Vector3.back * rotationSpeed);
        return Vector3.back * rotationSpeed;
    }

    public void TakesDamage1(float damage){
        health1 -= damage;
        healthbar.fillAmount = health1/100f;
        if (health1 <= 0){
            Player1Death();
            gameOver1 = true;
        }

    }

    private void OnGUI()
    {
        GUI.skin = layout;
            if (health1 <= 0)
        {
            GUI.Label(new Rect(Screen.width / 2 - 190, 200, 2000, 5000), "PLAYER TWO WINS");
            GUI.Label(new Rect(Screen.width / 2 - 300, 400, 3000, 7000), "Press 'Space' to Restart.");
        }
    }

    void GameRestart()
    {
        Vector3 zero = new Vector3(0, 0, 0);
        transform.position = new Vector3(-8, 0, -1);
        health1 = 100;
        healthbar.fillAmount = health1 / 100f;
    }

    void Player1Death(){
        transform.position = new Vector3(10000, 10000, 0);
    }
}
