using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class enemieBehaviour: MonoBehaviour
{   public float life;
    public Rigidbody2D rb;
    public Vector2 linVel;
    public float duration = 1.2f;
    public void Update(){
        linVel = rb.linearVelocity;
    }
    public void GetDamage(float force,  float damage ,Vector2 direction){
        life-= damage;
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(direction * force,ForceMode2D.Impulse);
        StartCoroutine(StopKb());
      
    }
    IEnumerator StopKb(){
        float time = 0;
        Vector2 startRb = rb.linearVelocity;
        while(time < duration){
            time += Time.deltaTime;
            float t = time / duration;
           rb.linearVelocity = Vector2.Lerp(startRb,Vector2.zero,t);
            yield return null;
        }
        rb.linearVelocity = Vector2.zero;
       
    }
}
