using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Waypoint startPoint, endPoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();//Declared a dictionary

    Queue<Waypoint> queue = new Queue<Waypoint>();

    [SerializeField] bool isRunning = true;

    Vector2Int[] directions = { Vector2Int.up, Vector2Int.down, Vector2Int.right, Vector2Int.left };

    Waypoint searchCenter;

    List<Waypoint> pathFinder = new List<Waypoint>();

    public List<Waypoint> GetPath()
    {
        if (pathFinder.Count == 0)
        {
            CalculatePath();
        }
        return pathFinder;
    }

    private void CalculatePath()
    {
        LoadBlocks();
        //SetColourOfStartAndEnd();
        //FindNeighbour();
        BreadthFirstSearch();
        FindPath();
    }

    void FindPath()
    {
        SetAsPath(endPoint);
        Waypoint previous = endPoint.exploredFrom;
        while(previous != startPoint)
        {
            SetAsPath(previous);
            previous = previous.exploredFrom;
        }
        SetAsPath(startPoint);
        pathFinder.Reverse();
    }

    void SetAsPath(Waypoint waypoint)
    {
        pathFinder.Add(waypoint);
        waypoint.isPlaceable = false;
    }

    void BreadthFirstSearch()
    {
        queue.Enqueue(startPoint);
       
        while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
         // print("Started searching form: " + searchCenter);
            StopIfEdEqualsStart();
            FindNeighbour();
            searchCenter.isExplored = true;
        }
     // print(queue.Count);     
    }

    void StopIfEdEqualsStart()
    {
       if (searchCenter == endPoint)
       {
            //Debug.Log("Is PathFinding Finished???????");
            isRunning = false;
       }
    }

    public  void FindNeighbour()
    {
        if (isRunning == false) { return; }

        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourCoordinates = searchCenter.GetGridPos() + direction;
            // print("Exploring " + neighbourCoordinates);
            if (grid.ContainsKey(neighbourCoordinates))
            {
                QueueNewNeighbours(neighbourCoordinates);
            }
        }
    }

    private void QueueNewNeighbours(Vector2Int neighbourCoordinates)
    {
        Waypoint neighbour = grid[neighbourCoordinates];
        if (neighbour.isExplored || queue.Contains(neighbour))
        {
            //Do Nothing
        }
        else
        {
            //neighbour.SetTopColor(Color.blue);
            queue.Enqueue(neighbour);
            //print("Queueing" + neighbour);
            neighbour.exploredFrom = searchCenter;
        }
    } 

    public void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();//"waypoints" is an array.
        foreach (Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetGridPos();
            if (grid.ContainsKey(waypoint.GetGridPos()))
            {
                
            }
            else 
            { 
                grid.Add(gridPos, waypoint);
                waypoint.SetTopColor(Color.cyan);
            }
        }
        // print(grid.Count);
    }
    
    //void SetColourOfStartAndEnd()
    //{
    //    startPoint.SetTopColor(Color.green);
    //    endPoint.SetTopColor(Color.red);
    //}
}