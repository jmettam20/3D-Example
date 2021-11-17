using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public float coinRotationSpeed; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinRotation();
    }

    void coinRotation(){
        transform.Rotate(Vector3.up,coinRotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            other.GetComponent<PlayerScript>().addScore(1);
            Destroy(gameObject);
        }
    }

}
