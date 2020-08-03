using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallButton : MonoBehaviour
{
    [SerializeField] SpriteRenderer wallButtonSpriteRenderer;
    public delegate void ActivateButton();
    public delegate void DeactivateButton();

    [SerializeField]
    private bool triggered;

    [SerializeField]
    private float activationPeriodLength;

    public ActivateButton ButtonActivated;
    public DeactivateButton ButtonDeactivated;

    void OnMouseDown()
    {
        print("mouse over button");
        if(!triggered)
        {
            print("Triggered button activate");
            StartCoroutine(ButtonActivation());
        }
    }

    private IEnumerator ButtonActivation()
    {
        

        if (ButtonActivated != null)
        {
            ButtonActivated();

            wallButtonSpriteRenderer.color = new Color(0, 255, 0, 255);

            triggered = true;

            yield return new WaitForSeconds(activationPeriodLength);
            StartCoroutine(ButtonDeactivation());
        }

    }

    private IEnumerator ButtonDeactivation()
    {
        if (ButtonDeactivated != null)
        {
            ButtonDeactivated();

            wallButtonSpriteRenderer.color = new Color(225, 0, 0, 255);

            triggered = false;

            yield break;
        }
    }
}
