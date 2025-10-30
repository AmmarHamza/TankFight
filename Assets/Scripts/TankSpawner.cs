using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    // The array of enemy tank prefabs
    public GameObject[] tankPrefabs;

    // The number of tank types
    public int tankTypes = 5;

    // The size of each pool
    public int poolSize = 3;

    // The two-dimensional array of tanks
    private GameObject[,] tanks;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the two-dimensional array of tanks
        tanks = new GameObject[tankTypes, poolSize];

        // Create the pools of tanks and set them inactive
        for (int i = 0; i < tankTypes; i++)
        {
            for (int j = 0; j < poolSize; j++)
            {
                // Instantiate a tank from the corresponding prefab
                GameObject tank = Instantiate(tankPrefabs[i]);

                // Set the tank inactive
                tank.SetActive(false);

                // Add the tank to the array
                tanks[i, j] = tank;
            }
        }

        // Invoke the SpawnTank method repeatedly every 2 seconds
        InvokeRepeating("SpawnTank", 0, 1.5f);
    }

    // A method that spawns a random tank from the pools
    void SpawnTank()
    {
        // Choose a random tank type
        int type = Random.Range(0, tankTypes);

        // Get the tank from the array

        // If the tank is not active, activate it and set its position and rotation
        for(int i = 0; i < poolSize; i++)
        {
            GameObject tank = tanks[type, i];
            if (!tank.activeInHierarchy)
            {
                tank.SetActive(true);
                tank.transform.position = new Vector3(Random.Range(-4f, 4f), 8, 0);
                break;
            }
        }
    }
}
