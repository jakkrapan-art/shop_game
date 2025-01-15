using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour
{
  public enum State { Idle, Move, Interact}

  [SerializeField]
  private CharacterData _characterData;
  [SerializeField]
  private Rigidbody2D _rb;
  public CharacterBrain Brain { get; private set; }
  public InteractController InteractController { get; private set; }
  public State CurrentState { get; private set; }

  private void Awake()
  {
    _rb = GetComponent<Rigidbody2D>();
  }

  #region Setter
  public void SetBrain(CharacterBrain brain)
  {
    Brain = brain;
  }
  public void SetupInteractSystem()
  {
    InteractController = new InteractController(3, transform);
  }
  #endregion

  public void Move(EnumTypes.HoriziontalDirection direction)
  {
    int dir = (int)direction;
    _rb.velocity = new Vector2(dir * _characterData.MoveSpeed, 0) * Time.fixedDeltaTime;
  }

  #region Interact System
  public bool CanInteract(IInteractable target)
  {
    if(InteractController == null)
    {
      return false;
    }

    return InteractController.IsCanInteract(transform.position.x, target.GetPosition().x, transform.lossyScale.x);
  }

  public void InteractTo(IInteractable target)
  {
    if (InteractController == null) return;

    InteractController.InteractTo(target, ()=> CurrentState = State.Idle);
    CurrentState = State.Interact;
  }
  #endregion
}
