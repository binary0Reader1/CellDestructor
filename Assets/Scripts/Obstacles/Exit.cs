using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour, IObstacle
{
    //[SerializeField]GameObject exitAvailability;
    [SerializeField]Transform playerTransform;
    private Transform exitTransform;
    private Collider exitCollider;
    private Animator doorOpeningAnim;
    private string doorOpeningAnimConditionName = "isDoorOpenNeeded";

    private void Start() {
        doorOpeningAnim = GetComponent<Animator>();
        exitCollider = GetComponent<Collider>();
        exitTransform = GetComponent<Transform>();
    }
    public void OnHit(GameObject someObject){
        Destroy(someObject);
    }
    public void CheckExitAvailability(){
        Debug.Log("Win??");
        Collider[] allObjects;
        allObjects = Physics.OverlapCapsule(exitTransform.position,playerTransform.position,5);
        foreach(Collider col in allObjects){
            Debug.Log(col.name);
            if(col.name != gameObject.name){
                return;
            }
        }
        
        FindObjectOfType<GameController>().onWinFunctions.Invoke();
        Debug.Log("Win!!!!!");
    }
    public void OnWin(){
        doorOpeningAnim.SetBool(doorOpeningAnimConditionName,true); 
    }
}
