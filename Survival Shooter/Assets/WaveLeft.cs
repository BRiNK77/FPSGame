using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveLeft : MonoBehaviour
{
    public Text waveLeft;
    public GameObject gameControl;
    public int wave = 5;
    public int killed = 0;

    void Start()
    {
        waveLeft = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        string left = (wave - killed).ToString();
        waveLeft.text = left;
        if((wave - killed) <= 0)
        {
            gameControl.GetComponent<GameCon>().setCleared(true);
        }
    }

    public void killIncrease(int num)
    {
        killed = killed + num;
    }
    public void setWave(int count)
    {
        wave = count;
    }
    public void resetKills()
    {
        killed = 0;
    }
}
