
using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects, CustomEditor(typeof(MegaDeformable))]
public class MegaDeformableEditor : MegaModifierEditor
{
	public override string GetHelpString() { return "Deformable Modifier by Chris West"; }

	public override bool Inspector()
	{
		MegaDeformable mod = (MegaDeformable)target;

#if !UNITY_5 && !UNITY_2017 && !UNITY_2018 && !UNITY_2019 && !UNITY_2020 && !UNITY_2021
		EditorGUIUtility.LookLikeControls();
#endif

		mod.Hardness = EditorGUILayout.FloatField("Hardness", mod.Hardness);
		Texture2D hmap = (Texture2D)EditorGUILayout.ObjectField("Hardness Map", mod.HardnessMap, typeof(Texture2D), true);
		if ( hmap != mod.HardnessMap )
		{
			mod.HardnessMap = hmap;
			mod.LoadMap();
		}

		mod.impactFactor = EditorGUILayout.FloatField("Impact Factor", mod.impactFactor);
		mod.ColForce = EditorGUILayout.FloatField("Collision Force", mod.ColForce);
		mod.MaxVertexMov = EditorGUILayout.FloatField("Max Vertex Move", mod.MaxVertexMov);
		mod.DeformedVertexColor = EditorGUILayout.ColorField("Deformed Color", mod.DeformedVertexColor);
		mod.usedecay = EditorGUILayout.BeginToggleGroup("Use Decay", mod.usedecay);
		mod.decay = EditorGUILayout.FloatField("Decay", mod.decay);
		EditorGUILayout.EndToggleGroup();

		return false;
	}
}