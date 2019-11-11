using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyCon : MonoBehaviour
{
    Animator anim;
    public int HP = 2; // the amount of health for the enemy
    //int DMG = 1;
    public GameObject player;
    public GameObject enemy;
    public Camera mainCam;
    public bool death = false;
    public int minDist = 1;
    public float deathTime = 4.0f;

    void Start()
    {
        anim = GetComponent<Animator>(); // gets animator for setting up variables
        player = GameObject.FindGameObjectWithTag("Player");
        mainCam = Camera.main;
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
        anim.SetFloat("attack", attack);

        // sends enemy to player position
        GetComponent<NavMeshAgent>().destination = player.transform.position;

        if(Vector3.Distance(transform.position, player.transform.position) <= minDist)
        {
            GetComponent<NavMeshAgent>().destination = transform.position;
            attack = 1.0f;
            anim.SetFloat("attack", attack);
            Camera mainCam = Camera.main;

        }

        
        // destroys enemy after a set time to allow death animation
        if(HP <= 0 )
        {
            death = true;
            anim.SetBool("dead", death);
            GetComponent<NavMeshAgent>().speed = 0;
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
    
    public void isDead()
    {
        this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
        mainCam.GetComponent<Shoot>().applyKill();
    }
}
