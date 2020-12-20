using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_follow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;

    void LateUpdate()
    {   
        //position
        Vector3 newPosition = new Vector3(player.position.x,transform.position.y,player.position.z);
        transform.position = Vector3.Lerp(transform.position,newPosition,100*Time.deltaTime);       

        //rotate
        transform.RotateAround(player.transform.position,Vector3.up,60*Time.deltaTime);
    }
}
