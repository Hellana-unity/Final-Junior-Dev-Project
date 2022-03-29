using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : Enemy
{
    [SerializeField] Vector3  spawnPosition = new Vector3(-25,1,-2);
    private GameObject currentTarget;
    private int currentTargetNb;
    private Animator animator;

    // Start is called before the first frame update
    private void Awake()
    {
        animator = this.GetComponent<Animator>();
        animator.Play("Base Layer.ghoul_spawn");
    }

    void Start()
    {
        speed = 2.5f;
        transform.SetPositionAndRotation(spawnPosition, transform.rotation);
        currentTargetNb = 0;
        currentTarget = GameManager.target[currentTargetNb];

    }

    // Update is called once per frame
    
    /*void Update()
    {
        
    }*/

    protected override void MoveToEndPoint()
    {
         animator.SetFloat("speed", speed);
        //animator.Play("Base Layer.ghoul_walk0");
        currentTarget = GameManager.target[currentTargetNb];
        float step = speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, currentTarget.transform.position) < 1.5f)
        {
            if(currentTargetNb == 5)
            {
                //On détruit et on baisse le score
                EnemyPass();
            }
            else
            {
                currentTargetNb += 1;
                currentTarget = GameManager.target[currentTargetNb];
            }
            
        }
        else
        {   
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.transform.position, step);
            Vector3 targetDirection = currentTarget.transform.position - transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, step, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);


        }
        
    }


}
