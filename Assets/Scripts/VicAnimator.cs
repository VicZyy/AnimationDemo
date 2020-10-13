using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VicAnimator : MonoBehaviour
{
    public Animator _animator;
    public Button  _injureBtn; 
    public Button  _normalBtn; 
    private AnimatorStateInfo _stateInfo;

    // Start is called before the first frame update
    void Start()
    {
        _injureBtn.onClick.AddListener(()=>_animator.SetLayerWeight(2,1));
        _normalBtn.onClick.AddListener(()=>_animator.SetLayerWeight(2,0));
    }

    // Update is called once per frame
    void Update()
    {
        //跑
        if (Input.GetKeyDown(KeyCode.W))
        {
            _animator.SetBool("run", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            _animator.SetBool("run", false);
        }
        //后退
        if (Input.GetKeyDown(KeyCode.S))
        {
            _animator.SetBool("back", true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            _animator.SetBool("back", false);
        }
        _stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        //跳
        if (_stateInfo.shortNameHash == Animator.StringToHash("RunForward") && Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger("jump");
        }
        //弹吉他
        if (_stateInfo.shortNameHash == Animator.StringToHash("Ideal") && Input.GetKeyDown(KeyCode.G))
        {
            _animator.SetTrigger("guitar");
        }
        //射击
        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetTrigger("shoot");
        }
    }
}
