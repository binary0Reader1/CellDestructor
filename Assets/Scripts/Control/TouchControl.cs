using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchControl : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerExitHandler, IPointerEnterHandler
{
    [SerializeField]private GameObject player;
    [SerializeField]private GameObject bulletPrefab;
    [SerializeField]private GameObject scaleChangerPrefab;
    private GameObject currentBullet;
    private Transform playerTransform;
    private Transform currentBulletTransform;
    private Quaternion originQuaternion;
    private float radius = 15;
    private bool isPointerExit;
    private GameObject bulletScaleChanger;
    private GameObject playerScaleChanger;
    private void Start() {
        playerTransform = player.GetComponent<Transform>();
        originQuaternion = playerTransform.rotation;
    }
    public void OnBeginDrag(PointerEventData eventData){
        isPointerExit = false;
        currentBullet = Instantiate(bulletPrefab, GetNewBulletPosition(eventData), GetNewBulletRotation(eventData)); 
        currentBulletTransform = currentBullet.GetComponent<Transform>();

        bulletScaleChanger = Instantiate(scaleChangerPrefab,Vector3.zero,Quaternion.identity);
        bulletScaleChanger.GetComponent<ScaleChanger>().StartChangeScale(currentBullet.GetComponent<InteractionObject>(),0.03f,100.0f);

        playerScaleChanger = Instantiate(scaleChangerPrefab, Vector3.zero, Quaternion.identity);
        playerScaleChanger.GetComponent<ScaleChanger>().StartChangeScale(player.GetComponent<InteractionObject>(),-0.03f,100.0f);
    }
    public void OnDrag(PointerEventData eventData){
        if(isPointerExit){
            return;
        }
        currentBulletTransform.position = GetNewBulletPosition(eventData);
        currentBulletTransform.rotation = GetNewBulletRotation(eventData);
    }
    public void OnEndDrag(PointerEventData eventData){
        bulletScaleChanger.GetComponent<ScaleChanger>().StopChangeScale();
        playerScaleChanger.GetComponent<ScaleChanger>().StopChangeScale();
        currentBullet.GetComponent<Bullet>().Shoot();
        currentBullet = null;
    }
    public void OnPointerEnter(PointerEventData eventData){
        isPointerExit = false;
    }
    public void OnPointerExit(PointerEventData eventData){
        isPointerExit = true;
    }
    ///<Summary>
    ///Calculates bullet's position
    ///</Summary>
    private Vector3 GetNewBulletPosition(PointerEventData eventData){
        float pointerCalibrator = 15f; //Значение, балансирующее данные, полученные с мировой позиции
        float maxPointerValue = 50.0f;
        float minPointerValue = 15.0f;

        float angle = 1 - ((Mathf.Clamp(eventData.pointerCurrentRaycast.worldPosition.x, minPointerValue - pointerCalibrator, maxPointerValue -pointerCalibrator) - pointerCalibrator)/radius); //Преобразовываем 
        //evenData в мнимый угол поворота объекта
        float positionX = playerTransform.position.x + Mathf.Cos(angle) * radius; //Высчитываем координаты объекта
        float positionY = currentBullet == null ? 0 : currentBulletTransform.localScale.y / 2;
        float positionZ = playerTransform.position.z + Mathf.Sin(angle) * radius;

        Vector3 bulletPosition = new Vector3(positionX,positionY,positionZ);
        return bulletPosition;
    }
    ///<Summary>
    ///Calculates bullet's rotation
    ///</Summary>
    private Quaternion GetNewBulletRotation(PointerEventData eventData){
        Quaternion angleAxisY = Quaternion.AngleAxis(eventData.pointerCurrentRaycast.worldPosition.x * 2, Vector3.up);
        return originQuaternion * angleAxisY;
    }
    public void OnWin(){
        if(currentBullet != null){
            Destroy(currentBullet);
        }
        gameObject.SetActive(false);
    }
    public void OnLose(){
        if(currentBullet != null){
            Destroy(currentBullet);
        }
        gameObject.SetActive(false);
    }
}
