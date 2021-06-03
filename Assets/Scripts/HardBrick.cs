using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardBrick : MonoBehaviour
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

    void Start()
    {
        isBreakable = (this.tag == "Breakable");
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        AudioSource.PlayClipAtPoint(Laser, transform.position);
        if (isBreakable)
        {
            HandleHits();
        }
    }
    void HandleHits()
    {
        PuffSmoke();

        Transform t = transform.parent;

        transform.parent = null;

        t.gameObject.GetComponent<ParentBrick>().CheckForDestroy();

        Destroy(gameObject);
    }
    void PuffSmoke()
    {
        GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
        ParticleSystem.MainModule main = smokePuff.GetComponent<ParticleSystem>().main;
        main.startColor = gameObject.GetComponent<SpriteRenderer>().color;
    }
}
