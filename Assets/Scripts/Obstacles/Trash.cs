using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour, IObstacle
{
    public void OnHit(GameObject someObject){
        Bullet bullet = someObject.GetComponent<Bullet>();
        if(bullet != null){
            Debug.Log("It's bullet");
            GameObject explosion = Instantiate(Resources.Load<GameObject>("ExplosionObject"), transform.position,Quaternion.Euler(90,0,0));
            GameObject explosionScaleChanger = Instantiate(Resources.Load<GameObject>("ScaleChanger"), Vector3.zero, Quaternion.identity);
            explosionScaleChanger.GetComponent<ScaleChanger>().StartChangeScale(explosion.GetComponent<InteractionObject>(),bullet.power/100,bullet.power/2);
            Destroy(someObject);
        }
        Destroy(gameObject);
    }
}
