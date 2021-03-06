
using UnityEditor;

[CanEditMultipleObjects, CustomEditor(typeof(MegaBulge))]
public class MegaBulgeEditor : MegaModifierEditor
{

	public override bool Inspector()
	{
		MegaBulge mod = (MegaBulge)target;

#if !UNITY_5 && !UNITY_2017 && !UNITY_2018 && !UNITY_2019 && !UNITY_2020 && !UNITY_2021
		EditorGUIUtility.LookLikeControls();
#endif
		mod.Amount = EditorGUILayout.Vector3Field("Radius", mod.Amount);
		mod.FallOff = EditorGUILayout.Vector3Field("Falloff", mod.FallOff);
		mod.LinkFallOff = EditorGUILayout.Toggle("Link Falloff", mod.LinkFallOff);
		return false;
	}
}
