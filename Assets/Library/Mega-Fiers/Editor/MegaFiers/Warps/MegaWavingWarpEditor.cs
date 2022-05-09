
using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects, CustomEditor(typeof(MegaWavingWarp))]
public class MegaWavingWarpEditor : MegaWarpEditor
{
	[MenuItem("GameObject/Create Other/MegaFiers/Warps/Waving")]
	static void CreateStarShape() { CreateWarp("Waving", typeof(MegaWavingWarp)); }

	public override string GetHelpString() { return "Waving Warp Modifier by Chris West"; }
	public override Texture LoadImage() { return (Texture)EditorGUIUtility.LoadRequired("MegaFiers\\bend_help.png"); }

	public override bool Inspector()
	{
		MegaWavingWarp mod = (MegaWavingWarp)target;

#if !UNITY_5 && !UNITY_2017 && !UNITY_2018 && !UNITY_2019 && !UNITY_2020 && !UNITY_2021
		EditorGUIUtility.LookLikeControls();
#endif

		mod.amp = EditorGUILayout.FloatField("Amp", mod.amp * 100.0f) * 0.01f;
		mod.wave = EditorGUILayout.FloatField("Wave", mod.wave);
		mod.phase = EditorGUILayout.FloatField("Phase", mod.phase);
		mod.Decay = EditorGUILayout.FloatField("Decay", mod.Decay);
		mod.animate = EditorGUILayout.Toggle("Animate", mod.animate);
		mod.Speed = EditorGUILayout.FloatField("Speed", mod.Speed);
		mod.waveaxis = (MegaAxis)EditorGUILayout.EnumPopup("Axis", mod.waveaxis);
		return false;
	}
}