using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : GameUnit
{
    
    [SerializeField] protected Transform characterModel;
    
    [SerializeField] private Animator anim;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private Character currentTarget;
    [HideInInspector] public Character currentAttacker;
    public Transform throwPoint;
    private List<Character> targets = new List<Character>();
    private Vector3 targetDirection;

    public Weapon weapon;
    
    private string currentAnim;
    //State Machine
    protected IdleState IdleState = new();
    protected AttackState AttackState = new();
    private IState currentState;

    protected bool isAttack = false;
    private float timeToResetAttack = Constant.TIME_TO_RESET_ATTACK;
    
    public override void OnInit() {
        targets.Clear();
        characterModel.rotation = Quaternion.identity;
        ChangeState(IdleState);
    }
    
    public void OnHit() {
        if (currentAttacker.CheckTarget(this))
        {
            currentAttacker.RemoveTarget(this);
        }
    }

    public void AddTarget(Character character) {
        targets.Add(character);
        currentTarget = character;
    }

    public bool CheckTarget(Character character) {
        return targets.Contains(character);
    }

    public void RemoveTarget(Character character) {
        if (CheckTarget(character)) {
            targets.Remove(character);
            currentTarget = targets.Count > 0 ? targets[targets.Count - 1] : null;
        }
    }
    
    public void ChangeAnim(Anim ani) {
        string animName = ani.ToString();
        if (currentAnim != animName) {
            anim.ResetTrigger(currentAnim);
            currentAnim = animName;
            anim.SetTrigger(currentAnim);
        }
    }

    public void CheckAround() {
        if (targets.Count > 0) {
            currentTarget = targets[0];
            isAttack = true;
            ChangeState(AttackState);
        }
    }
    
    public void LookAtTarget()
    {
        if (currentTarget != null) {
            targetDirection = currentTarget.transform.position - transform.position;
            targetDirection.y = 0f;
            targetDirection = targetDirection.normalized;
            transform.rotation = Quaternion.LookRotation(targetDirection);
        }
    }

    public void Attack() {
        targetDirection = currentTarget.transform.position - transform.position;
        ChangeAnim(Anim.attack);
        weapon.Shoot(this, targetDirection);
    }

    public void ResetAttack() {
        if (isAttack) {
            timeToResetAttack -= Time.deltaTime;
            if (timeToResetAttack <= 0) {
                timeToResetAttack = Constant.TIME_TO_RESET_ATTACK;
                ChangeState(IdleState);
            }
        }
    }

    public void StopAttack() {
        isAttack = false;
        currentTarget = null;
    }

    public void SetAttacker(Character attacker) {
        currentAttacker = attacker;
    }
    
    public virtual void ChangeState(IState state)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }

        currentState = state;

        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }

    public virtual void Move() { }

    protected virtual void Update()
    {
        //Pause before hit play
        if (GameManager.Ins.IsState(GameState.GamePlay))
        {
            if (currentState != null)
            {
                currentState.OnExecute(this);
            }
        }
    }
}
