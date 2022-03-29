using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tower : MonoBehaviour
{

    [SerializeField] GameObject tower;
    [SerializeField] Projectile projectile;

    private bool isTowerCreated;
    private GameObject[] enemies;
    private float range = 10.0f;
    private float delay = 1.5f;
    private bool hasShoot = false;
    private float timeShoot;

    // Start is called before the first frame update
    void Start()
    {
        isTowerCreated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTowerCreated)
        {
            if (Time.time - timeShoot > delay)
            {
                hasShoot = false;
            }
            enemies = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject enemy in enemies)
            {
                Enemy enemyC = enemy.GetComponent<Enemy>();
                float distance = Vector3.Distance(transform.position, enemyC.transform.position);

                //Debug.Log(distance);
                if (distance < range && hasShoot == false)
                {
                    Shoot(enemyC);
                }
            }
        }

    }

    protected void Shoot(Enemy enemy)
    {

        Projectile newProjectile = Instantiate(projectile, transform.position, transform.rotation);
        newProjectile.target = enemy;
        hasShoot = true;
        timeShoot = Time.time;
    }

    void OnMouseDown()
    {
        if (!isTowerCreated)
        {
            Instantiate(tower, this.transform.position, this.transform.rotation);
            isTowerCreated = true;
        }
    }
}
