/*
	SetRenderQueue.cs
	
	Sets the RenderQueue of an object's materials on Awake. This will instance
	the materials, so the script won't interfere with other renderers that
	reference the same materials.
*/

using UnityEngine;

[AddComponentMenu("Rendering/SetRenderQueue")]

public class SetRenderQueue : MonoBehaviour {
	
	[SerializeField]
	protected int[] m_queues = new int[]{3000};

	protected void Awake() {
		Renderer[] renders = GetComponentsInChildren<Renderer>();
		for (int i = 0; i < renders.Length; ++i) {
			Material[] materials = renders[i].materials;
			for(int k=0;k<materials.Length;k++){
				materials[k].renderQueue = 3000;
			}
		}
	}
}