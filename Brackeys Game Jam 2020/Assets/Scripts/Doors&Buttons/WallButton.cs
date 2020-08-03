using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallButton : MonoBehaviour
{
    [SerializeField] SpriteRenderer wallButton;
    public delegate void ActivateButton();
    public delegate void DeactivateButton();

    public ActivateButton ButtonActivated;
    public DeactivateButton ButtonDeactivated;

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            wallButton.color = Color.green;
        }
    }
}
