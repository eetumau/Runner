using UnityEngine;

public class FloorManager : MonoBehaviour
{

    public GameObject[] floors;
    public GameObject enemy;
    public Transform coin;


    public float _startZ;
    public float speed;
    public float speedIncreaseRate;
    public float speedIncreaseInterval;
    public float maxSpeed;
    public float endZ;
    public float coinInterval;

    private int _index;
    private int initialFloorCount;
    private float coinTimer;
    private Vector3[] _safePoints = new Vector3[5];
    private Vector3 _origin;
    private bool spawn;
    private float eventTime;
    private float startTime;


    // Use this for initialization
    void Start()
    {
        initialFloorCount = (int)((_startZ + -1 * endZ) / 5);
        SetupFloors();
        coinTimer = coinInterval;
        eventTime = Time.time;
        startTime = Time.time;
        
    }

    void Update()
    {
        if (GameGlobals.Instance.playerAlive)
        {
            UpdateSpeed();
            SpawnCoins();
            AddScore();
        }else
        {
            FreezeGame();
        }

    }



    private void SetupFloors()
    {
        for (int i = 0; i < initialFloorCount; i++)
        {

            float initialStartZ = _startZ - i * 5;
            var temp = Instantiate(floors[0], new Vector3(0, 0, initialStartZ), Quaternion.identity);
            temp.GetComponent<Floor>().speed = speed;
            temp.GetComponent<Floor>().endZ = endZ;
        }
    }

    public void SpawnFloor()
    {
        _index = UnityEngine.Random.Range(0, floors.Length);

        var temp = Instantiate(floors[_index], new Vector3(0, 0, _startZ), Quaternion.identity);
        temp.GetComponent<Floor>().speed = speed;
        temp.GetComponent<Floor>().endZ = endZ;

        if (UnityEngine.Random.Range(0, 100) > 70)
            SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        var temp = Instantiate(enemy, new Vector3(0, 0, _startZ), Quaternion.identity);
        temp.GetComponent<Enemy>().speed = speed;
        temp.GetComponent<Enemy>().endZ = endZ;
    }

    public void SpawnCoins()
    {
        for (int i = 0; i < 5; i++)
        {
            _origin = new Vector3(i - 2, 2, _startZ);

            if (Physics.Raycast(_origin, Vector3.down))
            {
                Debug.DrawRay(_origin, Vector3.down, Color.blue );

                if(Random.Range(0, 500) >= 499)
                {
                    spawn = true;
                }

            }else
            {
                Debug.DrawRay(_origin, Vector3.down, Color.red);
            }

            if (spawn)
            {
                var temp = Instantiate(coin, _origin, coin.rotation);
                temp.GetComponent<Collectable>().speed = speed;
                temp.GetComponent<Collectable>().endZ = endZ;
            }

            spawn = false;
        }




    }

    private void UpdateSpeed()
    {
        if (Time.time - eventTime > speedIncreaseInterval)
        {
            speed += speedIncreaseRate;
            eventTime = Time.time;
        }

    }

    private void AddScore()
    {
        float distanceTraveled = speed * (Time.time - startTime);
        GameGlobals.Instance.score = (int)distanceTraveled;
    }

    public void FreezeGame()
    {

        speed = 0;
    }

}
