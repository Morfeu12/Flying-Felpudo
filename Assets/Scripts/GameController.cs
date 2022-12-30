using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Set Enemy Game Object")]
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("RespawnEnemys", 1.0f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RespawnEnemys() 
    {
        float heightRandom = 10.0f * Random.value - 5;
        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.position = new Vector2(15.0f, heightRandom);

    }
}
