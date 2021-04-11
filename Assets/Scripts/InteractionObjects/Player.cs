using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : InteractionObject
{
    Animator playerMoveAnim;
    private string playerMoveAnimConditon = "isPlayerMoveNeeded";
    private void Start() {
        playerMoveAnim = GetComponent<Animator>();
        minPowerValue = 88;
    }
    public override void OnDestroy()
    {
        Debug.Log("GameFinished");
        FindObjectOfType<GameController>().onLoseFunctions.Invoke();
        Destroy(gameObject);
    }
    public void OnWin(){
        playerMoveAnim.SetBool(playerMoveAnimConditon,true);
    }
}
