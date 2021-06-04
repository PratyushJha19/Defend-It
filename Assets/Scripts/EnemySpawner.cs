using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 5f;
    [SerializeField] EnemyMovement enemyPrefab;
    public Transform parentEnemy;
    public Text scoreText;
    public AudioClip spawnSFX;
    int initialScore;

    void Start()
    {
        scoreText.text = initialScore.ToString();
        StartCoroutine(RepeatedlySpawnEnemies());
    }

    IEnumerator RepeatedlySpawnEnemies()
    {
        while (true) // Means forever
        {
            //print("Spawning");
            var newEnemies = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemies.transform.parent = parentEnemy;
            GetComponent<AudioSource>().PlayOneShot(spawnSFX);
            initialScore++; // '++' means adding 1 to the variable
            scoreText.text = initialScore.ToString();
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}