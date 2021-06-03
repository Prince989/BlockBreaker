using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

    public AudioClip Laser;
    public Sprite[] hitSprites;
    public static int breakableCount = 0;
    public static int bricksDestroyed = 0;

    public GameObject smoke;

    //private int maxHits;
    private int timesHit;
    private LevelManager levelManager;
    private bool isBreakable;

    // Use this for initialization
    void Start()
    {
        breakableCount = 0;
        bricksDestroyed = 0;
        isBreakable = (this.tag == "Breakable");
        // Tracking of breakable Bricks
        if (isBreakable)
        {
            breakableCount++;
        }

        breakableCount = GameObject.FindGameObjectsWithTag("Breakable").Length;
        Debug.Log(breakableCount);

        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        AudioSource.PlayClipAtPoint(Laser, transform.position);
        if (isBreakable)
        {
            HandleHits();
        }
    }

    void HandleHits ()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            breakableCount--;
            bricksDestroyed++;
            Debug.Log(breakableCount + ",," + bricksDestroyed);

            levelManager.BrickDestroyed();
            PuffSmoke();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
        if(breakableCount <= 0)
        {
            GameObject UIController = FindObjectOfType<BlockBreakerUIController>().gameObject;
            UIController.GetComponent<BlockBreakerUIController>().GameComplete(Brick.bricksDestroyed);
        }
    }

    void PuffSmoke()
    {
        GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
        ParticleSystem.MainModule main = smokePuff.GetComponent<ParticleSystem>().main;
        main.startColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] !=null)
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError ("Brick Sprite Missing");
        }
    }
}