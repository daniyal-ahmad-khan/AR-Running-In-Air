using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    public Transform[] view;
    public int transspeed;
    void LateUpdate()
    {
        if (PlayerManager.numberOfCoins == 5){
            //transition
            transform.position = Vector3.Lerp(transform.position,view[1].position,Time.deltaTime*transspeed);
            transform.rotation = view[1].rotation;
        }
        else if (PlayerManager.numberOfCoins == 15){
            transform.position = Vector3.Lerp(transform.position,view[0].position,Time.deltaTime*transspeed);
            transform.rotation = view[0].rotation;
        }
        
    }
}
