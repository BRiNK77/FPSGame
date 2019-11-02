using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveLeft : MonoBehaviour
{
    public Text waveLeft;
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
    }
}
