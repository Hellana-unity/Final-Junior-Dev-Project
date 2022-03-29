using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    float bulletSpeed = 7.0f;
    private int damage = 2;
    public Enemy target;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target.isActiveAndEnabled && Vector3.Distance(transform.position, target.transform.position) > 1.5f)
        {
            float step = bulletSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
            Vector3 targetDirection = target.transform.position - transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, step, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
        else
        {
            target.TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }

}
