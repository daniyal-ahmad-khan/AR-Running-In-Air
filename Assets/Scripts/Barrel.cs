using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{   
    private int rnd;
    void Start(){
        rnd = Random.Range(0,3);
    }
    
    void Update()
    {   
        if (rnd == 1)transform.Rotate(60 * Time.deltaTime,0,10 * Time.deltaTime);
        else if(rnd == 0) transform.Rotate(0, 60 * Time.deltaTime, 10 * Time.deltaTime);
        else Destroy(gameObject);
    }
}
