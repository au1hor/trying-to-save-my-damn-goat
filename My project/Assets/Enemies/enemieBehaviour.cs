using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class enemieBehaviour: MonoBehaviour
{   public float life;
    public Rigidbody2D rb;
    public void GetDamage(float force,  float damage ,Vector2 direction){
        life-= damage;
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(direction * force,ForceMode2D.Impulse);
        StartCoroutine(stopKb());
      
    }
    IEnumerator stopKb(){
        yield return new WaitForSeconds(0.3f);
        rb.linearVelocity = Vector2.zero;
    }
}
