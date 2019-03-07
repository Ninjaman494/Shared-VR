using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDControl : MonoBehaviour
{

    public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
                Debug.Log("D");
                gameObject.transform.Translate(Vector3.right * Time.deltaTime * 3f);
        }
        if(Input.GetKey(KeyCode.A))
        {
                gameObject.transform.Translate(Vector3.left * Time.deltaTime * 3f);
        }
        if(Input.GetKey(KeyCode.S))
        {
                gameObject.transform.Translate(Vector3.back * Time.deltaTime * 3f);
        }
        if(Input.GetKey(KeyCode.W))
        {
                gameObject.transform.Translate(Vector3.forward * Time.deltaTime * 3f);
        }
    }
}
