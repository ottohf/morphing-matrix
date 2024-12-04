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
            coinSO.Value += 1;
            collider.gameObject.SetActive(false);
        }
    }

}
