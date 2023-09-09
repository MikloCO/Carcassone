using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawpile : MonoBehaviour
{
    [SerializeField] Tile StartTile;
    [SerializeField] List<Tile> cards = new List<Tile>();
    [SerializeField] List<string> cardnames = new List<string>();
    [SerializeField] int shuffleAmount = 5;
    [SerializeField] GameObject backside;
    [SerializeField] GameObject card;

    void Start()
    {
        AddCardsToPile();
        ShuffleDeck();
        CutDeck();
        AddStartTile();
    }

    public List<string> getCardNames()
    {
        return cardnames;
    }
    public List<Tile> getCards()
    {
        return cards;
    }

    public Sprite GetStartTile()
    {
        return StartTile.artWork;
    }

    public Sprite getCardsSpriteAtIndex(int i)
    {
        return cards[0].artWork;
    }

    public void setCards(List<string> cn)
    {
        cn = cardnames;
    }

    private void AddStartTile()
    {
        cardnames.Insert(0, StartTile.card_id);
    }

    private void ShuffleDeck()
    {
        for (int i = 0; i < shuffleAmount; i++)
        {
            ShufflePile();
        }
    }

    private void ShufflePile()
    {
        string placeholder;

        for (int i = 0; i < cardnames.Count; i++)
        {
            placeholder = cardnames[i];
            cardnames.RemoveAt(i);
            int new_index = UnityEngine.Random.Range(0, cardnames.Count-1);

            cardnames.Insert(new_index, placeholder);
        }
    }

    private void CutDeck()
    {
        int deckcount = cardnames.Count;
        List<string> temp_list = new List<string>();
        for (int i = 0; i < deckcount / 2; i++)
        {
            temp_list.Add(cardnames[i]);
            cardnames.RemoveAt(i);
        }

        for (int i = 0; i < deckcount / 2; i++)
        {
            cardnames.Add(temp_list[i]);
        }
    }

    private void AddCardsToPile()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            int loop = cards[i].number_in_game;

            for (int j = 0; j < loop; j++)
            {
                cardnames.Add(cards[i].card_id);
            }

        }
    }
}
