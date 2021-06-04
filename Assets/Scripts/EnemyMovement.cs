using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //[SerializeField] List<Waypoint> path;
    //List is something same as array
    public float coroutineTime = 0.5f;
    public ParticleSystem deathParticles;

    public void Start()
    {
        PathFinder pathFinder = FindObjectOfType<PathFinder>();
        var path = pathFinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        // Debug.Log("Starting Patrol");
        foreach (Waypoint paths in path)
        {
            transform.position = paths.transform.position;
            //print("Visiting Block: " + paths.name);    //".name" will return the names of the Game Objects. 
            yield return new WaitForSeconds(coroutineTime);
        }
        //print("Patrol Ended");
        SelfDestruct();
    }

    public void SelfDestruct()
    {
        var particle = Instantiate(deathParticles, transform.position, Quaternion.identity);
        particle.Play();
        Destroy(particle.gameObject, 2.5f);
        Destroy(gameObject);
    }
}
