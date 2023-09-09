using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOver : MonoBehaviour
{
    public event Action<int> OnCellClick;
    public event Action<int> HandleOnExitCell;


    void OnMouseEnter()
    {
        this.GetComponent<MeshRenderer>().enabled = true;
    }
    private void OnMouseExit()
    {
        int i = this.GetComponent<Internal_id>().GetID();
        HandleOnExitCell?.Invoke(i);
    }

    private void OnMouseDown()
    {
        int i = this.GetComponent<Internal_id>().GetID();
        OnCellClick?.Invoke(i);
    }

}
