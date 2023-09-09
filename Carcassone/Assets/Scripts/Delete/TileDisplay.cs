using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDisplay : MonoBehaviour
{
    public Tile tile;
    SpriteRenderer spriteRender;

    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
    }
    public event Action flipCard;

    public void FlipCard()
    {
        tile.flipped = true;
    }

    void OnMouseDown()
    {
        tile.flipped = true;

    }

    // Update is called once per frame
    void Update()
    {
        if(tile.flipped)
        {
            spriteRender.sprite = tile.artWork;
            Vector2 originalSize = spriteRender.sprite.bounds.size;

            float desiredWidth = 5f;
            float scaleFactor = desiredWidth / originalSize.x;

            spriteRender.transform.localScale = new Vector3(scaleFactor, scaleFactor, 1f);
        }
    }
}
