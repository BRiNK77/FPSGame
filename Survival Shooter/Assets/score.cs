using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public Text scoreN;
    public static int trueS = 0;

    void Start()
    {
        scoreN = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreN.text = "Score: " + trueS.ToString();
    }

    public void newScore(int num)
    {
        trueS = trueS + num;
    }
}
