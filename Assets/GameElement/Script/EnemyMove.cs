using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class EnemyMove : MonoBehaviour
{
    GameObject player;
    SpriteRenderer sprite;
    float enemySpeedx;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        player = GetComponent<EnemySkills>().player;
        enemySpeedx = GetComponent<EnemySkills>().enemySpeed;
    }
    void FixedUpdate()
    {
        if(transform.position.x>player.transform.position.x)
        {
            sprite.flipX = false;
          
        }
        else
        {
            sprite.flipX = true;
         
        }
            
        transform.position = Vector3.MoveTowards(transform.position,player.transform.position,enemySpeedx*Time.deltaTime);
    }
}
