using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTilableBoard : MonoBehaviour
{
    [SerializeField] GameObject Tile1;
    [SerializeField] GameObject Tile2;
    [SerializeField] int width = 16;
    [SerializeField] int height = 9;
    [SerializeField] List<TileData> tileCoordList = new List<TileData>();

    public List<TileData> GetTileCoords ()
    {
        return tileCoordList;
    }

    void Start()
    {
        GameObject parentGameObject = new GameObject("Parent");
        parentGameObject.transform.localScale = new Vector3(0.8f, 0.8f, 1f);
        parentGameObject.transform.localPosition = new Vector3(1.19f, 0.35f, 0f);

        for (int tw = 0; tw < width; tw++)
        {
            for (int ty = 0; ty < height; ty++)
            {
                GameObject go;

                if (ty % 2 == 0)
                {
                    if (tw % 2 == 0)
                    {
                        go = Instantiate(Tile1, new Vector3(tw, ty, 0), Quaternion.identity);                     
                    }
                    else
                    {
                        go =  Instantiate(Tile2, new Vector3(tw, ty, 0), Quaternion.identity);
                    }
                }
                else
                {
                    if (tw % 2 == 0)
                    {
                        go = Instantiate(Tile2, new Vector3(tw, ty, 0), Quaternion.identity);
                    }
                    else
                    {
                        go = Instantiate(Tile1, new Vector3(tw, ty, 0), Quaternion.identity);
                    }
                }
                go.transform.SetParent(parentGameObject.transform);
                tileCoordList.Add(new TileData("", new Vector2(tw, ty), go));
                go.AddComponent<ID>();
                go.GetComponent<ID>().id = new Vector2(tw, ty);
                go.AddComponent<TrackClicks>();
            }
        }
    }
    //void OnMouseOver()
    //{
    //    this.GetComponent<SpriteRenderer>().color = Color.red;
    //    Debug.Log("Mouse is no longer on GameObject.");
    //}

    //void Update()
    //{
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    RaycastHit hit;
    //    if(Input.GetMouseButtonDown(0))
    //    {
    //        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
    //        {
    //            if(hit.transform.gameObject.name.Contains("Tile"))
    //            {
    //                Debug.Log("Hit tile!");
    //            }
    //        }
    //    }

    //}
}

[System.Serializable]
public class TileData
{
    public string name;
    public Vector2 position;
    public GameObject go;

    public TileData(string name, Vector2 position, GameObject go)
    {
        this.name = name;
        this.position = position;
        this.go = go;
    }

    void setTile(string name, Vector2 position, GameObject go)
    {
        this.name = name;
        this.position = position;
        this.go = go;
    }
}