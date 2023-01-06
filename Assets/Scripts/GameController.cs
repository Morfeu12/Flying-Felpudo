using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Header("Set Enemy Game Object")]
    public GameObject enemyPrefab;
    public List<GameObject> enemys = new List<GameObject>();
    private GameObject player;
    private GameObject playAgainPanel;
    private Text pressStart;
    private Text textScore;
    private int score;
    private bool gamestart = false;
    private bool gameover = false;

    
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        playAgainPanel = GameObject.Find("Play Again Panel");
        textScore = GameObject.Find("Score").GetComponent<Text>();
        pressStart = GameObject.Find("Press Start").GetComponent<Text>();
        pressStart.text = "Touch for start";
    }

    
    void Update()
    {
        if(!gameover) {
            CheckPoints();
        } else if (gameover) {
            Invoke("PlayAgain", 0.3f);
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
            if(Input.GetButtonDown("Fire1") || Input.GetKeyDown("space") || Input.GetKeyDown("return")) {       
                playAgainPanel.SetActive(false);
                pressStart.text = "";
                InvokeRepeating("RespawnEnemys", 1.0f, 1.5f);
                gamestart = true;
            }
        } else {
            textScore.text = "Score: " + score.ToString();
        }
        if (gameover) {
            playAgainPanel.SetActive(true);
            pressStart.text = "Touch for Play again";
            pressStart.transform.position = new Vector2(Screen.width/2,Screen.height/2 - 50);
            textScore.transform.position  = new Vector2(Screen.width/2,Screen.height/2 + 40);
            textScore.fontSize = 100;

        }
    }

    private void PlayAgain() {
        if(Input.GetButtonDown("Fire1") || Input.GetKeyDown("space") || Input.GetKeyDown("return") ) { 
            SceneManager.LoadScene("Game", LoadSceneMode.Single);
        }
    }


    public void GameOver() {
        gameover = true;
    }


    
}
