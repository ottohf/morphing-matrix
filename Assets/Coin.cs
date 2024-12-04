using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField]
    private FloatSO coinSO;
   
    bool ObjectIsCoin(GameObject component)
    {
        if (component.CompareTag("Coin")){
            return true;
        }
        else
        {
            return false;
        } 
        

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (ObjectIsCoin(collider.gameObject)) {
            print("Before collecting coin, user had " + coinSO.Value + "coins");
            coinSO.Value += 1;
            print("got a coin, now have "+coinSO.Value);
        }
    }

}