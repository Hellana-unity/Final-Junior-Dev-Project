using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    private int life = 10;
    protected float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    protected void Update()
    {
        MoveToEndPoint();
        if(this.life <= 0)
        {
            Die();
        }
    }

    private void Die( )
    {
        Destroy(this.gameObject);
    }

    protected abstract void MoveToEndPoint();

    protected void EnemyPass()
    {
        GameManager.loose();
        Die();
    }

    public void TakeDamage(int damage)
    {
        this.life -= damage;
        Debug.Log("Life = " + life);
    }

}
