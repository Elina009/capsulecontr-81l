using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleController : MonoBehaviour
{
    Transform tr;
    CharacterController contr;
    float horizontalSpeed = 2.0f;
    public float speed = 12f;
    float gravityValue = -9.81f;
    bool isGrounded = false;
    float jumpHeight = 5f;
    Material m_Material;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        contr = GetComponent<CharacterController>();
        m_Material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float vertical = Input.GetAxis("Vertical");
        contr.Move(tr.forward * vertical * speed * Time.deltaTime);
        tr.Rotate(0,h,0);
        contr.Move(tr.up * gravityValue * Time.deltaTime);
        if(Input.GetKeyDown("space") && isGrounded == true){
            contr.Move(tr.up * jumpHeight);
        }
        
    }
    //void OnCollisionEnter(Collision col){
    //    if(col.gameObject.tag == "ground"){
    ///        isGrounded = true;
    //    }
    //}
    void OnControllerColliderHit(ControllerColliderHit col){
        if(col.gameObject.tag == "ground"){
            isGrounded = true;
        }
        if(col.gameObject.tag == "cube"){
            Destroy(col.gameObject);
        }
        if(col.gameObject.tag == "cube2"){
           m_Material.color = Color.red;
        }
    }
}
