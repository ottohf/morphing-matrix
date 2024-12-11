using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Shop;

public class PreVanityManager : MonoBehaviour
{
    public GameObject Shop;
    public List<ItemInfo> itemsFromShop;

    // Start is called before the first frame update
    void Start()
    {
        Shop = GameObject.Find("Shop");
        if (GameObject.Find("Shop") != null)
        {
            itemsFromShop = Shop.GetComponent<Shop>().items;
        }
    }
    
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("PreVanityManager");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
