using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class donut : MonoBehaviour
{
 void Update()
    {
        //transform.Rotate(0,0,20 * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<AudioManager>().PlaySound("PickUp");
            PlayerManager.numberOfSpecialCoins +=1;
            Destroy(gameObject);
            
        }
    }
}
