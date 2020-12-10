using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(60 * Time.deltaTime,0,20 * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<AudioManager>().PlaySound("PickUp");
            PlayerManager.numberOfCoins +=1;
            Destroy(gameObject);
            
        }
    }
}
