using UnityEngine;

public class PlayerCollision : MonoBehaviour{
 
    public PlayerMovement movement;

    public GameObject orange_Donut;
    
    private Rigidbody2D rb;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D (Collision2D col)
    {
        if(col.collider.name == "Zombie(Clone)"){
            PlayerTakeDamage(20);
            Debug.Log(GameManager.gameManager._playerHealth.Health);
            
        }

        if(col.collider.name == "orange_Donut(Clone)"){
            PlayerHeal(10);
            Destroy(col.gameObject);
            Debug.Log(GameManager.gameManager._playerHealth.Health);
            spawnOrangeDonut();
        }
    }

    private void PlayerTakeDamage(int damage){

        GameManager.gameManager._playerHealth.DamageUnit(damage);
    }

    private void PlayerHeal(int healing){
        GameManager.gameManager._playerHealth.HealUnit(healing);
    }

    private void spawnOrangeDonut(){

        bool orangeSpawned = false;
        while (!orangeSpawned){
            Vector3 orangePosition = new Vector3(Random.Range(-9f, 9f), Random.Range(0f, 2f), 0f);
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
