using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Knife")
        {
            PosSet(collision.gameObject.transform.parent.gameObject);
        }
        else
        {
            PosSet(collision.gameObject);
        }
    }
    void PosSet(GameObject objectx)
    {
        float x = 0, y = 0;
        if (objectx.tag != "Knife") { 
        if (objectx.gameObject.transform.position.x >= transform.position.x)
        {
            x = objectx.gameObject.transform.position.x + 0.15f;
        }
        else
        {
            x = objectx.gameObject.transform.position.x - 0.15f;
        }
        if (objectx.gameObject.transform.position.y >= transform.position.y)
        {
            y = objectx.gameObject.transform.position.y + 0.15f;
        }
        else
        {
            y = objectx.gameObject.transform.position.y - 0.15f;
        }
        objectx.gameObject.transform.position = new Vector2(x, y);
        }
    }
}
