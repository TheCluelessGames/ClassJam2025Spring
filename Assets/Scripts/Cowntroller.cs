using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cowntroller : MonoBehaviour
{
    UIController uIController;
    private EnemyCowController.ObjectType currentType;
    [SerializeField] private Transform UpperJumpPoint, LowerJumpPoint;
    [SerializeField] private float jumpSpeed = 5f;
    [SerializeField] private Animator animator;
    [SerializeField] private List<SpriteRenderer> CurrentSprites;
    [SerializeField] private List<Sprite> White;
    [SerializeField] private List<Sprite> Red;
    [SerializeField] private List<Sprite> Green;
    [SerializeField] private List<Sprite> Blue;
    [SerializeField] private List<Sprite> Orange;
    [SerializeField] private List<Sprite> Purple;
    [SerializeField] private List<Sprite> Yellow;

    private Vector3 targetPosition;
    private bool isJumping = false;

    void Start()
    {
        uIController = GameObject.Find("UIController").GetComponent<UIController>();
        isJumping = true;
        currentType = EnemyCowController.ObjectType.White;
        
        targetPosition = UpperJumpPoint.position;
        StartMoving();
    }

    void Update()
    {
        if (!isJumping && Input.GetKeyDown(KeyCode.Space))
        {
            StartMoving();
        }

        if (isJumping)
        {
            MoveObject();
        }
    }

    void StartMoving()
    {        
        targetPosition = (targetPosition == UpperJumpPoint.position) ? LowerJumpPoint.position : UpperJumpPoint.position;
        animator.SetTrigger(targetPosition == LowerJumpPoint.position ? "JumpDown" : "JumpUp");
        isJumping = true;
    }

    void MoveObject()
    {        
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, jumpSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
           animator.SetTrigger("OnGround");
           isJumping = false;
        }
    }

    private void Grow()
    {
        Debug.Log("Bigger fur, yaay!");
    }

    private void ChangeColour()
    {
        List<Sprite> newSprites = new List<Sprite>();
        switch (currentType)
        {
            case EnemyCowController.ObjectType.White:
                newSprites = White;
                break;
            case EnemyCowController.ObjectType.Red:
                newSprites = Red;
                break;
            case EnemyCowController.ObjectType.Green:
                newSprites = Green;
                break;
            case EnemyCowController.ObjectType.Blue:
                newSprites = Blue;
                break;
            case EnemyCowController.ObjectType.Orange:
                newSprites = Orange;
                break;
            case EnemyCowController.ObjectType.Purple:
                newSprites = Purple;
                break;
            case EnemyCowController.ObjectType.Yellow:
                newSprites = Yellow;
                break;
        }
        for (int i = 0; i < CurrentSprites.Count; i++)
        {
            if (i < newSprites.Count && CurrentSprites[i] != null)
            {
                CurrentSprites[i].sprite = newSprites[i];
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            uIController.LoadScene("Highscore");
        }

        if (collision.CompareTag("Cow"))
        {
            EnemyCowController otherCow = collision.gameObject.GetComponent<EnemyCowController>();
            if (currentType == otherCow.selectedType)
            {
                Grow();
                otherCow.Undress();
            }
            else
            {
                uIController.LoadScene("Highscore");
            }

        }

        if (collision.CompareTag("Bucket"))
        {
            currentType = EnemyCowController.ObjectType.White;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Flower"))
        {
            EnemyCowController.ObjectType newType = collision.gameObject.GetComponent<EnemyCowController>().selectedType;
            switch (currentType)
            {
                case EnemyCowController.ObjectType.White:
                    currentType = newType;
                    break;
                case EnemyCowController.ObjectType.Red:
                    if(newType == EnemyCowController.ObjectType.Blue)
                    {
                        currentType = EnemyCowController.ObjectType.Purple;
                    } else if (newType == EnemyCowController.ObjectType.Yellow)
                    {
                        currentType = EnemyCowController.ObjectType.Orange;
                    }
                    else {
                        currentType = newType;
                    }
                    break;
                case EnemyCowController.ObjectType.Yellow:
                    if (newType == EnemyCowController.ObjectType.Blue)
                    {
                        currentType = EnemyCowController.ObjectType.Green;
                    }
                    else if (newType == EnemyCowController.ObjectType.Red)
                    {
                        currentType = EnemyCowController.ObjectType.Orange;
                    }
                    else
                    {
                        currentType = newType;
                    }
                    break;
                case EnemyCowController.ObjectType.Blue:
                    if (newType == EnemyCowController.ObjectType.Yellow)
                    {
                        currentType = EnemyCowController.ObjectType.Green;
                    }
                    else if (newType == EnemyCowController.ObjectType.Red)
                    {
                        currentType = EnemyCowController.ObjectType.Purple;
                    }
                    else
                    {
                        currentType = newType;
                    }
                    break;
            }
            Destroy(collision.gameObject);
        }
    }
    
}
