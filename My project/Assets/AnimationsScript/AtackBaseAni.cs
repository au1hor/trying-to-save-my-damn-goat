using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class AtackBaseAni : MonoBehaviour
{
   Coroutine atackBase;
   public Sprite[] sprites;
   public float casTime;
   public SpriteRenderer srprR;

   public void Start(){
        InstAnimation();
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
        while (index < sprites.Length)
        {
            srprR.sprite = sprites[index];
            index ++;
             yield return new WaitForSeconds(casTime);
        }
       Destroy(this.gameObject);
   }
}
