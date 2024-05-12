using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySkills : MonoBehaviour
{
    public GameObject player;
    public GameObject gold;
    public AudioSource source;
    public AudioClip clipKnife, clipDead;
   

    Slider slider;

    public float enemySpeed;
    public float sliderHealt;
    public int xp;
    public float damage;
    void Start()
    {
        slider = GetComponentInChildren<Slider>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Knife")
        {

            source.clip = clipKnife;

            if (slider.value == 0)
            {
                source.clip = clipDead;
                Instantiate(gold, transform.position, Quaternion.identity);
                Destroy(gameObject);
                collision.gameObject.transform.parent.gameObject.transform.parent.GetComponent<CharacterSkills>().AddPuan(xp);
            }
            source.Play();
            slider.value -= sliderHealt;

        }
        else if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<CharacterSkills>().LowHealt(damage);
        }
    }
}
