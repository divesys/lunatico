using UnityEngine;
using System.Collections;

public abstract class BaseSkill : MonoBehaviour {
	
	public MonoBehaviour[] ComponentsToDesactive;
	public float TimeoutExecuting;
	public string MoonPhase;
	public bool StopAfterTime;
	
	//private bool skillActive;
	private bool executing;
	
	protected abstract void Execute();
	
	void Start () {
		//skillActive = true;
	}
	
	void Update () {
		
		if (ValidateExecution())
		{
			PreExecute();
			Execute();
			StartCoroutine(WaitingExecution());
		}
		
		if (ValidateStopExecution() && !StopAfterTime)
		{
			StopExecution();
		}
	}
	
	private IEnumerator WaitingExecution()
	{
		yield return new WaitForSeconds(TimeoutExecuting);
		
		if (StopAfterTime && ValidateStopExecution())
		{
			StopExecution();
		}
	}
	
	private void StopExecution()
	{
		PosExecute();
	}
	
	protected virtual void PreExecute()
	{
		executing = true;
		ChangeActivitiesComponents(false);
	}
	
	protected virtual void PosExecute()
	{
		executing = false;
		ChangeActivitiesComponents(true);
	}
	
	protected virtual bool ValidateStopExecution()
	{
		return IsExecuting();
	}
	
	protected virtual bool ValidateExecution()
	{
		return (Input.GetButtonDown("skill")) && (simuladorDaFaseDaLua.faseDaLuaSimulada.Equals(MoonPhase));
	}
	
	private void ChangeActivitiesComponents(bool enabled)
	{
		foreach (MonoBehaviour component in ComponentsToDesactive)
		{
			component.enabled = enabled;
		}
	}
	
	public bool IsExecuting()
	{
		return executing;
	}
	
}
