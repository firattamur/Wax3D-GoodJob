
using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects, CustomEditor(typeof(MegaSinusCurveWarp))]
public class MegaSinusCurveWarpEditor : MegaWarpEditor
{
	[MenuItem("GameObject/Create Other/MegaFiers/Warps/Sinus Curve")]
	static void CreateStarShape() { CreateWarp("Sinus", typeof(MegaSinusCurveWarp)); }

	public override string GetHelpString() { return "Sinus Curve Warp Modifier by Unity"; }
	//public override Texture LoadImage() { return (Texture)EditorGUIUtility.LoadRequired("MegaFiers\\bend_help.png"); }

	public override bool Inspector()
	{
		MegaSinusCurveWarp mod = (MegaSinusCurveWarp)target;

#if !UNITY_5 && !UNITY_2017 && !UNITY_2018 && !UNITY_2019 && !UNITY_2020 && !UNITY_2021
		EditorGUIUtility.LookLikeControls();
#endif
		mod.scale = EditorGUILayout.FloatField("Scale", mod.scale);
		mod.wave = EditorGUILayout.FloatField("Wave", mod.wave);
		mod.speed = EditorGUILayout.FloatField("Speed", mod.speed);
		mod.phase = EditorGUILayout.FloatField("Phase", mod.phase);
		mod.animate = EditorGUILayout.Toggle("Animate", mod.animate);
		return false;
	}
}