using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T : MonoBehaviour
{

    [SerializeField] private Color baseColor;
    [SerializeField] private Color offsetColor;
    [SerializeField] private SpriteRenderer renderer;
    [SerializeField] private GameObject highlight;

    public void Init(bool isOffset)
    {
        renderer = gameObject.GetComponent<SpriteRenderer>();
        if(isOffset)
        {
            renderer.color = Color.grey;
        }
        else
        {
            renderer.color = Color.white;
        }
    }

    void OnMouseEnter()
    {
        highlight.SetActive(true);
    }
    void OnMouseExit()
    {
        highlight.SetActive(false);
    }
}
