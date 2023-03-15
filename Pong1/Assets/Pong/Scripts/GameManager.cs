using UnityEngine;

public class GameManager : MonoBehaviour
{
    //declare all the variables to be used later
    public Transform ball;
    public float startSpeed = 5f;
    public GoalTrigger leftGoalTrigger;
    public GoalTrigger rightGoalTrigger;

    private int leftScore = 0;
    private int rightScore = 0;
    private Vector3 startPos;

    // start the ball
    void Start()
    {
        startPos = ball.position;
        Rigidbody ballBody = ball.GetComponent<Rigidbody>();
        ballBody.velocity = new Vector3(1f, 0f, 0f) * startSpeed;
    }
    
    //increment score and debug log which side scored and its updated score
    public void OnGoalTrigger(GoalTrigger trigger)
    {
        if (trigger == leftGoalTrigger)
        {
            rightScore++;
            Debug.Log($"Right scored: {rightScore}");
            
            //end game when right player gets 11 points
            if (rightScore == 11)
            {
                Debug.Log("Right won. Please reset game");
            }
            else
            {
                ResetBall(-1f);
            }
        }
        else if (trigger == rightGoalTrigger)
        {

            leftScore++;
            Debug.Log($"Left scored: {leftScore}");
            
            //end game when left player gets 11 points
            if (leftScore == 11)
            {
                Debug.Log("Left won. Please reset game");
            }
            else
            {
                ResetBall(1f);
            }
        }
    }

    void ResetBall(float directionSign)
    {
        ball.position = startPos;
        
        directionSign = Mathf.Sign(directionSign);
        Vector3 newDirection = new Vector3(directionSign, 0f, 0f) * startSpeed;

        var rbody = ball.GetComponent<Rigidbody>();
        rbody.velocity = newDirection;
        rbody.angularVelocity = new Vector3();
    }
}
