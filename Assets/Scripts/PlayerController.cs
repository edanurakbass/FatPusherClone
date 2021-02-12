using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject floatingPrefabs;
    public GameObject floatingTextPrefabs;
    public GameObject finishPanel;
    public GameObject replayPanel;
    public GameObject playPanel;

    private float mousex = 0;
    public float speed = 2f;
    private float min = -3.62f;
    private float max = 3.05f;
    private int coinCount;

    public Vector3 newpos;
    public float playerSpeed = -2.0f;
    public int health = 40;
    public float demage = 2.0f;
    public Slider slider;
    public Animator anim;
    public bool isRunning;
    public static PlayerController Instance;

    public bool move = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        playPanel.SetActive(true);
        anim = GetComponent<Animator>();
        coinCount = 0;
        slider.maxValue = 50;
        slider.value = health;
    }
    public void PlayGame()
    {
        playPanel.SetActive(false);
        move = true;
    }

    private void Update()
    {
        if (move)
        {
            MovePlayer();
        }

    }
    private void MovePlayer()
    {
        transform.Translate(0, 0, 1f * playerSpeed * Time.deltaTime);
        anim.SetBool("run", true);
        if (Input.GetMouseButton(0))
        {
            newpos = this.transform.position;
            mousex = Input.mousePosition.x;
            newpos.x = (mousex * (((max - min) / 2) / (Screen.width / 2)) + min);
            newpos.x = Mathf.Clamp(newpos.x, min, max);
            this.transform.position = Vector3.Lerp(this.transform.position, newpos, Time.deltaTime * speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "food" )
        {
            FloattingTextPrefabs();
            slider.value += 2;
            Destroy(other.gameObject);
            transform.localScale += new Vector3(0.5f, 0.05f, 0.5f);
        }
        else if (other.gameObject.tag == "coin")
        {
            coinCount++;
            FloattingPointsPrefabs();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "finish")
        {
            finishPanel.SetActive(true);
            move = false;
        }
    }

    void FloattingPointsPrefabs()
    {
        var offset = new Vector3(1.0f, 1.5f, 5.0f);
        Instantiate(floatingPrefabs, transform.position + offset, Quaternion.identity, transform);

    }
    void FloattingTextPrefabs()
    {
        var offset = new Vector3(1.0f, 1.5f, 5.0f);
        Instantiate(floatingTextPrefabs, transform.position + offset, Quaternion.identity, transform);

    }

    public void ReplayGame()
    {
        Debug.Log("Replay calisti");
        SceneManager.LoadScene("GameScene");
    }

}
    

