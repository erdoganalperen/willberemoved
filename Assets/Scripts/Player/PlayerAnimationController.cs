using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FinishController>() != null)
        {
            GameManager.Instance.ChangeState(GameState.Scoring);
        }
    }
}
