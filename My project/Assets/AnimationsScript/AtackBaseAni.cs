using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class AtackBaseAni : MonoBehaviour
{
   Coroutine atackBase;
   public Sprite[] sprites;
   public float casTime;
   public SpriteRenderer srprR;
   public GameObject player;
   public bool flip = false;

   public void Start(){
        InstAnimation();
        player = GameObject.FindGameObjectWithTag("Player");
   }
   public void Update(){
    
   }
   public void InstAnimation(){
        if (atackBase != null)
        {
            StopCoroutine(atackBase);
        }
        atackBase = StartCoroutine(AtackBanimation());
 
   }
   IEnumerator AtackBanimation(){
     int index = 0;
        Debug.Log(flip);
     this.GetComponent<SpriteRenderer>().flipX = flip;
     while (index < sprites.Length)
     {
          srprR.sprite = sprites[index];
          index ++;   
          yield return new WaitForSeconds(casTime);
     }
       Destroy(this.gameObject);
   }
   public void CheckHitbox(){

   }
   public void OnTriggerEnter2D(Collider2D other){
     if(other.CompareTag("enemie")){ 
          flip = !flip;
          Debug.Log(flip);
          Vector2 dir = other.gameObject.transform.position - transform.position;
          other.gameObject.GetComponent<EnemieBehaviour>().GetDamage(3,1,dir);
     }
   }
   
}
