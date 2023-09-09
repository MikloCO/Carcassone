using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [SerializeField]
    public GameObject gridParent;
    PlaceTile placeTileComponent;
    [SerializeField]
    Dictionary<int, bool> childImageData = new Dictionary<int, bool>();
    [SerializeField]
    public GameObject PlacedTile;
    [SerializeField]
    public GameObject ScriptableObjectManager;

    List<GameplayActionss> history;

    // Start is called before the first frame update
    void Start()
    {
        placeTileComponent = this.GetComponent<PlaceTile>();
        placeTileComponent.OnPlacementStarted += HandlePlacementStarted;


    }

    private void Update()
    {
        if (childImageData.Count > 0)
        {
            if (Input.GetKeyUp(KeyCode.R))
            {
                GameObject child = gridParent.transform.GetChild(childImageData.Keys.First()).gameObject;
                child.transform.Rotate(Vector3.up, 90.0f);
            }
            if (Input.GetKeyUp(KeyCode.Q))
            {
                GameObject child = gridParent.transform.GetChild(childImageData.Keys.First()).gameObject;
                child.transform.Rotate(Vector3.up, -90.0f);
            }
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            AcceptPlacement();
        }
    }

    private void OnCellClick(int index)
    {
        Tile t = this.GetComponent<CardDeck>().Next();

        int cellWidth = this.GetComponent<GridCreator>().GetCellHeight(), cellHeight = cellWidth;

        if (t != null)
        {
            if (childImageData.Count <= 0)
            {
                GameObject childInQuestion = gridParent.transform.GetChild(index).gameObject;
                childInQuestion.GetComponent<Renderer>().material.mainTexture = t.artWork.texture;
                childImageData.Add(index, true);
            }
            else if (childImageData.Count > 0)
            {
                GameObject childInQuestion = gridParent.transform.GetChild(childImageData.Keys.First()).gameObject;
                Texture outline_texture = this.GetComponent<GridCreator>().Get_OutlineTexture();

                childInQuestion.GetComponent<Renderer>().material.mainTexture = outline_texture;
                childImageData.Clear();
                childInQuestion.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }

    private void HandlePlacementStarted()
    {
        AddMouseOverEvent();
    }

    private void AddMouseOverEvent()
    {
        if (this.GetComponent<PlaceTile>().IsplacementInProgress())
        {
            for (int i = 0; i < gridParent.transform.childCount; i++)
            {
                GameObject child = gridParent.transform.GetChild(i).gameObject;
                if (child.GetComponent<MouseOver>() == null)
                {
                    child.AddComponent<MouseOver>();
                    child.GetComponent<MouseOver>().OnCellClick += OnCellClick;
                    child.GetComponent<MouseOver>().HandleOnExitCell += HandleOnExitCell;
                }
            }
        }
    }

    private void HandleOnExitCell(int id)
    {
        GameObject child = gridParent.transform.GetChild(id).gameObject;

        if (child.GetComponent<Renderer>().material.mainTexture.name.Contains("outline"))
        {
            child.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    public void AcceptPlacement()
    {
       // history.Add(GameplayActionss.AcceptedPlacement);
        GameObject child = gridParent.transform.GetChild(childImageData.Keys.First()).gameObject;
        Tile t = this.GetComponent<CardDeck>().Next();
        child.GetComponent<Renderer>().material.mainTexture = t.artWork.texture;
        GameObject duplicateChild = Instantiate(
            child,
            child.transform.position,
            child.transform.rotation
        );
        duplicateChild.transform.localScale = child.transform.lossyScale;

        child.SetActive(false); // Turn off this tile. But we need it later for querying neighbour information
        duplicateChild.transform.parent = PlacedTile.transform;

        childImageData.Clear();
        this.GetComponent<CardDeck>().RemoveCurrent();


        // @TODO: Beroende på vilket kort vi lägger, så lyses giltigt område upp.
        int cellWidth = this.GetComponent<GridCreator>().GetCellHeight(), cellHeight = cellWidth;
        GameObject child2 = PlacedTile.transform.GetChild(0).gameObject;
        int[,] Data = this.GetComponent<GridCreator>().GetData();
        for (int i = 0; i < cellWidth; i++)
        {
            for (int y = 0; y < cellHeight; y++)
            {
                if (child2.GetComponent<Internal_id>().GetID() == Data[i, y])
                {
                    //Cell in hiearchy

                    int leftIndex = Data[i - 1, y];
                    int rightIndex = Data[i + 1, y];
                    int upIndex = Data[i, y + 1];
                    int downIndex = Data[i, y - 1];

                    int[] Datapoint = { leftIndex, rightIndex, upIndex, downIndex };

                    for (int u = 0; u < 4; u++)
                    {
                        GameObject tile = gridParent.transform.GetChild(Datapoint[u]).gameObject;
                        tile.GetComponent<MeshRenderer>().enabled = true;

                    }


                }
            }
        }
    }


}
public enum GameplayActionss
{
    PlacedTile,
    AcceptPlacement,
    AcceptedPlacement,
    RotatedCard,
    NextPlayer,
    GameRoundEnd,

}