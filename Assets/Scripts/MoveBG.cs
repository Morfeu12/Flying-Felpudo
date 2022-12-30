using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBG : MonoBehaviour
{
    private float imgWidth;  
    private float imgHeight;
    private float screenHeight;
    private float screenWidth;
    
    void Start()
    {
        BackgroundOnScreen();
        if(this.name == "bgGame@2")
        {
            transform.position = new Vector2(screenWidth, 0f);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveBackground();
    }

    private void BackgroundOnScreen() // Get camera (screen) size and apply to bg image
    {   
        
        SpriteRenderer grafic = GetComponent<SpriteRenderer>();

        imgWidth  = grafic.sprite.bounds.size.x;
        imgHeight = grafic.sprite.bounds.size.y;

        // OrthographicSize get /2 size screen
        screenHeight = Camera.main.orthographicSize * 2f;
        screenWidth = screenHeight / Screen.height * Screen.width;

        Vector2 newScale = transform.localScale;
        newScale.x = screenWidth / imgWidth + 0.1f;
        newScale.y = screenHeight / imgHeight;
        this.transform.localScale = newScale; 
        
    }

    private void MoveBackground()
    {
        // -3 is the velocity the BG move
        // Off(0) gravity at inpector 
        GetComponent<Rigidbody2D>().velocity = new Vector2(-3,0);

        
        
        if(transform.position.x <= -screenWidth)
        {
            transform.position = new Vector2(screenWidth, 0f);

        }
    }


}
