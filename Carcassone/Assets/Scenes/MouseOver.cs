using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOver : MonoBehaviour
{
    public event Action<int> OnCellClick;
    public event Action<int> HandleOnExitCell;
    public event Action<int> HandleOnEnterCall;



    void OnMouseEnter()
    {
        if(gameObject.layer == LayerMask.NameToLayer("Ignore Raycast"))
        {
            return;
        }
        int i = this.GetComponent<Internal_id>().GetID();
        HandleOnEnterCall?.Invoke(i);

    }
    private void OnMouseExit()
    {
        int i = this.GetComponent<Internal_id>().GetID();
        HandleOnExitCell?.Invoke(i);
    }

    private void OnMouseUp()
    {
        if (gameObject.layer == LayerMask.NameToLayer("Ignore Raycast"))
        {
            return;
        }
        int i = this.GetComponent<Internal_id>().GetID();
        OnCellClick?.Invoke(i);
    }

}
