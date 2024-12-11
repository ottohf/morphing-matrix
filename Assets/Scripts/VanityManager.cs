using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Shop;

public class VanityManager : MonoBehaviour
{
    // Start is called before the first frame update

    public bool hasBowtie;
    public bool hasHat;
    GameObject bowtie;
    GameObject hat;
    GameObject player;

    public SpriteRenderer spriteRendererBowtie;
    public SpriteRenderer spriteRendererHat;
    public SpriteRenderer spriteRendererPlayer;

    public GameObject preVanityManager;
    public List<ItemInfo> itemsFromShop;
    void Start()
    {
        preVanityManager = GameObject.Find("PreVanityManager");
        if (preVanityManager != null)
        {
            itemsFromShop = preVanityManager.GetComponent<PreVanityManager>().itemsFromShop;
        }
        bowtie = GameObject.Find("BowtieAnim");
        hat = GameObject.Find("HatAnim");
        player = GameObject.Find("PlayerSprite");
        bowtie.transform.position = new Vector2(-100, -100);
        spriteRendererBowtie = bowtie.GetComponent<SpriteRenderer>();
        spriteRendererHat = hat.GetComponent<SpriteRenderer>();
        spriteRendererPlayer = player.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < itemsFromShop.Count; i++)
        {
            if (itemsFromShop[i].name == "Bowtie")
            {
                hasBowtie = itemsFromShop[i].equipped;
            }
            if (itemsFromShop[i].name == "Wizard hat")
            {
                hasHat = itemsFromShop[i].equipped;
            }
        }
        if (hasBowtie)
        {
            bowtie.transform.position = player.transform.position;
            spriteRendererBowtie.transform.localScale = spriteRendererPlayer.transform.localScale;
        }
        if (hasHat)
        {
            hat.transform.position = player.transform.position;
            spriteRendererHat.transform.localScale = spriteRendererPlayer.transform.localScale;
        }
    }
}
