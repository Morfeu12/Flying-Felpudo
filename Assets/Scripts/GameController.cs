using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("Set Enemy Game Object")]
    public GameObject enemyPrefab;
    public List<GameObject> enemys = new List<GameObject>();
    private GameObject player;
    private Text pressStart;
    private Text textScore;
    private int score;
    private bool gamestart = false;
    private bool gameover = false;

    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        textScore = GameObject.Find("Score").GetComponent<Text>();
        pressStart = GameObject.Find("Press Start").GetComponent<Text>();
        pressStart.text = "Touch for start";
        // InvokeRepeating("RespawnEnemys", 1.0f, 1.5f);
        
    }

    
    void Update()
    {
        if(!gameover) {
            CheckPoints();
        }
        CanvasGUI();
        

    }


    private void RespawnEnemys() 
    {
        if(!gameover) {
            float heightRandom = 10.0f * Random.value - 5;
            GameObject newEnemy = Instantiate(enemyPrefab);
            newEnemy.transform.position = new Vector2(15.0f, heightRandom);
            enemys.Add(newEnemy);
        }

    }

    public void CheckPoints(){

        foreach (var enemy in enemys.ToArray())
        {
            if(enemy != null){
                if(player.transform.position.x > enemy.transform.position.x) {
                    enemys.Remove(enemy);
                    score++;
                }

            }

        }
        
    }

    private void CanvasGUI() {
        if (!gamestart) {
            if(Input.GetButtonDown("Fire1") || Input.GetKeyDown("space") ) {       
                Destroy(pressStart);
                InvokeRepeating("RespawnEnemys", 1.0f, 1.5f);
                gamestart = true;
            }
        }
        textScore.text = "Score: " + score.ToString();
    }


    public void GameOver() {
        gameover = true;
    }


    
}
