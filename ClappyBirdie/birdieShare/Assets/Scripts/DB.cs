using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DB : MonoBehaviour
{[SerializeField]
    private Canvas canvas;
    [SerializeField]
    private Button create;
    [SerializeField]
    private Button login;
    [SerializeField]
    private Text message;
    [SerializeField]
    private Text loadText;
    [SerializeField]
    private Slider bar;
    [SerializeField]
    private InputField nick;
    [SerializeField]
    private InputField pass;
    AsyncOperation loadingOperation;
    private bool next;
    Firebase.Auth.FirebaseAuth auth;
    Firebase.Auth.FirebaseUser user;
    //FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
    // Start is called before the first frame update
    void Start()
    {
        next=false;
        nick.gameObject.SetActive(false);
        pass.gameObject.SetActive(false);
        loadText.gameObject.SetActive(false);
        bar.gameObject.SetActive(false);
        create.onClick.AddListener(RunCreate);
        login.onClick.AddListener(RunLog);
        message.text="";
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        
        
  
        
        

    }
    

    // Update is called once per frame
    void Update()
    {
        if(next){ 
            float progressValue = Mathf.Clamp01(loadingOperation.progress / 0.9f);
            bar.value=progressValue;
        
        }

    }
    
    public void RunCreate(){
        createRun();
    }   
       
    public void RunLog(){
        logRun();
    }  
    public async Task logRun()
    {

         if(!nick.gameObject.activeSelf)
        {
            nick.gameObject.SetActive(true);
            pass.gameObject.SetActive(true);
        }
        else
        {
            await signIn(nick.text,pass.text);
            if(user.Email==nick.text)
            {
                bar.gameObject.SetActive(true);
                loadText.gameObject.SetActive(true);
                nick.gameObject.SetActive(false);
                pass.gameObject.SetActive(false);
                login.gameObject.SetActive(false);
                create.gameObject.SetActive(false);
                next=true;
                loadingOperation = SceneManager.LoadSceneAsync(1);
            }
        }

    }
    public async Task createRun()
    {
        if(!nick.gameObject.activeSelf)
        {
            nick.gameObject.SetActive(true);
            pass.gameObject.SetActive(true);
        }
        else
        {
            await createUser(nick.text,pass.text);
            
        }
        
    }
    public async Task createUser(string nickname,string password)
    {
        await auth.CreateUserWithEmailAndPasswordAsync(nickname, password).ContinueWith(task => {
            if (task.IsCanceled) {
            Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
            message.text="CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception;
            return;
            }
            if (task.IsFaulted) {
            Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
            message.text="CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception;
            return;
            }

  // Firebase user has been created.
            user = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
            user.DisplayName, user.UserId);
            
            
            }
        );
    }
    public async Task signIn(string nickname,string password)
    {
        await auth.SignInWithEmailAndPasswordAsync(nickname, password).ContinueWith(task => {
        if (task.IsCanceled) {
            Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
        return;
        }
        if (task.IsFaulted) {
        Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
        return;
        }
        

        
        user = task.Result;
        Debug.LogFormat("User signed in successfully: {0} ({1})",
        user.Email, user.UserId);
        
        
        
        });
        

        
    }
}
