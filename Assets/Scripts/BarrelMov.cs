using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelMov : MonoBehaviour
{
    private Vector3 newPos;
    public float barrelSpeed =1.5f; 
    
    private int rnd;
    void Start(){
        rnd = Random.Range(0,3);
        newPos = new Vector3(barrelSpeed*Time.deltaTime,0, 0);
    }
    void Update()
    {   
        
        if(transform.position.x >= 3.0f)
        {
            // newPos = new Vector3(0,0,0);
            newPos = -newPos;
        }
        if(transform.position.x <= -3.0f)
        {
            // newPos = new Vector3(0,0,0);
            newPos = -newPos;
        }
        transform.position += newPos;
        if (rnd == 1)
        {
            
            
            transform.Rotate(60 * Time.deltaTime,0,10 * Time.deltaTime);
            
        }
        else if(rnd == 0) transform.Rotate(0, 60 * Time.deltaTime, 10 * Time.deltaTime);
        else Destroy(gameObject);

    }
}
