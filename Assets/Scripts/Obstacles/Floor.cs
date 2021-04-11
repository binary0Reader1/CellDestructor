using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour, IObstacle
{
    public void OnHit(GameObject bullet){
        Debug.Log("It's floor");
    }
}
