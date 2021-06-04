using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
 // [SerializeField] Color exploredColor;
    public bool isExplored = false;
    public Waypoint exploredFrom;
    const int movementSize = 5;
    Vector2Int gridPos;
    public bool isPlaceable = true;
    const string towerParentName = "Towers";

    TowerFactory tower;

    public void Update()
    {
        // exploredColor = Color.blue;
    }

    public int GetMovementSize()
    {
        return movementSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int
       (Mathf.RoundToInt(transform.position.x / movementSize),
        Mathf.RoundToInt(transform.position.z / movementSize));
    }

    public void SetTopColor(Color colour)
    {
        MeshRenderer topColor = (transform.Find("Top").GetComponent<MeshRenderer>());//"transform.Find" is a method which finds the child GameObject of the parent GameObject to which the script is attached and returns the child game object.
        // colour = Color.blue;
        topColor.material.color = colour;
    }

    void OnMouseOver()
    {
        if (Input.GetKey(KeyCode.Mouse0) && isPlaceable == true)//Mouse0 is keycode for left click (LMB - Left Mouse Button)
        {
            FindObjectOfType<TowerFactory>().PlaceTower(this);
        }

        else if(Input.GetKey(KeyCode.Mouse0) && isPlaceable == false)
        {
            //Debug.Log("Can't Place Tower");
        }
    }
}