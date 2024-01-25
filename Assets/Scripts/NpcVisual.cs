using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcVisual : MonoBehaviour
{
    private Animator _animator;


    // Start is called before the first frame update
    void Awake()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    public void StartWalking() => _animator.SetTrigger("StartWalking");
    public void StopWalking() => _animator.SetTrigger("StopWalking");
    public void BossInteract() => _animator.SetTrigger("Interact");
    public void BossDefeat()
    {
        _animator.SetTrigger("Defeat");
        GameManager.Instance.failCount += 50;

    }
}
