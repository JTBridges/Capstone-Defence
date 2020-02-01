using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //awake is called once when the game object is made
    private void Awake()
    {
#if UNITY_STANDALONE || UNITY_WEBGL//we don't want joysticks on non-mobile platforms
        Destroy(transform.GetChild(0));
        Destroy(transform.GetChild(1));
#endif
    }
}
