using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]//Makes all instances of a script execute in Edit Mode.
[SelectionBase]
[RequireComponent(typeof(Waypoint))]

public class Editor : MonoBehaviour
{
    TextMesh textMesh;//"TextMesh" is a variable type which is a component in Unity Editor
    Waypoint waypoint;
    Vector3 gridPos;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();    
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()//Mathf.RoundToInt returns the Round Off the of the number in integer form. 
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        int movementSize = waypoint.GetMovementSize();
        transform.position = new Vector3
            (waypoint.GetGridPos().x * movementSize, 0f, waypoint.GetGridPos().y * movementSize);
    }

    private void UpdateLabel()
    {
        int movementSize = waypoint.GetMovementSize();
        textMesh = GetComponentInChildren<TextMesh>();//"GetComponentInChildren" returns the component added to a Game Object childed in the Object to which the Script is attached.
        string objectName = waypoint.GetGridPos().x + "," + transform.position.z / movementSize;
        //The ".text" is a part of the "TextMesh" Component which shows the text provided, in the Runtime and in editor or we can say it is a place where we can enter the text which we want to show.
        textMesh.text = objectName;
        gameObject.name = objectName;//it returns the name of the Game Object as the value provided.
    }
}