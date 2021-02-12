using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleManager : MonoBehaviour
{
    private int live;
    [SerializeField]
    private GameObject player;
    public Text liveText;

    void Start()
    {
        live = Random.Range(2, 13);
        liveText.text = live.ToString(); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player")
        {
            PlayerController.Instance.anim.SetBool("push", true);
            PlayerController.Instance.slider.value -= PlayerController.Instance.demage;
            PlayerController.Instance.health -= 2;
            if (PlayerController.Instance.health <= 3)
            {
                PlayerController.Instance.anim.SetBool("die", true);
                PlayerController.Instance.replayPanel.SetActive(true);
                Debug.Log("Olme Animasyonu");
                PlayerController.Instance.move = false;
            }
            if (live > 0)
            {
                Invoke("Countdown",0.1f);
                liveText.text = live.ToString(); 
                player.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
                Debug.Log("kalan hak" + live);   
            }
            else if (live <= 0)
            {
                Destroy(gameObject);
                PlayerController.Instance.anim.SetBool("push", false);
            }
        }
    }
    void Countdown()
    {
        live--;

    }
}
