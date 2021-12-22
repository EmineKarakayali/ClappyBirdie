using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> groundParts;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float outScreenValue;
    [SerializeField]
    private float size;
    [SerializeField]
    private float countOfElements;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        swapControl();
    }

    void swapControl()
    {
        foreach (var item in groundParts)
        {
            if(item.GetComponent<Transform>().localPosition.x<=outScreenValue)
            {
                item.GetComponent<Transform>().localPosition=new Vector3(item.GetComponent<Transform>().localPosition.x+(countOfElements*size),item.GetComponent<Transform>().localPosition.y,item.GetComponent<Transform>().localPosition.z);
            }
                 
            item.GetComponent<Transform>().localPosition=new Vector3(item.GetComponent<Transform>().localPosition.x-(speed*Time.deltaTime),item.GetComponent<Transform>().localPosition.y,item.GetComponent<Transform>().localPosition.z);
            
            
        }
    }
}
