using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public Transform target;
    public Vector3 offset; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cameraFollow();
    }

    void cameraFollow(){
        transform.position = target.position + offset; 

    }
}
