using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMove : MonoBehaviour
{
    GameObject player;
    public GameObject gold;
    Slider slider;
    SpriteRenderer sprite;
    TextMeshProUGUI txtHealt;
    public AudioClip clipKnife,clipDead;
    AudioSource source;
    int healt = 100;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sprite = GetComponent<SpriteRenderer>();
        source = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        slider = GetComponentInChildren<Slider>();
        txtHealt = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Knife")
        {

            source.clip=clipKnife;
            
            if (slider.value==0)
            {
                source.clip = clipDead;
                Instantiate(gold,transform.position,Quaternion.identity);
                Destroy(gameObject);
            }
            source.Play();
            slider.value -= 0.1f;
            txtHealt.text = healt.ToString();
            healt -= 10;
            
        }
        else if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<CharacterSkills>().LowHealt();
        }
    }
    void Update()
    {
        if(transform.position.x>player.transform.position.x)
        {
            sprite.flipX = false;
          
        }
        else
        {
            sprite.flipX = true;
         
        }
            
        transform.position = Vector3.MoveTowards(transform.position,player.transform.position,0.5f*Time.deltaTime);
    }
}
