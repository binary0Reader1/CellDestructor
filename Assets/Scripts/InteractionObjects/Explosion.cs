using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : InteractionObject
{
    Rigidbody bulletRigidbody;
    private void Start() {
        bulletRigidbody = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider collision) {
        Debug.Log("SOMETHING");
        IObstacle obstacle = collision.gameObject.GetComponent<IObstacle>();
        Debug.Log(obstacle);
        if(obstacle!=null){
            obstacle.OnHit(gameObject);
        }
    }
    public override void OnDestroy()
    {
        FindObjectOfType<Exit>().CheckExitAvailability();
        Destroy(gameObject);
    }
}