using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PlayerScript : MonoBehaviour
{

    public float playerSpeed; 
    private Rigidbody rb; 
    public float playerJumpForce; 
    private bool isGrounded; 
    public int playerScore; 

    public UI ui; 

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        playerController(); 
        outOfBounds();
    }

    private void playerController(){
        //MOVE X/Z
        float moveX = Input.GetAxis("Horizontal") * playerSpeed; //x input
        float moveZ = Input.GetAxis("Vertical")* playerSpeed;//z input

        rb.velocity = new Vector3(moveX,rb.velocity.y,moveZ); // move player


        Vector3 vel=rb.velocity; 
        vel.y=0; 

        if(vel.x !=0 || vel.z !=0){//if moving in x or z dir - stops snapping back to default direction when movement stops 
            transform.forward = vel; //face drection 
        }
        
        //MOVE Y (JUMP)
        if(Input.GetKeyDown(KeyCode.Space)&& isGrounded == true){
            isGrounded = false; 
            rb.AddForce(Vector3.up * playerJumpForce,ForceMode.Impulse);//jump on spacebar press

        }
    }

     void OnCollisionEnter(Collision other) {
        if(other.contacts[0].normal == Vector3.up){
            isGrounded = true; 
        }
    }

    private void outOfBounds(){
        if(transform.position.y < -10){
            gameOver();
        }
    }
    public void gameOver(){
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void addScore(int amount){
        playerScore += amount;
        ui.setScoreText(playerScore);
    }
}
