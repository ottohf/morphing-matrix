using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VanityManager : MonoBehaviour
{
    public bool hasBowtie;
    public bool hasHat;

    public SpriteRenderer bowtie;
    public SpriteRenderer hat;
    public SpriteRenderer player;

    void Start()
    {
        if (Shop.actualItems != null)
        {
            for (int i = 0; i < Shop.actualItems.Count; i++)
            {
                if (Shop.actualItems[i].name == "Bowtie")
                {
                    hasBowtie = Shop.actualItems[i].equipped;
                }
                if (Shop.actualItems[i].name == "Wizard hat")
                {
                    hasHat = Shop.actualItems[i].equipped;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        bowtie.enabled = hasBowtie;
        hat.enabled = hasHat;

        bowtie.transform.position = player.transform.position;
        bowtie.transform.localScale = player.transform.localScale;
        hat.transform.position = player.transform.position;
        hat.transform.localScale = player.transform.localScale;
    }
}
