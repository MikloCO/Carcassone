using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardtype : MonoBehaviour
{
    [SerializeField] Tile tile;
    public void setCard(Tile t) {
        tile = t;
    }
    public Tile getCard()
    {
        return tile;
    }
}
