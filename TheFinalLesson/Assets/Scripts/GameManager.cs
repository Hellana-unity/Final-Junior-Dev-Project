using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject human;
    public static GameObject[] target;
    public static int life;

    //public static object Instance { get; internal set; }


    private void Awake()
    {
        life = 10;
        target = new GameObject[6];

        for(int i=0; i<6; i++)
        {
            target[i] =  new GameObject();
        }
        target[0].transform.position = new Vector3(-16, 1, 0);
        target[1].transform.position = new Vector3(-5, 1, 2);
        target[2].transform.position = new Vector3(4, 1, 3);
        target[3].transform.position = new Vector3(10, 1, 3);
        target[4].transform.position = new Vector3(13, 1, -6);
        target[5].transform.position = new Vector3(9, 1, -26);
    }


    // Start is called before the first frame update
    void Start()
    {     
        StartCoroutine("SpawnEnemy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected IEnumerator SpawnEnemy()
    {
        
        while (true)
        {
            yield return new WaitForSeconds(5);
            Instantiate(human, transform.position, transform.rotation);
        }
        
    }

    public static void loose()
    {
        life -= 1;
        Debug.Log(life);
    }
}
