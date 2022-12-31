using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Settings")]
    public float jump = 500f;
    public float gravity = 2.5f;
    public GameObject feathersParticles;
    
    private bool start = false;
    private bool finish = false;
    private Rigidbody2D playerbody;
    private Vector2 impulse;

    public GameController myGameController;
  
    void Start()
    {
       playerbody = GetComponent<Rigidbody2D>();
       impulse = new Vector2(0,jump);
        
    }

    
    void Update()
    {
        if (!finish)
        {
            if(Input.GetButtonDown("Fire1") || Input.GetKeyDown("space") )
            {
                if(!start)
                {
                   playerbody.gravityScale = gravity;
                   start = true;
                   //myGameController.GameStart();
                }

                playerbody.velocity = new Vector2(0,0);
                playerbody.AddForce(impulse);
            
                GameObject featherAnim = Instantiate(feathersParticles);
                featherAnim.transform.position = this.transform.position;
            }
            transform.rotation = Quaternion.Euler(0,0,playerbody.velocity.y * 3);
        }
        AreaLimit();
   
    }

    private void AreaLimit() { // Exceeded the upper or lower area
        float heightPlayPixel = Camera.main.WorldToScreenPoint(transform.position).y;

        if(heightPlayPixel > Screen.height + 200 || heightPlayPixel < 0)
        {
            FinishGame();   
        } 
    }

    void OnCollisionEnter2D() { // Collision with Enemy
        FinishGame();
    }

    private void FinishGame()
    {
        if (!finish)
        {
            finish = true;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(200,-10));
            GetComponent<Rigidbody2D>().AddTorque(300f);
            GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.5f, 0.5f);
            myGameController.GameOver();
        
        }
    }
}
