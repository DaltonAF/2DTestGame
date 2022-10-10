using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public GameObject target;

    public GameObject Zombie;

    bool facingRight = true;

    // Start is called before the first frame update
    void Start(){
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
        
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 
        0.45f*Time.deltaTime);

        if(transform.position.x - target.transform.position.x > 0 && !facingRight){
            Flip();
            Debug.Log("Enemy is to your right.");
        }
        
        if(transform.position.x - target.transform.position.x < 0 && facingRight){
            Flip();
            Debug.Log("Enemy is to your left.");
        }
    }

    void Flip(){
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}
