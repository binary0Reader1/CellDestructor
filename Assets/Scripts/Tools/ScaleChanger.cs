using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleChanger : MonoBehaviour
{
    private InteractionObject interactionObject;
    private float valuePerFrame;
    private float absoluteValuePerFrame;
    private float summaryValue;
    private float maxValue;
    private bool isChangeNeeded = false;
    public void StartChangeScale(InteractionObject interactionObject, float valuePerFrame, float maxValue){
        this.interactionObject = interactionObject;
        this.valuePerFrame = valuePerFrame;
        this.maxValue = Mathf.Abs(maxValue);
        absoluteValuePerFrame = Mathf.Abs(valuePerFrame);
        isChangeNeeded = true;
    }   
    public void StopChangeScale(){
        Destroy(gameObject);
    }
    void FixedUpdate(){
        if(isChangeNeeded){
            Debug.Log(interactionObject.power);
            if(interactionObject.power <= interactionObject.minPowerValue){
                interactionObject.OnDestroy();
            }
            if(summaryValue > maxValue){
                Debug.Log("Here");
                interactionObject.OnDestroy();
                StopChangeScale();
            }
            interactionObject.ChangeHealth(valuePerFrame);
            summaryValue += absoluteValuePerFrame;
        }
    }
}
