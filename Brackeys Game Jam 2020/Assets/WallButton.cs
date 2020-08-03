using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallButton : MonoBehaviour
{
    [SerializeField] SpriteRenderer wallButton;

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            wallButton.color = Color.green;
        }
    }
}
