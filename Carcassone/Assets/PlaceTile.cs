using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class PlaceTile : MonoBehaviour
{
    [SerializeField]
    private GameObject GameManager;
    [SerializeField]
    private bool placementInProgress = false;

    public event Action OnPlacementStarted;

    // Start is called before the first frame update

    public bool IsplacementInProgress()
    {
        return placementInProgress;
    }
    public void SetPlacementInProgress(bool status)
    {
        placementInProgress = status;
    }

    public void PlaceTileOnBoard()
    {
        Debug.Log("Cursor Entering " + name + " GameObject");
        placementInProgress = true;
        OnPlacementStarted?.Invoke();
        
    }


}
