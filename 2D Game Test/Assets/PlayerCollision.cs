using UnityEngine;

public class PlayerCollision : MonoBehaviour{
 
    public PlayerMovement movement;

    public GameObject orange_Donut;
    
    void OnCollisionEnter2D (Collision2D col)
    {
        if(col.collider.name == "Zombie(Clone)"){
            PlayerTakeDamage(20);
            Debug.Log(GameManager.gameManager._playerHealth.Health);
            
        }

        if(col.collider.name == "orange_Donut(Clone)"){
            PlayerHeal(10);
            Destroy(col.gameObject);
        }
    }

    private void PlayerTakeDamage(int damage){

        GameManager.gameManager._playerHealth.DamageUnit(damage);
    }

    private void PlayerHeal(int healing){
        GameManager.gameManager._playerHealth.HealUnit(healing);
    }
}

