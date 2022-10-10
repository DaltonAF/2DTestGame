using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)){
            PlayerTakeDamage(20);
            Debug.Log(GameManager.gameManager._playerHealth.Health);
        }

        if(Input.GetKeyDown(KeyCode.RightShift)){
            PlayerHeal(10);
            Debug.Log(GameManager.gameManager._playerHealth.Health);
        }
    }

    private void PlayerTakeDamage(int damage){

        GameManager.gameManager._playerHealth.DamageUnit(damage);
    }

    private void PlayerHeal(int healing){

        GameManager.gameManager._playerHealth.HealUnit(healing);
    }
}
