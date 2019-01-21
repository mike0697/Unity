using UnityEngine;

public class Bottle : MonoBehaviour {

    public int bottleIndex;
    private Vector3 offset;

    private void OnMouseDown()
    {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
    }

    private void OnMouseDrag()
    {
        Vector2 currentScreenPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y); //posione del mause
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + offset;
        transform.position = currentPosition;
    }

}
