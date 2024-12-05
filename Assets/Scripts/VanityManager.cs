using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void Start()
    {
        hasBowtie = true;
        bowtie = GameObject.Find("BowtieAnim");
        hat = GameObject.Find("HatAnim");
        player = GameObject.Find("PlayerSprite");
        bowtie.transform.position = new Vector2(-100, -100);
        spriteRendererBowtie = bowtie.GetComponent<SpriteRenderer>();
        //spriteRendererHat = hat.GetComponent<SpriteRenderer>();
        spriteRendererPlayer = player.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasBowtie)
        {
            bowtie.transform.position = player.transform.position;
            spriteRendererBowtie.transform.localScale = spriteRendererPlayer.transform.localScale;
        }
    }
}
