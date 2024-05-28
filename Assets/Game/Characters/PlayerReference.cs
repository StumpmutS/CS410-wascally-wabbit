using UnityEngine;
using Utility;

public class PlayerReference : Singleton<PlayerReference>
{
    public GameObject Player => gameObject;
}