using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBrain : CharacterBrain
{
  [SerializeField]
  private GameObject _target;

  public void SetTarget(GameObject target)
  {
    _target = target;
  }

  protected override float GetMoveInputValue()
  {
    if (_target == null || _character.CurrentState == Character.State.Interact) return 0;
    
    if (_target.TryGetComponent(out IInteractable interactable) && _character.CanInteract(interactable))
    {
      if(_character.CurrentState != Character.State.Interact)
      {
        _character.InteractTo(interactable);
      }
      return 0;
    }
    else
    {
      var dir = Mathf.Clamp(Mathf.Round(_target.transform.position.x - transform.position.x), -1, 1);
      return (int)dir;
    }
  }
}
