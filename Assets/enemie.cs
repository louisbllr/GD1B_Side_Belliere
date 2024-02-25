using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemie : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rgbd;
    private Animator anim;
    private Transform currentPoint;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = pointB.transform;
        anim.SetBool("isRunning", true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pointB.transform)
        {
            rgbd.velocity = new Vector2(speed, 0);
        }
        else
        {
            rgbd.velocity = new Vector2(-speed, 0);
        }


        if(Vector2.Distance(transform.position, currentPoint.position)< 0.5f && currentPoint == pointB.transform) 
        {
            currentPoint = pointA.transform;        
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            currentPoint = pointB.transform;
        }
    }
}
