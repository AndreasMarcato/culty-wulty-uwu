using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
      private Animator _animator;


    // Start is called before the first frame update
    void Awake()
    {
         _animator = gameObject.GetComponent<Animator>();
    }

    public void StartWalking() => _animator.SetTrigger("StartWalking");
    public void StopWalking() => _animator.SetTrigger("StopWalking");

    public void DoMagic() => _animator.SetTrigger("Magic");




    }





