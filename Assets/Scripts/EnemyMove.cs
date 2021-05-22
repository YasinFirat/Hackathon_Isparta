using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyMove : MonoBehaviour
{
    public MovePoint movePoint;
    void Start()
    {
        movePoint.StartPosition();
        movePoint.transform = transform;
       
    }
    void FixedUpdate()
    {
        movePoint.MoveToNextPoint();
       
        if (movePoint.Arrive(1))
        {
            movePoint.CheckPointCounter();
        }
       
    }
   
}
