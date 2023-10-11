using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTracker : MonoBehaviour
{
    List<int> SelectedTile;
    void Start()
    {
        GameObject gridParent = GameObject.Find("Grid");

        for (int i = 0; i < gridParent.transform.childCount; i++)
        {
            GameObject child = gridParent.transform.GetChild(i).gameObject;
            if (child.GetComponent<MouseOver>() == null)
            {
                child.AddComponent<MouseOver>();
                child.GetComponent<MouseOver>().OnCellClick += OnCellClick;
            }
        }
    }

    private void OnCellClick(int index)
    {
        SelectedTile.Add(index);
    }
}



