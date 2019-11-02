using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyCon : MonoBehaviour
{
    Animator anim;
    public int HP = 4; // the amount of health for the enemy
    //int DMG = 1;
    public GameObject player;
    public GameObject enemy;
    public bool death = false;
    
    public int minDist = 1;

    void Start()
    {
        anim = GetComponent<Animator>(); // gets animator for setting up variables
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // constantly checks for updates on these variables to update the animator
        float forward = Input.GetAxis("Vertical");
        float sideways = Input.GetAxis("Horizontal");
        float attack = 0;

        // sets floats in the animator based off in game floats
        anim.SetFloat("forward", forward);
        anim.SetFloat("sideways", sideways);
       // anim.SetBool("dead", health);
        anim.SetFloat("attack", attack);

        // sends enemy to player position
        GetComponent<NavMeshAgent>().destination = player.transform.position;

        if(Vector3.Distance(transform.position, player.transform.position) <= minDist)
        {
            GetComponent<NavMeshAgent>().destination = transform.position;
            attack = 1.0f;
            anim.SetFloat("attack", attack);

        }

        
        // destroys enemy after a set time to allow death animation
        if(HP <= 0)
        {
            death = true;
            anim.SetBool("dead", death);
            GetComponent<NavMeshAgent>().speed = 0;
            float deathTime = 4.0f;
            Destroy(enemy, deathTime);
            
        }
        
        
    }
    
    public void AttackEnd()
    {
       // player.GetComponent<PlayerCon>.damageChar(DMG);
        
    }
    public void damageEnemy(int DMG)
    {
        HP = HP - DMG;
    }
    
    
}
