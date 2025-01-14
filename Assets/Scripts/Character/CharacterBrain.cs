using UnityEngine;

public abstract class CharacterBrain : MonoBehaviour
{
  [SerializeField]
  protected Character _character;

  public void Setup(Character character)
  {
    _character = character;
    character.SetBrain(this);
  }

  protected virtual void Update()
  {
    ControlCharacter();
  }

  public void ControlCharacter()
  {
    if (_character == null) throw new System.Exception("Character is null");

    //Move Control
    _character.Move((EnumTypes.HoriziontalDirection) GetMoveInputValue());
  }

  protected abstract float GetMoveInputValue();
}
