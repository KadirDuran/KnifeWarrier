using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldAnimation : MonoBehaviour
{
    void Start()
    {
        Invoke("TagChange", 0.9f);
    }
    void TagChange()
    {
        gameObject.tag = "Gold";
    }
}
