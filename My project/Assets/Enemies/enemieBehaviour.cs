using System.Collections;
using UnityEngine;

public class EnemieBehaviour: MonoBehaviour
{   public float life;
    public Rigidbody2D rb;
    public Vector2 linVel;
    public float duration = 1.2f;
    public SpriteRenderer sprRender;
    public GameObject player;
    public float dist;
    public float rangeChase;
    public float rangeAtack;
    public float speed = 2f;
    public bool canChangeState;

    public void Update(){
        linVel = rb.linearVelocity;
        dist = (player.transform.position - transform.position).magnitude;
        if (dist <= rangeChase)
        {
            if (dist <= rangeAtack)
            {
                ChangeStats(States.Atack);
                return;
            } 
            ChangeStats(States.Chase);
        }else if(canChangeState){
            ChangeStats(States.CHill);
        }
        if (state == States.Chase)
        {
            this.transform.position = Vector3.MoveTowards(transform.position,player.transform.position,speed);
        }
    }
    public States state;
    public enum States{
        CHill,
        Chase,
        Atack,
        Hitted
    }
    public void ChangeStats(States newState){
        if (canChangeState)
        {
            state = newState;
            UpdateAction();
        }
        
    }
    public void UpdateAction(){
        switch(state){
            case States.CHill:
            //Debug.Log("Chilling");
            sprRender.color = Color.blue;
            break;
            case States.Chase:
            //Debug.Log("Chasing");
             sprRender.color = Color.orange;
            break;
            case States.Atack:
            //Debug.Log("Atacking");
             sprRender.color = Color.red;
            break;
            case States.Hitted:
            //Debug.Log("Hitted");
             sprRender.color = Color.yellow;
            break;
        }
       
    }
    public void GetDamage(float force,  float damage ,Vector2 direction){
        ChangeStats(States.Hitted);
        canChangeState = false;
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
        canChangeState = true;
       
    }
}
