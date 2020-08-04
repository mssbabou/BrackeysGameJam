using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class boulderHolderScript : MonoBehaviour
{
    [SerializeField]
    private GameObject boulder;
    private GameObject currentBoulder;
    [SerializeField]
    float yOffset;
    private bool boulderInHolder = false;

    [SerializeField]
    private GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        if (button.name == "Button")
        {
            button.GetComponent<ButtonScript>().ButtonActivated += DropBoulder;            
        }
        else if (button.name == "Wall Button")
        {
            button.GetComponent<WallButton>().ButtonActivated += DropBoulder;
        }
        StartCoroutine(SpawnBoulder());
    }
    // Update is called once per frame
    private IEnumerator SpawnBoulder()
    {
        if (!boulderInHolder)
        {
            currentBoulder = Instantiate(boulder);
            currentBoulder.transform.parent = transform;
            currentBoulder.transform.localPosition = Vector2.down * yOffset;
            currentBoulder.GetComponent<Rigidbody2D>().gravityScale = 0f;
            currentBoulder.GetComponent<Rigidbody2D>().isKinematic = true;

            yield break;
            
        }
        
    }

    private void DropBoulder()
    {
        currentBoulder.GetComponent<Rigidbody2D>().gravityScale = 2f;
        currentBoulder.transform.parent = null;
        currentBoulder.GetComponent<Rigidbody2D>().isKinematic = false;
    }

}
