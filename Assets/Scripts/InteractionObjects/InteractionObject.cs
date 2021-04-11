using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractionObject : MonoBehaviour
{
    public float power{get; protected set;} = 100;
    public float minPowerValue{get; protected set;} = 0;
    protected Vector3 presentScale; 
    protected Transform objectTransform;
    private void Awake() {
        objectTransform = GetComponent<Transform>();
        presentScale = transform.localScale;
    }
    public virtual void ChangeHealth(float value){
        power += value;
        float newSize = objectTransform.localScale.x + value;
        objectTransform.localScale = new Vector3(newSize,newSize,newSize);
    }
    public virtual void OnDestroy(){
        Destroy(gameObject);
    }
}
