using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAtack : MonoBehaviour
{
    public PlayerMove playerMove;
    public float duration = 0.3f;
    public GameObject enemie;
    public Vector3 enemieLocation;
    public Vector3 targetPosition;
     void DashAtack(GameObject Enemie){
       StartCoroutine(Dashit());
    }
    IEnumerator Dashit(){
        enemieLocation = enemie.transform.position;
        Vector3 startPosition = transform.position;
        float timer = 0;
        Vector3 dist = startPosition -enemieLocation;
        targetPosition = enemieLocation - dist;
        playerMove.canMove = false;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            float t = timer / duration;
            transform.position = Vector3.Lerp(startPosition,targetPosition,t);
            Debug.Log("sadasd");
            if ((transform.position - targetPosition).magnitude < 3 )
            {
                break;
            }
            yield return null;
        }
        playerMove.canMove = true;
    }
    public void Update(){
        if(Input.GetMouseButtonDown(0)){
            DashAtack(enemie);
        }
    }
        
        
}
