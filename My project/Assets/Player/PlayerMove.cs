using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    public Vector2 inputMove;
    public float MoveSpeed;
    public bool canMove;
    public void Move(){
        if (canMove)
        {
            inputMove = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical")).normalized;
            transform.position += (Vector3)inputMove * MoveSpeed * Time.deltaTime;
        }
       
    }
    public void ResetPosition(){
        transform.position = Vector3.zero;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))ResetPosition();
        Move();
    }
}
