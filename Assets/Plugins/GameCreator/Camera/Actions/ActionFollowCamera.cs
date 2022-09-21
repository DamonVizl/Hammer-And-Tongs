﻿namespace GameCreator.Camera
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.Events;
	using GameCreator.Core;

	#if UNITY_EDITOR
	using UnityEditor;
	#endif

	[AddComponentMenu("")]
    public class ActionFollowCamera : IAction
	{
        public bool mainCameraMotor = false;
        public CameraMotor cameraMotor;

        public TargetGameObject anchor = new TargetGameObject(TargetGameObject.Target.Invoker);
        public Vector3 anchorOffset = new Vector3(); //damon added this -
        public TargetDirection lookAt = new TargetDirection(TargetDirection.Target.Player);

        // EXECUTABLE: ----------------------------------------------------------------------------

        public override bool InstantExecute(GameObject target, IAction[] actions, int index)
        {
            CameraMotor motor = (this.mainCameraMotor ? CameraMotor.MAIN_MOTOR : this.cameraMotor);
            if (motor != null && motor.cameraMotorType.GetType() == typeof(CameraMotorTypeFollow))
            {
                CameraMotorTypeFollow followMotor = (CameraMotorTypeFollow)motor.cameraMotorType;
                followMotor.anchor = this.anchor;
                followMotor.anchorOffset = this.anchorOffset; //damon added this - this line assigns the offset made in the inspector to the actual camera motor. 
                followMotor.lookAt = this.lookAt;
            }

            return true;
        }

		// +--------------------------------------------------------------------------------------+
		// | EDITOR                                                                               |
		// +--------------------------------------------------------------------------------------+

		#if UNITY_EDITOR

	    public static new string NAME = "Camera/Follow Camera Settings";
        private const string NODE_TITLE = "Change {0} Follow Camera settings";

		// PROPERTIES: ----------------------------------------------------------------------------

		private SerializedProperty spMainCameraMotor;
        private SerializedProperty spCameraMotor;

        private SerializedProperty spAnchor;
        private SerializedProperty spAnchorOffset; //damon added this - i dont even understand these that well. but i assume it has to be in there
        private SerializedProperty spLookAt;

		// INSPECTOR METHODS: ---------------------------------------------------------------------

		public override string GetNodeTitle()
		{
            string motor = (this.mainCameraMotor
                ? "[Main Camera]"
                : (this.cameraMotor == null ? "none" : this.cameraMotor.gameObject.name)
            );
            
			return string.Format(NODE_TITLE, motor);
		}

		protected override void OnEnableEditorChild ()
		{
            this.spMainCameraMotor = this.serializedObject.FindProperty("mainCameraMotor");
            this.spCameraMotor = this.serializedObject.FindProperty("cameraMotor");

            this.spAnchor = this.serializedObject.FindProperty("anchor");
            this.spAnchorOffset = this.serializedObject.FindProperty("anchorOffset"); //damon added this - i dont even understand these that well. but i assume it has to be in there
            this.spLookAt = this.serializedObject.FindProperty("lookAt");
		}

		protected override void OnDisableEditorChild ()
		{
            this.spMainCameraMotor = null;
            this.spCameraMotor = null;
            this.spAnchor = null;
            this.spAnchorOffset = null; //damon added this - i dont even understand these that well. but i assume it has to be in there
            this.spLookAt = null;
		}

		public override void OnInspectorGUI()
		{
			this.serializedObject.Update();

            EditorGUILayout.PropertyField(this.spMainCameraMotor);
            EditorGUI.BeginDisabledGroup(this.spMainCameraMotor.boolValue);
            EditorGUILayout.PropertyField(this.spCameraMotor);
            EditorGUI.EndDisabledGroup();
            EditorGUILayout.Space();

            EditorGUILayout.PropertyField(this.spAnchor);
            EditorGUILayout.PropertyField(this.spAnchorOffset); //damon added this - Pretty sure this one is responsible for drawing it to the GUI in the editor. 
            EditorGUILayout.PropertyField(this.spLookAt);
			this.serializedObject.ApplyModifiedProperties();
		}

		#endif
	}
}
