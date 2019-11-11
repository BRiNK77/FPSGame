using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{

    // for UI
    public Text scoreNum;
    public Text numLeft;
    public float nextFire;
    public float fireRate = 0.25f;
    

    public static int DMG = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // checks for fire button
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            // shoots ray, sends info to hitInfo
            nextFire = Time.time + fireRate;
            RaycastHit hitInfo;
            Physics.Raycast(transform.position, transform.forward, out hitInfo);
            // Debug.Log(hitInfo.collider.name + ", " + hitInfo.collider.tag);

            // checks if collider hit enemy
            if (hitInfo.collider.gameObject.name.Equals("Enemy(Clone)"))
            {
                // calls enemy damage function with given damage
                //Destroy(hitInfo.collider.gameObject);
                hitInfo.collider.gameObject.GetComponent<EnemyCon>().damageEnemy(DMG);
                
            }
            
        }
    }

    public void applyKill()
    {
        numLeft.GetComponent<WaveLeft>().killIncrease(1);
        scoreNum.GetComponent<score>().newScore(10);
    }
}
