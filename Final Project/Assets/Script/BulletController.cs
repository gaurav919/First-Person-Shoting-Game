using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float moveSpeed, lifeTime;
    public Rigidbody theRB;
    public GameObject impactEffect;
    public bool damageEnemy, damageplayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = transform.forward * moveSpeed;
        lifeTime -= Time.deltaTime; //how long each frame will occur in a screen
        if(lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag == "Enemy" && damageEnemy)
        {
          other.gameObject.GetComponent<EnemyHealthController>().DamageEnemy();
        }

        if(other.gameObject.tag=="Player" && damageplayer)
        {
            other.gameObject.GetComponent<PlayerHealth>().DamagePlayer();
        }

        if (other.gameObject.tag == "finish")
        {
            Destroy(gameObject);
        }
        Destroy(gameObject);
        Instantiate(impactEffect, transform.position, transform.rotation);
    }
}
