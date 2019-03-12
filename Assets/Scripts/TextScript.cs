using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScript : MonoBehaviour
{
    public Vector2 screenPosition = new Vector2(0, 0);

    void Update()
    {
        Vector3 tempScreenPosition = screenPosition;
        tempScreenPosition.z = -Camera.main.transform.position.z;

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(tempScreenPosition);
        worldPosition.x -= GetComponent<Renderer>().bounds.size.x * tempScreenPosition.x / Screen.width;
        worldPosition.y += GetComponent<Renderer>().bounds.size.y * (1 - tempScreenPosition.y / Screen.height);
        transform.position = worldPosition;
    }
}
