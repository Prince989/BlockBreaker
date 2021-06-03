using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBricks : MonoBehaviour
{

    public GameObject EasyBrickPrefab;
    public GameObject HardBrickPrefab;
    public GameObject InvinciblePrefab;
    public Transform BrickParent;
    public Collider BrickSpawnZone;

    public int EasyBricksCount = 12;
    public int HardBricksCount = 7;
    public int InvincibleBricksCount = 5;

    [SerializeField]
    private GameObject[] EasyBricks;
    [SerializeField]
    private GameObject[] HardBricks;
    [SerializeField]
    private GameObject[] InvincibleBricks;

    void Start()
    {
        EasyBricks = new GameObject[EasyBricksCount];
        HardBricks = new GameObject[HardBricksCount];
        InvincibleBricks = new GameObject[InvincibleBricksCount];
        FindObjectOfType<BlockBreakerUIController>().maxBricksCount = EasyBricksCount + HardBricksCount;
        SpawnBrick();
        
    }
    public Vector3 RandomSpawnInZone()
    {
        Vector3 pos = GetRandomPoint(BrickSpawnZone);
        return pos;
    }
    void SpawnBrick()
    {
        for(int i = 0; i < EasyBricksCount; i++)
        {
            Vector3 p = GetRandomPoint(BrickSpawnZone);
            var t = Instantiate(EasyBrickPrefab, p, new Quaternion(0, 0, 0, 0), BrickParent);
            //t.AddComponent<CheckBrickCollision>();
            EasyBricks[i] = t.gameObject;
        }
        for(int i=0;i < HardBricksCount; i++)
        {
            Vector3 p = GetRandomPoint(BrickSpawnZone);
            var t = Instantiate(HardBrickPrefab, p, new Quaternion(0, 0, 0, 0), BrickParent);
            //t.AddComponent<CheckBrickCollision>();
            HardBricks[i] = t.gameObject;
        }
        for(int i = 0; i < InvincibleBricksCount; i++)
        {
            Vector3 p = GetRandomPoint(BrickSpawnZone);
            var t = Instantiate(InvinciblePrefab, p, new Quaternion(0, 0, 0, 0), BrickParent);
            //t.AddComponent<CheckBrickCollision>();
            InvincibleBricks[i] = t.gameObject;
        }
    }
    Vector3 GetRandomPoint(Collider collider)
    {
        Vector3 point;
        do
        {
            point = new Vector3(
                UnityEngine.Random.Range(collider.bounds.min.x, collider.bounds.max.x),
                UnityEngine.Random.Range(collider.bounds.min.y, collider.bounds.max.y),
                UnityEngine.Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        } while (point != collider.ClosestPoint(point));
        return point;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
