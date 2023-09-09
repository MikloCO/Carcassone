using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flip : MonoBehaviour
{
    [SerializeField] GameObject card;
    [SerializeField] GameObject DrawPile;
    [SerializeField] drawpile dp;
    [SerializeField] GameCardTracker gameCardTracker;
    [SerializeField] BoardManager bm;
    [SerializeField] Camera mainCamera;
    [SerializeField] Image imageGUI;


    private Vector3 offset;

    private void OnMouseDown()
    {
        card.SetActive(true);
        Debug.Log(this.transform.gameObject);
    }

    private void Start()
    {
        offset = transform.localPosition - GetMouseWorldPosition();

    }

    void Update()
    {
        if (Input.GetMouseButton(0)) {
            if(transform.gameObject.GetComponent<RectTransform>().position.y >= -122f) {
       //         transform.gameObject.GetComponent<RectTransform>().anchoredPosition
                // if(this.transform.position.y >= -122f) {
                Vector3 targetPosition = GetMouseWorldPosition();
                transform.position = targetPosition;
            }
        }

    }

    private bool IsMouseOverObjectCollider()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        int layerMask = 1 << LayerMask.NameToLayer("HUD");


        // Cast a ray from the mouse position and check if it hits the collider of the GameObject
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            return hit.collider.gameObject == gameObject;
        }

        return false;
    }

    private Vector3 GetMouseWorldPosition()
    {
        // Get the current mouse position in screen coordinates
        Vector3 mouseScreenPosition = Input.mousePosition;

        // Convert the mouse position to world coordinates using the main camera
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mouseScreenPosition);

        // Ensure the Z position is 0 to keep the sprite on the same plane as the game objects
        mouseWorldPosition.z = 0f;

        return mouseWorldPosition;
    }
}
