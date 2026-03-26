using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class AniDashAtack : MonoBehaviour
{
    public GameObject player;
    public Vector2 direction;
    public float forceKb;
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprsDashAtack;
    public int indice = 0;
    Coroutine dashAtackAnim;
    public float castTime;
    public GameObject target;

    public void Start(){
        InstAnimation();
          
    }
    public void GetDamage(float force, float damage , Vector2 direction){
        target.GetComponent<enemieBehaviour>().GetDamage(force,damage,direction);
    }
    public void InstAnimation(){
        if(dashAtackAnim != null){
            return;
        }
        dashAtackAnim = StartCoroutine(AnimationDaAtack());
    }
    public void Rotation(){
        float x = Random.Range(90,-90);
        float y = Random.Range(90,-90);
        float angle = Mathf.Atan2(y,x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,angle - 90f);
    }
    IEnumerator AnimationDaAtack(){
       Rotation();
       
        yield return new WaitForSeconds(0.05f);
        while(true){
             if (indice >= sprsDashAtack.Length )
            {
                Destroy(this.gameObject);   
                break;
            }else if (indice == 2)
            {
                 GetDamage(forceKb,1,direction);
            }
            spriteRenderer.sprite = sprsDashAtack[indice];
            yield return new WaitForSeconds(castTime);
            indice ++;
            
        }
       
    }
}
