using UnityEngine;

public class Draggable : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;

    private void OnMouseDown()
    {
        if (Input.GetMouseButton(0))
        {
            isDragging = true;
            offset = transform.position - GetMouseWorldPos();
        }
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Debug.Log("dragging");
            transform.position = GetMouseWorldPos() + offset;
        }
    }

    private void OnMouseUp()
    {
            Debug.Log("m up");
        isDragging = false;
    }

    private Vector3 GetMouseWorldPos()
    {
            // Debug.Log("m up");
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        return mousePos/16;
        
    }
}
 


