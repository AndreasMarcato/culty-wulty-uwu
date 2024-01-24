using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcLogic : MonoBehaviour
{
    public bool isTalking = false;
    private NpcVisual _visuals;
    [SerializeField] float horizontalMovementSpeed = 3;
    [SerializeField] Vector2 moveHorizontal;
    private bool isDead = false;
    private Interactable _interactable;

    

    // Start is called before the first frame update
    void Start()
    {
        _visuals = gameObject.GetComponentInChildren<NpcVisual>();
        if (_visuals == null)
            _visuals = GetComponent<NpcVisual>();
        InvokeRepeating("WalkCycle", 1, 2);

        
        _interactable = gameObject.GetComponent<Interactable>();
    }

    public void WalkCycle()
    {
        if (isDead)
        {
            
            Destroy(_interactable);

            int isWalkingRight = Random.Range(0, 2);
            float randomSpeedMultiplier = Random.Range(1, 1.8f);

            if (isWalkingRight == 0)
            {
                moveHorizontal = new Vector2(1 * horizontalMovementSpeed * randomSpeedMultiplier, 0);
                FlipSprite(-gameObject.transform.localScale.x);
            }
            else
            {
                moveHorizontal = new Vector2(1 * horizontalMovementSpeed * -randomSpeedMultiplier, 0);
                FlipSprite(gameObject.transform.localScale.x);
            }

            _visuals.StartWalking();
            Destroy(gameObject, 20f);

        }
        if (!isTalking)
        {


            int idleOrWalk = Random.Range(0, 2);
            switch (idleOrWalk)
            {
                case 0:
                    //IDLE
                    _visuals.StopWalking();
                    moveHorizontal = Vector2.zero;
                    break;
                case 1:
                    //MOVE
                    int isWalkingRight = Random.Range(0, 2);

                    _visuals.StartWalking();
                    if (!isTalking)
                    {
                        float randomSpeedMultiplier = Random.Range(1, 1.8f);
                        if (isWalkingRight == 0)
                        {
                            moveHorizontal = new Vector2( 1 * horizontalMovementSpeed * randomSpeedMultiplier, 0);
                            FlipSprite(-gameObject.transform.localScale.x);
                        }
                        else
                        {
                            moveHorizontal = new Vector2(1 * horizontalMovementSpeed * -randomSpeedMultiplier, 0);
                            FlipSprite(gameObject.transform.localScale.x);
                        }
                    }
                    break;
            }
        }
        else _visuals.StopWalking();
    }

    private void OnDestroy()
    {
        CancelInvoke("WalkCycle");
    }
    // Update is called once per frame
    void Update()
    {
        if (isTalking)
        {
            moveHorizontal = Vector2.zero;
            _visuals.StopWalking();
        }
        
        transform.Translate(moveHorizontal * Time.deltaTime);
       
    }

    public void FlipSprite(float flipX) => gameObject.transform.localScale = new Vector3(flipX, gameObject.transform.localScale.y, gameObject.transform.localScale.z);

    public void KillNPC()
    {
        UIManager.Instance.HideActionPanel();
        isDead = true;
    }

}
