using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class KnifeCenter : MonoBehaviour
{
    public GameObject knifeCenter;
    List<GameObject> knifes = new List<GameObject>();
    public float turnSpeed = 1f;
    void Start()
    {
        AddKnifes(2);
     
    }
    public void AddKnifes(int countObject)
    {
        
        float point = 0f;
        for (int k = 0; k < countObject; k++)
        {
            GameObject gameObject = Instantiate(knifeCenter,transform.position,Quaternion.identity);
            gameObject.transform.SetParent(transform);
            knifes.Add(gameObject); 
        }
        point = 360 / knifes.Count;
       
        KnifeRotateSet(point);
    }
    void KnifeRotateSet(float point)
    {
        for (int i = 0; i < knifes.Count; i++)
        {
            knifes[i].transform.rotation = Quaternion.Euler(0f, 0f, i * point);
            

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="BonusKnife")
        {
            Destroy(collision.gameObject);
            AddKnifes(1);
        }
    }
    void Update()
    {
        transform.Rotate(0f, 0f, turnSpeed);
    }
}
