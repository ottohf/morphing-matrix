using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VanityManager : MonoBehaviour
{
    // Start is called before the first frame update

    public bool hasBowtie;
    public bool hasHat;
    public SpriteRenderer bowtie;
    public SpriteRenderer hat;

    SpriteRenderer player;

    void Start()
    {
        player = GameObject.Find("PlayerSprite").GetComponent<SpriteRenderer>();
        bowtie.transform.position = new Vector2(-100, -100);

        if (Shop.persistantItems != null)
        {
            for (int i = 0; i < Shop.persistantItems.Count; i++)
            {
                if (Shop.persistantItems[i].name == "Bowtie")
                {
                    hasBowtie = Shop.persistantItems[i].equipped;
                }
                if (Shop.persistantItems[i].name == "Wizard hat")
                {
                    hasHat = Shop.persistantItems[i].equipped;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hasBowtie)
        {
            bowtie.transform.position = player.transform.position;
            bowtie.transform.localScale = player.transform.localScale;
        }
        if (hasHat)
        {
            hat.transform.position = player.transform.position;
            hat.transform.localScale = player.transform.localScale;
        }
    }
}
