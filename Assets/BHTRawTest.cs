using UnityEngine;
using System.Collections;

using RoomOfRequirement.AI.BehaviorTree;
using RoomOfRequirement.AI.Data;

public class BHTRawTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Task root = new Sequence(
			new PrintTask().SetMessage("Go to door"),
			new PrintTask().SetMessage("Knock knock"),
			new UntilFail(new Limit(new PrintTask().SetMessage("Waiting..."),10)));
		root.Run(new HierarchicalBlackboard());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

public class PrintTask : Task {

	string message;

	public Task SetMessage(string msg) {
		message = msg;
		return this;
	}

	public override TaskReturnValue Run (HierarchicalBlackboard blackboard) {
		Debug.Log(message);
		return TaskReturnValue.SUCCESS;
	}
}
