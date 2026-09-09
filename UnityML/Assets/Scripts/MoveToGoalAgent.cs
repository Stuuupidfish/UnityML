using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
public class MoveToGoalAgent: Agent
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private Material winMaterial;
    [SerializeField] private Material loseMaterial;
    [SerializeField] private MeshRenderer floorMeshRenderer;
    public override void OnActionReceived(ActionBuffers actions)
    {
        float moveX = actions.ContinuousActions[0]; //get the first action from the action buffer
        float moveZ = actions.ContinuousActions[1]; //get the second action from the action buffer

        float moveSpeed = 2.5f;
        Vector3 vector = new Vector3(moveX, 0, moveZ);
        transform.localPosition += vector.normalized * Time.deltaTime * moveSpeed; //move the agent based on the actions received
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition); 
        sensor.AddObservation(targetTransform.localPosition);
    }
    public override void OnEpisodeBegin()
    {
        transform.localPosition = Vector3.zero;
    }
    
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        //manually control the agent using keyboard/input
        //test your environment before you've trained a model
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetAxis("Horizontal"); //map the horizontal input to the first action
        continuousActions[1] = Input.GetAxis("Vertical"); //map the vertical input to the second action
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Goal>(out Goal goal))
        {
            SetReward(1f); //in this case reward amt doesnt matter-- it has to be relative to the other rewards in the environment. this is just a simple example
            floorMeshRenderer.material = winMaterial;
            EndEpisode();
        }
        if (other.TryGetComponent<Wall>(out Wall wall))
        {
            SetReward(-1f);
            floorMeshRenderer.material = loseMaterial;
            EndEpisode();
        }
    }
}
