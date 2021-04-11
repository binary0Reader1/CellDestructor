using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : InteractionObject
{   
    [SerializeField]GameObject targetGameObject;
    Transform targetTransform;
    private Vector3 target;
    Rigidbody bulletRigidbody;
    bool isShootNeeded;
    private void Start() {
        power = 1;
        targetTransform = targetGameObject.transform;
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.isKinematic = true;
        isShootNeeded = false;
    }
    private void FixedUpdate() {
        if(!isShootNeeded){
            return;
        }
        bulletRigidbody.AddForce(target);
    }
    private void OnCollisionEnter(Collision collision) {
        IObstacle obstacle = collision.gameObject.GetComponent<IObstacle>();
        if(obstacle!=null){
            obstacle.OnHit(gameObject);
        }
    }
    public void Shoot(){
        //objectTransform.rotation = Quaternion.Euler(0,0,0);
        target = targetTransform.position;
        Destroy(targetGameObject); //Удаляем объект-цель, так как нам он больше не нужен
        bulletRigidbody.isKinematic = false;
        isShootNeeded = true;
    }
}
