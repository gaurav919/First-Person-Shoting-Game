using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody RB;
    private bool chasing;
    public float distanceToChase = 10f, distanceToLose = 15f;

    private Vector3 targetpoint;
    public GameObject bullet;
    public Transform firePoint;


    public float fireRate , waitBetweenShots = 1f , timeToShoot =1f;
    private float fireCount, shotWaitCounter ,shootTimeCounter;
    // Start is called before the first frame update

    void Start()
    {
        shootTimeCounter = timeToShoot;
        shotWaitCounter = waitBetweenShots;
        distanceToChase = 25;
    }

    // Update is called once per frame
    void Update()
    {
        //enemy dont look up and doen only look at x and y.
        targetpoint = PlayerController.instance.transform.position;
        targetpoint.y = transform.position.y;
        if (!chasing)
        {
            if (Vector3.Distance(transform.position, targetpoint) < distanceToChase)
            {
                chasing = true;
                shootTimeCounter = timeToShoot;
                shotWaitCounter = waitBetweenShots;
            }
        }
        else
        {

            // look at enemy
            transform.LookAt(targetpoint);

            RB.velocity = transform.forward * moveSpeed;


            if (Vector3.Distance(transform.position, targetpoint) > distanceToChase)
                {
                chasing = false;
                }

            if (shotWaitCounter > 0)
            {
                shootTimeCounter -= Time.deltaTime;

                if(shotWaitCounter <= 0)
                {
                    shootTimeCounter = timeToShoot;
                }
            }
            else
            {



                shootTimeCounter -= Time.deltaTime;

                if (shootTimeCounter > 0)
                {

                    fireCount -= Time.deltaTime;
                    if (fireCount <= 0)
                    {
                        fireCount = fireRate;
                        Instantiate(bullet, firePoint.position, firePoint.rotation);

                    }
                }

                else
                {
                    shotWaitCounter = waitBetweenShots;
                }
            }
        }
    }
}
