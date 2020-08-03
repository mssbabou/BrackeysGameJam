using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallButton : MonoBehaviour
{
    [SerializeField] SpriteRenderer wallButtonSpriteRenderer;
    public delegate void ActivateButton();
    public delegate void DeactivateButton();

    [SerializeField]
    private bool inRange = false;

    [SerializeField]
    private bool triggered;

    [SerializeField]
    private float activationPeriodLength;

    public ActivateButton ButtonActivated;
    public DeactivateButton ButtonDeactivated;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.name == "Player")
        inRange = true;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.name == "Player")
            inRange = false;
    }

    void OnMouseOver()
    {
        if (inRange && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(ButtonActivation());
        }
    }


    private IEnumerator ButtonActivation()
    {
        if (ButtonActivated != null)
        {
            ButtonActivated();
        

            wallButtonSpriteRenderer.color = new Color(0, 1, 0, 1);
   

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

            wallButtonSpriteRenderer.color = new Color(1, 0, 0, 1);

            triggered = false;

            yield break;
        }
    }
}
