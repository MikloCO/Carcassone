using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameCardTracker : MonoBehaviour
{

    List<Tile> til_groups;
    List<string> til_cards_ind;
    [SerializeField] GameObject dp_obj;
    [SerializeField] GameObject real_card;
    [SerializeField] GameObject create_tilable_board;
    [SerializeField] Sprite placeholder;


    public void Something()
    {
        til_groups = dp_obj.GetComponent<drawpile>().getCards();
        til_cards_ind = dp_obj.GetComponent<drawpile>().getCardNames();
        Sprite sprite = dp_obj.GetComponent<drawpile>().GetStartTile();
        real_card.GetComponent<Image>().sprite = sprite;

        List<TileData> tc = create_tilable_board.GetComponent<CreateTilableBoard>().GetTileCoords();

        tc[0].go.GetComponent<SpriteRenderer>().sprite = sprite;
        tc[0].go.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(0.1f, 0.1f, 1f);
        //tileCoordList.Remove(tileCoordList[1]);
    }

    internal void ChangeTileToNormal(GameObject go)
    {
        //Sprite sprite = dp_obj.GetComponent<drawpile>().GetStartTile();
       // real_card.GetComponent<Image>().sprite = placeholder;


   //     go.GetComponent<SpriteRenderer>().sprite = placeholder;
    //    go.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(1f, 1f, 1f);
    }

    public void ChangeTile(GameObject go)
    {
        Sprite sprite = dp_obj.GetComponent<drawpile>().GetStartTile();
        real_card.GetComponent<Image>().sprite = sprite;


        go.GetComponent<SpriteRenderer>().sprite = sprite;
        go.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(0.1f, 0.1f, 1f);

    }

    public void AddTile(GameObject go)
    {

        go.GetComponent<SpriteRenderer>().sprite = null;
        
        GameObject tile = go.transform.GetChild(0).gameObject;
        tile.SetActive(true);
        tile.GetComponent<SpriteRenderer>().sprite = dp_obj.GetComponent<drawpile>().GetStartTile();
        tile.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(0.1f, 0.1f, 1f);
    }

    public void RemoveTile(GameObject go)
    {
        GameObject tile = go.transform.GetChild(0).gameObject;
        tile.SetActive(false);
        go.GetComponent<SpriteRenderer>().sprite = placeholder;
    }
}

