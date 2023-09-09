using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IDragHandler
{
    [SerializeField] GameObject backside;
    [SerializeField] GameObject card;

    Vector2 diff = Vector2.zero;

    private RectTransform rectTransform;
    public Canvas canvas;

    void Start()
    {
        // rectTransform = GetComponent<RectTransform>();
        rectTransform = card.GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
   //     card.SetActive(true);
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            card.transform.Rotate(0f, 0, 90f);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            card.transform.Rotate(0f, 0, -90f);
        }
    }

    public void RotateQ()
    {
        card.transform.Rotate(0f, 0, 90f);
    }
    public void RotateE()
    {
        card.transform.Rotate(0f, 0, -90f);
    }

}
