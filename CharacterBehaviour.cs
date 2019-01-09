using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    public enum ActionType { Move, Attack, Idle, Buy };
    public enum ActionStatus { Complete, Process};

    public class Action
    {
        public GameObject targetObject;
        public ActionType actionType;
        public ActionStatus actionStatus;

        public void Move(Vector3 point)
        {

        }

        public void Attack(GameObject character)
        {

        }

        public void Enter(GameObject building)
        {

        }
    }

    private int rad = 10;
    private Vector3 randDir;
    [SerializeField]
    private Action currentAction;

    public int health = 100;
    public int mana = 100;
    public int exp = 0;
    public int lvl = 1;
    public int speed = 10;

    public float radiusDamage = 0.5f;
    public int valueDamage = 20;
    public float radiusView = 20;

    //Generate action from parameters
    public Action GenerateAction()
    {
        Action action = new Action();

        return action;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (currentAction != null)
        {
            if (currentAction.actionStatus != ActionStatus.Complete)
            {

            }
        }
        else
        {
            currentAction = GenerateAction();
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radiusView);
    }


}
