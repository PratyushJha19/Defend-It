using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]//Makes all instances of a script execute in Edit Mode.
public class EditorSnap : MonoBehaviour
{
    [SerializeField] [Range(0f, 20f)] float movementSize = 10f;
    //The range keyword makes the value of the variable ranged between the points provided in it.
    //It will also make a bar of range in which we can move the point to change the value of variable.

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()//Mathf.RoundToInt returns the Round Off the of the number in integer form. 
    {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / movementSize) * movementSize;
        snapPos.y = 0;
        snapPos.z = Mathf.RoundToInt(transform.position.z / movementSize) * movementSize;
        transform.position = new Vector3(snapPos.x, 0f, snapPos.z);
    }
}
