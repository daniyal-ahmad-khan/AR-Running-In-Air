using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelMov : MonoBehaviour
{
    private Vector3 newPos;
    public float barrelSpeed; 
    
    private int rnd;
    void Start(){
        newPos = new Vector3(barrelSpeed*Time.deltaTime,0, 0);
    }
    void FixedUpdate()
    {   
        
        if(transform.position.x >= 3.0f)
        {
            // newPos = new Vector3(0,0,0);
            newPos = -newPos;
            
        }
        else if(transform.position.x <= -3.0f)
        {
            // newPos = new Vector3(0,0,0);
            newPos = -newPos;
        }
        transform.position += newPos;

    }
}
