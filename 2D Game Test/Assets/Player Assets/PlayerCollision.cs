using UnityEngine;

public class PlayerCollision : MonoBehaviour{
 
    public PlayerMovement movement;

    public GameObject Zombie;

    public GameObject orange_Donut;
    
    private Rigidbody2D rb;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D (Collision2D col)
    {
        if(col.collider.name == "Zombie(Clone)"){
            if(transform.position.y > -0.5){
                EnemyTakeDamage(20);
                if(GameManager.gameManager._enemyHealth.Health <= 0){
                    Destroy(col.gameObject);
                    SpawnZombie();
                }
            }

            else{
                PlayerTakeDamage(20);
            }
        }

        if(col.collider.name == "orange_Donut(Clone)"){
            PlayerHeal(10);
            Destroy(col.gameObject);
            spawnOrangeDonut();
        }
    }

    private void PlayerTakeDamage(int damage){

        GameManager.gameManager._playerHealth.DamageUnit(damage);
    }

    private void PlayerHeal(int healing){
        GameManager.gameManager._playerHealth.HealUnit(healing);
    }

    private void EnemyTakeDamage(int damage){

        GameManager.gameManager._enemyHealth.DamageUnit(damage);
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
}
