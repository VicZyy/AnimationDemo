using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VicAnimationEvents : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    //不需要Public也可以，只能有一个参数，可以是Int，Float,string,object
    private void RunStartEvent(string str)
    {
        Debug.Log(str);
    }

}
