using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{

    public static PlayerHealth instance;
    // Start is called before the first frame update
    public int  currentHealth;
    public string nextlevel;
   
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamagePlayer()
    {
        currentHealth -= 1;
        if(currentHealth <= 0)
        {
            SceneManager.LoadScene(nextlevel);
            //gameObject.SetActive(false);
        }
    }
}
