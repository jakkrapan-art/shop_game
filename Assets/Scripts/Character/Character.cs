using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour
{
  [SerializeField]
  private CharacterData _characterData;
  [SerializeField]
  private Rigidbody2D _rb;

  private void Awake()
  {
    _rb = GetComponent<Rigidbody2D>();
  }

  public void Move(EnumTypes.HoriziontalDirection direction)
  {
    int dir = (int)direction;
    _rb.velocity = new Vector2(dir * _characterData.MoveSpeed, 0) * Time.fixedDeltaTime;
  }

  public void StopMove()
  {
    _rb.velocity = Vector2.zero;
  }
}
