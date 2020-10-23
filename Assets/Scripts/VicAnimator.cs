using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VicAnimator : MonoBehaviour
{
    public Animator _animator;
    public Button _injureBtn;
    public Button _normalBtn;
    public Toggle _ikToogle;

    public Transform _lootAtTarget;
    public Transform _rightHandIkTarget;
    public Transform _leftHandIKTarget;
    public Transform _rightFootIKTarget;
    public Transform _leftFootIKTarget;

    private AnimatorStateInfo _stateInfo;

    // Start is called before the first frame update
    void Start()
    {
        _injureBtn.onClick.AddListener(() => _animator.SetLayerWeight(2, 1));
        _normalBtn.onClick.AddListener(() => _animator.SetLayerWeight(2, 0));
    }

    // Update is called once per frame
    void Update()
    {
        //跑
        if (Input.GetKeyDown(KeyCode.W))
        {
            _animator.SetBool("run", true);
        }
        //输出动画曲线
        if (_stateInfo.shortNameHash == Animator.StringToHash("RunForward"))
        {
            Debug.Log(_animator.GetFloat("RunSpeed"));
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


    private void OnAnimatorIK(int layerIndex)
    {
        if (_ikToogle.isOn)
        {
            //LookAtIK
            _animator.SetLookAtWeight(1);
            if (_lootAtTarget)
            {
                _animator.SetLookAtPosition(_lootAtTarget.position);
            }
            //手IK
            _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
            _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
            if (_leftHandIKTarget)
            {
                _animator.SetIKPosition(AvatarIKGoal.LeftHand, _leftHandIKTarget.position);
                _animator.SetIKRotation(AvatarIKGoal.LeftHand, _leftHandIKTarget.rotation);
            }
            _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
            _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
            if (_leftHandIKTarget)
            {
                _animator.SetIKPosition(AvatarIKGoal.RightHand, _rightHandIkTarget.position);
                _animator.SetIKRotation(AvatarIKGoal.RightHand, _rightHandIkTarget.rotation);
            }
            //脚IK
            _animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1);
            _animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 1);
            if (_leftFootIKTarget)
            {
                _animator.SetIKPosition(AvatarIKGoal.LeftFoot, _leftFootIKTarget.position);
                _animator.SetIKRotation(AvatarIKGoal.LeftFoot, _leftFootIKTarget.rotation);
            }
            _animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1);
            _animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 1);
            if (_rightFootIKTarget)
            {
                _animator.SetIKPosition(AvatarIKGoal.RightFoot, _rightFootIKTarget.position);
                _animator.SetIKRotation(AvatarIKGoal.RightFoot, _rightFootIKTarget.rotation);
            }
        }
    }
}
