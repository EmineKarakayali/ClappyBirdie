using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
public class Movement : MonoBehaviour
{
    [SerializeField]
    private Text point;
    [SerializeField]
    private Rigidbody2D bird;
    [SerializeField]
    private PolygonCollider2D birdCol;
    [SerializeField]
    private Vector2 force;
    
    private int counter;
    private FirebaseDatabase db;
    Firebase.Auth.FirebaseAuth auth;
    // Start is called before the first frame update
    void Start()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        db=FirebaseDatabase.DefaultInstance;
        counter=0;
        point.text=counter.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        upwardForce();
        
    }

    void upwardForce()
    {
        if(Input.GetKeyUp(KeyCode.Mouse0))
        {bird.AddForce(force,ForceMode2D.Impulse);}
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        db.GetReference($"/users/{auth.CurrentUser.UserId}/Name").SetValueAsync(auth.CurrentUser.Email);
        db.GetReference($"/users/{auth.CurrentUser.UserId}/Point").SetValueAsync(point.text);
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       
        
    }
    void OnTriggerExit2D(Collider2D col)
    {
        counter++;
        point.text=counter.ToString();
        
    }

    

    
}
