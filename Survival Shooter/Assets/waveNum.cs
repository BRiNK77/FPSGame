using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class waveNum : MonoBehaviour
{
    public Text waveN;
    public int wave = 1;
    public bool cleared;
    void Start()
    {
        waveN = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        waveN.text = "Wave: " + wave.ToString();
        
    }

    public void setWave(int num)
    {
        wave = num;
    }
}
