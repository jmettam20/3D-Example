using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public float enemySpeed;
    public Vector3 enemyMoveDirection; 
    public float enemyMoveDistance; 

    private Vector3 enemyStartPos;
    private bool movingToStart; 

    // Start is called before the first frame update
    void Start()
    {
        enemyStartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        enemyMovement();
    }

    void enemyMovement(){

        if(movingToStart){
            transform.position = Vector3.MoveTowards(transform.position,enemyStartPos,enemySpeed * Time.deltaTime);

            if(transform.position == enemyStartPos){
                movingToStart = false; 
            }
        }else{
            transform.position = Vector3.MoveTowards(transform.position,enemyStartPos + (enemyMoveDirection * enemyMoveDistance),enemySpeed * Time.deltaTime);

            if(transform.position == enemyStartPos + (enemyMoveDirection * enemyMoveDistance)){
                movingToStart = true; 
            }
        }
    }

     private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            other.GetComponent<PlayerScript>().gameOver(); 
        }
    }
}
