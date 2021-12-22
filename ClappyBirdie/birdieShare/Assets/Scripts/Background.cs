using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField]
    private GameObject quadGameObject;
    private Renderer quadRenderer;
    [SerializeField]
    private float scrollSpeed;

    void Start()
    {
        quadRenderer = quadGameObject.GetComponent<Renderer>();
        
    }

    void FixedUpdate()
    {
        Vector2 textureOffset = new Vector2(Time.deltaTime*scrollSpeed,0);
        quadRenderer.material.mainTextureOffset = textureOffset;
    }
}
