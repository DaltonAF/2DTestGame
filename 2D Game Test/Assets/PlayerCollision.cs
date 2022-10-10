using UnityEngine;

public class PlayerCollision : MonoBehaviour{
 
    public PlayerMovement movement;
    
    void OnCollisionEnter2D (Collision2D col)
    {
        if(col.collider.name == "Zombie(Clone)"){
            PlayerTakeDamage(20);
            Debug.Log(GameManager.gameManager._playerHealth.Health);
            
        }
    }

    private void PlayerTakeDamage(int damage){

        GameManager.gameManager._playerHealth.DamageUnit(damage);
    }

}
