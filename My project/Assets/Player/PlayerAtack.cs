using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAtack : MonoBehaviour
{
    public PlayerMove playerMove;
    public float duration = 0.3f;
    public GameObject enemie;
    public Vector3 enemieLocation;
    public Vector3 targetPosition;
    public float forceKb = 10;
    // animations atacks
    public GameObject atackDash;
     void DashAtack(GameObject Enemie){
       StartCoroutine(Dashit(enemie.transform));
    }
    IEnumerator Dashit(Transform pos){
        Vector3 startPosition = transform.position;
        float timer = 0;
        targetPosition = pos.position;
        playerMove.canMove = false;
        while (timer < duration)
        {
             if ((transform.position - targetPosition).magnitude < 1 )
            {
                AtackDashInst(enemie);
                break;
            }
            timer += Time.deltaTime;
            float t = timer / duration;
            transform.position = Vector3.Lerp(startPosition,targetPosition,t);
            yield return null;
        }
        playerMove.canMove = true;
    }
    public void AtackDashInst(GameObject target){
        GameObject atackDs = Instantiate(atackDash,targetPosition,quaternion.identity);
        Vector2 direction =targetPosition - transform.position;
        atackDs.GetComponent<AniDashAtack>().forceKb = forceKb;
        atackDs.GetComponent<AniDashAtack>().direction = direction.normalized;
        atackDs.GetComponent<AniDashAtack>().target = enemie;
        atackDs.GetComponent<AniDashAtack>().player = this.gameObject;

        
    }
    public void Update(){
        if(Input.GetMouseButtonDown(0)){
            DashAtack(enemie);
        }
    }
    
        
        
}
