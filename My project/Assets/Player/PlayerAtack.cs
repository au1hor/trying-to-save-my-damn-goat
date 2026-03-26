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
    public float forceKb = 10;
    // animations atacks
    // prefabs
    public GameObject atackDash;
    public GameObject baseAtck;
    //

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
        GameObject atackDs = Instantiate(atackDash,targetPosition,Quaternion.identity);
        Vector2 direction =targetPosition - transform.position;
        atackDs.GetComponent<AniDashAtack>().forceKb = forceKb;
        atackDs.GetComponent<AniDashAtack>().direction = direction.normalized;
        atackDs.GetComponent<AniDashAtack>().target = enemie;
        atackDs.GetComponent<AniDashAtack>().player = this.gameObject;

        
    }
    public void atackBase(){
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = (transform.position- mousePos);
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        GameObject baseAtack = Instantiate(baseAtck,this.transform.position + new Vector3(0,1f,0),Quaternion.Euler(0,0,angle- 90f));
    }
    public void Update(){
        Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if(Input.GetMouseButtonDown(1)){
            DashAtack(enemie);
        }
         if(Input.GetMouseButtonDown(0)){
            atackBase();
        }
    }
    
        
        
}
