using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    [SerializeField] private GameObject directionObj;
    [SerializeField] private float moveRate;
    [SerializeField] private float rotateRate;

    private void Start()
    {
        rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("W");
            Vector3 direction = directionObj.transform.position - this.gameObject.transform.position;
            rigidbody.AddForce(direction * moveRate);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("S");
            Vector3 direction = this.gameObject.transform.position - directionObj.transform.position;
            rigidbody.AddForce(direction * moveRate);
        }

        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A");
            rigidbody.AddTorque(rotateRate, ForceMode2D.Force);
            //this.gameObject.transform.Rotate(0, 0, rotateRate);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("D");
            rigidbody.AddTorque(-rotateRate, ForceMode2D.Force);
            //this.gameObject.transform.Rotate(0, 0, -rotateRate);
        }
    }
}
