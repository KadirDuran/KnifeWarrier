using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterMove : MonoBehaviour
{
    private Vector3 touchPosition;
    public GameObject player;
    private bool isDragging = false;

    private void OnMouseDown()
    {
        touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        touchPosition.z = 0f;
        isDragging = true;
    }
    private void OnMouseUp()
    {
        isDragging = false;
    }
    private void OnMouseDrag()
    {
        touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        touchPosition.z = 0f;
    }

    private void FixedUpdate()
    {
        if (isDragging)
        {
            Vector3 direction = (touchPosition - player.transform.position).normalized;
            player.transform.position += direction * 2f * Time.deltaTime;
        }
    }


}