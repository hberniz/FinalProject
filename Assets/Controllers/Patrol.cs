using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float StartWaitTime;

    public Transform[] moveSpots;
    private int randomSpot;
    // Start is called before the first frame update
    void Start()
    {
        waitTime = StartWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    // Update is called once per frame
    void Update()
    {
        
        //print(moveSpots[randomSpot].position);
        transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, moveSpots[randomSpot].position)< 1.0f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = StartWaitTime;
            }
        }
        waitTime -= Time.deltaTime;
    }
}
