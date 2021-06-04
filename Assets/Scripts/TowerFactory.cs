using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    public int towerLimit = 5;
    public TowerScript towerPrefab;
    Queue<TowerScript> towerQueue = new Queue<TowerScript>();
    public Transform towerParent;

    public void PlaceTower(Waypoint baseWaypoint)
    {
        int numTowers = towerQueue.Count;

        if (numTowers < towerLimit)
        {
            InstantiateTowers(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }
    }
    void InstantiateTowers(Waypoint baseWaypoint)
    {
        var newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        //Debug.Log("Placing Tower");
        baseWaypoint.isPlaceable = false;
        newTower.transform.parent = towerParent;

        newTower.baseWaypoint = baseWaypoint;
        baseWaypoint.isPlaceable = false;

        towerQueue.Enqueue(newTower);
    }

    void MoveExistingTower(Waypoint newbaseWaypoint)
    {
        print("Moving Tower");
        var oldTower = towerQueue.Dequeue();

        oldTower.baseWaypoint.isPlaceable = true;
        newbaseWaypoint.isPlaceable = false;

        oldTower.baseWaypoint = newbaseWaypoint;
        oldTower.transform.position = newbaseWaypoint.transform.position;

        towerQueue.Enqueue(oldTower);
    }
}
