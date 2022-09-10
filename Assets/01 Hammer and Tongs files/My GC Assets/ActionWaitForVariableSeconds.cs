namespace GameCreator.Core
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.Events;
    using GameCreator.Variables;

	[AddComponentMenu("")]
	public class ActionWaitForVariableSeconds : IAction
	{
        //damon - I made this action to be able to wait for a variable number of seconds
        [VariableFilter(Variable.DataType.Number)]
        public VariableProperty variable = new VariableProperty(Variable.VarType.GlobalVariable);
        private bool forceStop = false;

        public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
        {
            this.forceStop = false;
            //cast the variable.Get() into a float
            float stopTime = Time.time + (float)variable.Get();
            WaitUntil waitUntil = new WaitUntil(() => Time.time > stopTime || this.forceStop);

            yield return waitUntil;
            yield return 0;
        }
        
        public override void Stop()
        {
            this.forceStop = true;
        }

#if UNITY_EDITOR
        public static new string NAME = "Custom/ActionWaitForVariableSeconds";
		#endif
	}
}
