using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour, IObstacle
{
    public void OnHit(GameObject someObject){
        Destroy(someObject);
    }
}
