using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeck : MonoBehaviour
{
    [SerializeField]
    GameObject ScriptableObjectManager = null;

    List<string> CardsStr = new List<string>();
    [SerializeField]
    List<Tile> Cards = new List<Tile>();

    void Start()
    {
        int amount_of_tiles = ScriptableObjectManager.GetComponent<ScriptableObjectManager>().GetSOCount();

        for (int i = 0; i < amount_of_tiles; i++)
        {
            Tile t = (Tile)ScriptableObjectManager.GetComponent<ScriptableObjectManager>().GetSO(i);
            int instances_of_cards_in_game = t.number_in_game;
            for (int x = 0; x < instances_of_cards_in_game; x++)
            {
                if(!t.card_id.Equals("Start_tile"))
                {
                    CardsStr.Add(t.card_id);
                    Cards.Add(t);
                }
            }
        }
        FisherYatesShuffleCardAlgorithm();
    }

    public void FisherYatesShuffleCardAlgorithm()
    {
        for (int i = CardsStr.Count - 1; i >= 0; i--)
        {
            int number = Random.Range(0, i);
            Tile temp = Cards[i];
            Cards[i] = Cards[number];
            Cards[number] = temp;
        }

        Cards.Insert(0, ScriptableObjectManager.GetComponent<ScriptableObjectManager>().GetSOByCardID("Start_tile"));
        Debug.Log(Cards);
    }

    public List<Tile> GetCards()
    {
        return Cards;
    }

    public Tile Next()
    {
        if(Cards.Count > 1)
        {
            Tile card = Cards[0];
            return card;
        }
        return null;
    }

    public void RemoveCurrent()
    {
        if (Cards.Count > 1)
        {
            Cards.RemoveAt(0);
        }
    }


}
//        Tile t = (Tile)so_manager.GetComponent<ScriptableObjectManager>().GetSO(4);
