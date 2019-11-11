using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCon : MonoBehaviour
{
    // locations for all spawn points and gameobject for spawning
    public Transform[] spawnLocs;
    public GameObject mutant;
    public GameObject[] spawnClones;

    // UI related components
    
    public static int killed = 0;
    public static int waveCon = 5;
    public static int count;
    public static int num;
    public static int roundNum = 1;
    public static int wave;
    //public Text ScoreNum;
    public Text waveNumber;
    public Text waveRemain;

    // Spawn variables

    float spawnTime = 4.0f;
    bool cleared = false;
    public static int scaleE = 2;

    void Start()
    {
        count = waveCon; // sets initial number of enemies to spawn
    }

    
    void Update()
    {
        spawnTime -= Time.deltaTime;    // takes away from spawn timer
        if(spawnTime < 0 && count > 0)  // checks if spawn timer is below zero and count is greater than zero,
        {                               // if so, will call SpawnEnemy, reset spawn timer, and decrease spawn count
            SpawnEnemy();
            spawnTime = 4.0f;
            count -= 1;
        }

        
        if (cleared)
        {
            // possible next round declaration
            roundNum = roundNum + 1; // updates round number when all monsters cleared
            waveNumber.GetComponent<waveNum>().setWave(roundNum);
            waveCon = (waveCon + 2);
            waveRemain.GetComponent<WaveLeft>().setWave(waveCon);
            waveRemain.GetComponent<WaveLeft>().resetKills();
            count = waveCon;
            cleared = false;
        }
        

        
        
    }

    public void SpawnEnemy()
    {
        num = Random.Range(0, 7);
      // spawns a clone of a given prefab, in order to create multiple instances that can be spawned and deleted 
      spawnClones[0] = Instantiate(mutant, spawnLocs[num].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
         
    }
    public void setCleared(bool con)
    {
        cleared = con;
    }
}
