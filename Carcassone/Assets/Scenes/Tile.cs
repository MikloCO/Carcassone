using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New tile", menuName = "Tile")]
public class Tile : ScriptableObject
{
    public new string name;
    public string description;

    public Sprite artWork;
    public int city_edges;
    public int road_edges;
    public int number_in_game;
    public bool flipped = false;
    public string card_id;

    public GameObject TilePrefab;

    //  public string[] edgeRepresentation = new string[4]; //Draw from left to right 0-3.
    public enum DataType { Road, City, Farm };
    [SerializeField] DataType[] datatype;
    public DataType[] GetDataType()
    {
        return datatype;
    }





}
