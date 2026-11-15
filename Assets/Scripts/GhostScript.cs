using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GhostScript : MonoBehaviour
{
    private Animator _anim;
    private CharacterController _characterController;

    private Vector3 _moveDirection = Vector3.zero;
    private Vector3 _startPosition;
    private Quaternion _startRotation;

    private static readonly int IdleState = Animator.StringToHash("Base Layer.idle");
    private static readonly int MoveState = Animator.StringToHash("Base Layer.move");
    private static readonly int SurprisedState = Animator.StringToHash("Base Layer.surprised");
    private static readonly int AttackState = Animator.StringToHash("Base Layer.attack_shift");
    private static readonly int DissolveState = Animator.StringToHash("Base Layer.dissolve");

    private static readonly int AttackTag = Animator.StringToHash("Attack");

    [FormerlySerializedAs("MeshR")] [SerializeField]
    private SkinnedMeshRenderer[] meshR;

    private float _dissolveValue = 1;
    private bool _dissolveFlg;

  private bool _wasMoving;

    private const int Dissolve = 1;
    private const int Attack = 2;
    private const int Surprised = 3;

    private static bool Held(KeyCode arrow, KeyCode wasd) => Input.GetKey(arrow) || Input.GetKey(wasd);

    [FormerlySerializedAs("Speed")] [SerializeField]
    private float speed = 4;

    void Start()
    {
        _anim = this.GetComponent<Animator>();
        _characterController = this.GetComponent<CharacterController>();
        
        _startPosition = this.transform.position;
        _startRotation = this.transform.rotation;
    }

    void Update()
    {
        Status();
        Gravity();
        if (!_playerStatus.ContainsValue(true))
        {
            Move();
            // PlayerAttack();
        }
        else if (_playerStatus.ContainsValue(true))
        {
            int statusName = 0;
            foreach (var i in _playerStatus)
            {
                if (i.Value)
                {
                    statusName = i.Key;
                    break;
                }
            }

            if (statusName == Dissolve)
            {
                PlayerDissolve();
            }
            else if (statusName == Attack)
            {
                // PlayerAttack();
            }
            else if (statusName == Surprised)
            {
            }
        }
    }

    private Dictionary<int, bool> _playerStatus = new Dictionary<int, bool>
    {
        { Dissolve, false },
        { Attack, false },
        { Surprised, false },
    };

    private void Status()
    {
        if (_dissolveFlg && DataContainer.Hp <= 0)
        {
            _playerStatus[Dissolve] = true;
        }
        else if (!_dissolveFlg)
        {
            _playerStatus[Dissolve] = false;
        }

        if (_anim.GetCurrentAnimatorStateInfo(0).tagHash == AttackTag)
        {
            _playerStatus[Attack] = true;
        }
        else if (_anim.GetCurrentAnimatorStateInfo(0).tagHash != AttackTag)
        {
            _playerStatus[Attack] = false;
        }

        if (_anim.GetCurrentAnimatorStateInfo(0).fullPathHash == SurprisedState)
        {
            _playerStatus[Surprised] = true;
        }
        else if (_anim.GetCurrentAnimatorStateInfo(0).fullPathHash != SurprisedState)
        {
            _playerStatus[Surprised] = false;
        }
    }

    private void PlayerDissolve()
    {
        _dissolveValue -= Time.deltaTime;
        for (int i = 0; i < meshR.Length; i++)
        {
            meshR[i].material.SetFloat("_Dissolve", _dissolveValue);
        }

        if (_dissolveValue <= 0)
        {
            _characterController.enabled = false;
        }
    }

    // private void PlayerAttack()
    // {
    //     if (Input.GetKeyDown(KeyCode.A))
    //     {
    //         _anim.CrossFade(AttackState, 0.1f, 0, 0);
    //     }
    // }

    private void Gravity()
    {
        if (_characterController.enabled)
        {
            if (CheckGrounded())
            {
                if (_moveDirection.y < -0.1f)
                {
                    _moveDirection.y = -0.1f;
                }
            }

            _moveDirection.y -= 0.1f;
            _characterController.Move(_moveDirection * Time.deltaTime);
        }
    }

    private bool CheckGrounded()
    {
        if (_characterController.isGrounded && _characterController.enabled)
        {
            return true;
        }

        Ray ray = new Ray(this.transform.position + Vector3.up * 0.1f, Vector3.down);
        float range = 0.2f;
        return Physics.Raycast(ray, range);
    }


    private void Move()
    {
        bool up = Held(KeyCode.UpArrow, KeyCode.W);
        bool down = Held(KeyCode.DownArrow, KeyCode.S);
        bool right = Held(KeyCode.RightArrow, KeyCode.D);
        bool left = Held(KeyCode.LeftArrow, KeyCode.A);
        bool isMoving = up || down || right || left;

        if (isMoving && !_wasMoving)
        {
            _anim.CrossFade(MoveState, 0.1f, 0, 0);
        }
        else if (!isMoving && _wasMoving)
        {
            _anim.CrossFade(IdleState, 0.1f, 0, 0);
        }

        if (up)
        {
            MOVE_Velocity(new Vector3(0, 0, -speed), new Vector3(0, 180, 0));
        }
        else if (down)
        {
            MOVE_Velocity(new Vector3(0, 0, speed), new Vector3(0, 0, 0));
        }
        else if (left)
        {
            MOVE_Velocity(new Vector3(speed, 0, 0), new Vector3(0, 90, 0));
        }
        else if (right)
        {
            MOVE_Velocity(new Vector3(-speed, 0, 0), new Vector3(0, 270, 0));
        }
    }

    private void MOVE_Velocity(Vector3 velocity, Vector3 rot)
    {
        _moveDirection = new Vector3(velocity.x, _moveDirection.y, velocity.z);
        if (_characterController.enabled)
        {
            _characterController.Move(_moveDirection * Time.deltaTime);
        }

        _moveDirection.x = 0;
        _moveDirection.z = 0;
        this.transform.rotation = Quaternion.Euler(rot);
    }

    private void Damage()
    {
        DataContainer.Hp--;
        if (DataContainer.Hp <= 0)
        {
            Death();
        }
        else
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        _characterController.enabled = false;
        this.transform.position = _startPosition;
        this.transform.rotation = _startRotation;
        _characterController.enabled = true;

        _moveDirection = Vector3.zero;
        _wasMoving = false;

        _dissolveValue = 1;
        for (int i = 0; i < meshR.Length; i++)
        {
            meshR[i].material.SetFloat("_Dissolve", _dissolveValue);
        }

        _anim.CrossFade(IdleState, 0.1f, 0, 0);
    }

    private void Death()
    {
        if (DataContainer.Hp <= 0 && !_dissolveFlg)
        {
            _anim.CrossFade(DissolveState, 0.1f, 0, 0);
            _dissolveFlg = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lava"))
        {
            Damage();
        }
    }
}