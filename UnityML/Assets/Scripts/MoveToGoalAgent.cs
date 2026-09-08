using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
public class MoveToGoalAgent: Agent
{
    [SerializeField] private Transform targetTransform;
    public override void OnActionReceived(ActionBuffers actions)
    {
        //base.OnActionReceived(actions);
        float moveX = actions.ContinuousActions[0]; //get the first action from the action buffer
        float moveZ = actions.ContinuousActions[1]; //get the second action from the action buffer

        float moveSpeed = 1f; //set the speed of the agent
        transform.position += new Vector3(moveX, 0, moveZ) * Time.deltaTime * moveSpeed; //move the agent based on the actions received
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        //base.CollectObservations(sensor);
        sensor.AddObservation(transform.position); //give the AI the position of the agent
        sensor.AddObservation(targetTransform.position); //give the AI the position of the goal
    }
}
