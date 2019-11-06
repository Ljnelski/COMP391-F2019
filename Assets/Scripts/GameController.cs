using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //public var
    //all for controlling the spawn of hazards
    [Header("Wave Setting")]
    public GameObject hazard;   // what is spawning
    public Vector2 spawnValue;  // how many spawning
    public int hazardCount;     // How many hazards per wave
    public float startWait;     // How Long until first wave
    public float spawnWait;     // How Long until each spawn
    public float waveWait;      // How long between each wave

    //private var
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Create a coroutine function
    IEnumerator SpawnWaves()
    {
        // Delayed the first wave by a period of time
        yield return new WaitForSeconds(startWait); // Wait for startWait seconds

        while (true) // Now the game Starts
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector2 spawnPosition = new Vector2(spawnValue.x, Random.Range(-spawnValue.y,spawnValue.y));

                Instantiate(hazard, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
            hazardCount++;
            yield return new WaitForSeconds(waveWait);
        }
    }
}
