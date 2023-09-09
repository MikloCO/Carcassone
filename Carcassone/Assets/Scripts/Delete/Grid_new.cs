using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static TMPro.TextMeshProUGUI;

public class Grid_new
{
    private int width;
    private int height;
    private int[,] gridArray;
    private float cellSize;

    private TextMeshProUGUI[,] debugTextArray;

    public Grid_new(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;

        gridArray = new int[width, height];
        debugTextArray = new TextMeshProUGUI[width, height];

        Debug.Log(width + " " + height);

        GameObject Parent = GameObject.Find("Canvas");

        //Loop through matrix array
        for(int x = 0; x < gridArray.GetLength(0); x++)
        {
            for(int y = 0; y < gridArray.GetLength(1); y++)
            {
                debugTextArray[x,y] = AddCell(cellSize, Parent, x, y);
            }

        }
        SetValue(3, 1, 56);
       // debugTextArray[3, 1].text = "56";

        TextMeshProUGUI AddCell(float cellSize, GameObject Parent, int x, int y)
        {
            int newx = Mathf.FloorToInt(x * cellSize);
            int newy = Mathf.FloorToInt(y * cellSize);
            GameObject gameObject = new GameObject(gridArray[x, y].ToString(), typeof(TextMeshProUGUI));
            gameObject.GetComponent<TextMeshProUGUI>().text = "0";
            Transform trans = gameObject.transform;
            trans.SetParent(Parent.transform, false);
            trans.localPosition = new Vector2(newx, newy);
            return gameObject.GetComponent<TextMeshProUGUI>();
        }
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize;
    }

    public void SetValue(int x, int y, int value)
    {
            if(x >= 0 && y >= 0 && x < width && y < height)
            {
                gridArray[x, y] = value;
                debugTextArray[x, y].text = gridArray[x, y].ToString();
            }
        
    }
}
