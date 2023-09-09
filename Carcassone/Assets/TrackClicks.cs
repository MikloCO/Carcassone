using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackClicks : MonoBehaviour
{
   [SerializeField] GameCardTracker gameCardTracker;
   [SerializeField] BoardManager bm;

    [SerializeField] GameObject Rememberme;
    bool hasTileAdded = false;


    private void Awake()
    {
        gameCardTracker = GameObject.Find("GameboardManager").GetComponent<GameCardTracker>();
        bm = GameObject.Find("GameboardManager").GetComponent<BoardManager>();
    }

    void OnMouseOver()
    {
        if(bm.CanPlaceTile())
        {
            if (!hasTileAdded)
            {
                gameCardTracker.AddTile(this.transform.gameObject);
                Rememberme = this.transform.gameObject;
                hasTileAdded = true;

            }
        }
    }
    void OnMouseExit()
    {
        if(Rememberme != null)
        {
            gameCardTracker.RemoveTile(Rememberme);
            hasTileAdded = false;
            Rememberme = null;
        }
    }

    void OnMouseDown()
    {
        if (bm.CanPlaceTile())
        {
            Debug.Log(this.transform.gameObject);
            gameCardTracker.ChangeTile(this.transform.gameObject);
        }
    }
}
