using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    // Start is called before the first frame update

    public int currentHealth = 3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DamageEnemy()
    {
        currentHealth -= 1;
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
