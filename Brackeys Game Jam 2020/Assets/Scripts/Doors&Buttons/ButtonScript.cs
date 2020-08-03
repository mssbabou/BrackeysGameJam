using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    private bool moveDown = false;
    // Start is called before the first frame update
    private void Update()
    {
        CheckForMove();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            moveDown = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            moveDown = false;
        }
    }

    private void CheckForMove()
    {
        if (moveDown)
        {
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        }
        else
        {
            if (transform.localPosition.y < 0)
            {
                transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
            }
        }
    }
}
