using UnityEngine;

public class Clickable : MonoBehaviour
{
    public GameObject objectToDuplicate; // Reference to the prefab or GameObject to duplicate

    // private void OnMouseDown()
    // {
    //     if (Input.GetMouseButton(0))
    //     {
    //         DuplicateObject();
    //     }
    // }

    public void DuplicateObject()
    {
        if (objectToDuplicate != null)
        {
            // Get the position of the original object
            Vector3 originalPosition = transform.position;

            // Offset the Y position for the duplicated object
            Vector3 duplicatedPosition = new Vector3(originalPosition.x, -360f, originalPosition.z);

            // Create a new instance of the objectToDuplicate at the specified position
            GameObject newObject = Instantiate(objectToDuplicate, duplicatedPosition, transform.rotation);

            // Optionally, you can modify properties of the duplicated object here

            Debug.Log("Duplicated: " + objectToDuplicate.name);
        }
        else
        {
            Debug.LogWarning("No object to duplicate assigned!");
        }
    }
}
