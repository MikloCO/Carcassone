using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCreator : MonoBehaviour
{
    [SerializeField]
    private GameObject grid;
    [SerializeField]
    private GameObject cell;
    [SerializeField]
    private int cellWidth = 10;
    [SerializeField]
    private int cellHeight = 10;
    [SerializeField]
    Texture outline_texture;
    public int[,] data;
    int id;

    void Start()
    {
        id = 0;
        data = new int[cellWidth, cellHeight];
        CreateGrid();
    }


    public int GetCellHeight()
    {
        return cellHeight;
    }
    public int[,] GetData()
    {
        return data;
    }
    

    private void CreateGrid()
    {
        for (int i = 0; i < cellWidth; i++)
        {
            for (int y = 0; y < cellHeight; y++)
            {
                GameObject reference = Instantiate(cell, new Vector3(0, 0, 0), cell.transform.rotation, grid.transform);
                reference.transform.localPosition = new Vector3(i * 10f, y * 10f, -0.015f);
                reference.name = i.ToString() + " " + y.ToString() + " ("+ id.ToString() + ")";
                data[i, y] = id;
                if (cell.GetComponent<Internal_id>() != null)
                {
                    reference.GetComponent<Internal_id>().StoreintiID(data[i, y]);
                }

                id++;
                reference.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }

    public Texture Get_OutlineTexture()
    {
        return outline_texture;
    }
}