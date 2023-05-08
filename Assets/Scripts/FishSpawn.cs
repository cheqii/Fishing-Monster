using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawn : MonoBehaviour
{
    [SerializeField] private float minVerticalSpawn;
    [SerializeField] private float maxVerticalSpawn;

    [SerializeField] private Fish.FishDirection _direction;
    
    [SerializeField] private GameObject[] fishPrefab;

    [SerializeField] private float[] fishSpawnPercent;

    private float[] fishSpawnPercentCal;

    [SerializeField] private Vector2 fishSpawnRate;
        
    // Start is called before the first frame update
    void Start()
    {
        fishSpawnPercentCal = fishSpawnPercent;
        
        for (int i = 0; i < fishSpawnPercent.Length; i++)
        {
            if (i == 0)
            {
                fishSpawnPercentCal[i] = fishSpawnPercent[i];
            }
            else
            {
                fishSpawnPercentCal[i] = fishSpawnPercent[i] + fishSpawnPercentCal[i - 1];
            }

        }

        StartCoroutine(SpawnFish());
    }
    
    IEnumerator SpawnFish()
    {
        while (true)
        {
            int randomNum = Random.Range(0, 100);
            
            for (int i = 0; i < fishSpawnPercentCal.Length; i++)
            {
                if (randomNum < fishSpawnPercentCal[i])
                {
                    var randomVerticalPos = Random.Range(minVerticalSpawn, maxVerticalSpawn);
                    Vector3 spawnPos = new Vector3(transform.position.x, randomVerticalPos, transform.position.z);
                    
                    
                    var fish = Instantiate(fishPrefab[i],spawnPos, Quaternion.identity);

                    if (_direction == Fish.FishDirection.left)
                    {
                        fish.GetComponent<Fish>()._Direction = Fish.FishDirection.left;
                    }
                    else
                    {
                        fish.GetComponent<Fish>()._Direction = Fish.FishDirection.right;
                        fish.transform.localScale = new Vector3(
                            -fish.transform.localScale.x,
                            fish.transform.localScale.y,
                            fish.transform.localScale.z);
                    }
                    
                    break;
                }
            }
            
            yield return new WaitForSeconds(Random.Range(fishSpawnRate.x, fishSpawnRate.y));
        }
    }
}
