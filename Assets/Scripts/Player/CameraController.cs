using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    private Vector3 offSet;
    private int scale = 100;
    // Start is called before the first frame update
    void Start()
    {
        offSet = transform.position - target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {       
        Vector3 newPosition = new Vector3(transform.position.x,transform.position.y,offSet.z+target.position.z);
        transform.position = Vector3.Lerp(transform.position,newPosition,100*Time.deltaTime);


    }
}
