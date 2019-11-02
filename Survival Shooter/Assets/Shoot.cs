using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public static int DMG = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // checks for fire button
        if (Input.GetButton("Fire1"))
        {
            // shoots ray, sends info to hitInfo
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

    
}
