using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public GameObject Zombie;

    public GameObject orange_Donut;

    public CharacterController2D controller;

    public float walkSpeed = 15f;

    public float sprintSpeed = 25f;

    float horizontalMove = 0f;

    float realSpeed;

    bool jump = false;

    public float zombieSpeed = 7f;
    

    void Start(){

        SpawnZombie();
        spawnOrangeDonut();

    }

    // Update is called once per frame
    void Update(){

        realSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;

        horizontalMove = Input.GetAxisRaw("Horizontal") * realSpeed;

        if (Input.GetButtonDown("Jump")){
            jump = true;
        } 
        
    }

    void OnGUI(){

        GUIStyle myStyle = new GUIStyle();

        Font myFont = (Font)Resources.Load("Fonts/VideoGameFont", typeof(Font));
        myStyle.font = myFont;


        myStyle.fontSize = 50;
        GUI.Label(new Rect(80,455,100,20), "Health: " + GameManager.gameManager._playerHealth.Health.ToString(), myStyle);
}

    void FixedUpdate(){

        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    private void SpawnZombie(){

        bool zombieSpawned = false;
        while (!zombieSpawned){
            Vector3 zombiePosition = new Vector3(Random.Range(-12f, 12f), 0f, 0f);
            if ((zombiePosition - transform.position).magnitude < 12){
                continue;
            }
            else{
                Instantiate(Zombie, zombiePosition, Quaternion.identity);
                zombieSpawned = true;
            }
        }
    }

    private void spawnOrangeDonut(){

        bool orangeSpawned = false;
        while (!orangeSpawned){
            Vector3 orangePosition = new Vector3(Random.Range(-9f, 9f), -1.5f, 0f);
            if((orangePosition - transform.position).magnitude < 8){
                continue;
            }
            else{
                Instantiate(orange_Donut, orangePosition, Quaternion.identity);
                orangeSpawned = true;
            }
        }
    }
}

