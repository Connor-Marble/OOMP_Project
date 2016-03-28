using UnityEngine;
using System.Collections;

public class TerrainGenerator : MonoBehaviour {

	private MusicListener listener;
	private float[] spectrum;
	public MeshFilter meshFilter;
	public MeshCollider collider;
	int samples =  64;
	int length = 160;
	Vector3[] verts;
	Mesh terrainMesh;

	[SerializeField]
	private float heightMult;
	
	[SerializeField]
	private float updateRate;
	
	private float lastUpdate;
	private float updatePeriod;
	
	// Use this for initialization
	void Start () {
		listener = FindObjectOfType<MusicListener> ();
		spectrum = new float[samples];
		updatePeriod = 1f/updateRate;
		lastUpdate = 0f;
		
		meshFilter = GetComponent<MeshFilter> ();
		collider = GetComponent<MeshCollider> ();
		terrainMesh = meshFilter.mesh;
		
		verts = new Vector3[samples*length];
		int[] triangles = new int[samples*length*6];
		
		for (int i =0; i<length; i++) {
			for(int j=0; j<samples;j++){
				verts[(i*samples)+j]=new Vector3(i,0,j);
			}
		}
		
		int index = 0;
		for (int i =1; i<length; i++) {
			for(int j=1; j<samples;j++){
				triangles[index+2] = (i*samples)+j;
				triangles[index+1] = ((i-1)*samples)+j;
				triangles[index] = (i*samples)+(j-1);
				
				triangles[index+3] = ((i-1)*samples)+j-1;
				triangles[index+4] = ((i-1)*samples)+j;
				triangles[index+5] = (i*samples)+(j-1);
				index+=6;
			}
		}
		terrainMesh.vertices = verts;
		terrainMesh.triangles = triangles;
		terrainMesh.RecalculateNormals ();
		terrainMesh.RecalculateBounds ();
		listener.GetSpec += UpdateTerrain;
	}
	
	// Update is called once per frame
	void UpdateTerrain (float[] spectrum) {
		

		while (Time.timeSinceLevelLoad - lastUpdate >= updatePeriod) {
			for (int i = verts.Length-samples-1; i>=0; i--) {
				verts [i + samples] = new Vector3 (
					verts [i + samples].x,
					Mathf.Lerp (verts [i].y, verts [i + samples].y, Time.timeSinceLevelLoad - lastUpdate),
					verts [i + samples].z);
			}
			lastUpdate += updatePeriod;
		}
		
		transform.position = new Vector3(Time.timeSinceLevelLoad - lastUpdate,0,transform.position.z);
		
		for (int i =0; i<samples; i++) {
			verts[i] = new Vector3(verts[i].x,Mathf.Pow(spectrum[i], 0.3f)*heightMult,verts[i].z);
		}
		meshFilter.mesh.vertices = verts;
		meshFilter.mesh.RecalculateNormals ();
		meshFilter.mesh.RecalculateBounds ();
	}
	
	public bool isUnder(Vector3 position){
		if (meshFilter.mesh.bounds.Contains (position)) {
			Vector3 localPosition = transform.InverseTransformPoint (position);
			return GetHeightAtPos(position) < position.y;
		}
		return true;
	}
	
	private float GetHeightAtPos(Vector3 localPosition){
		return 1f;
	}
	
	public float getChannel(int channel){
		return spectrum[channel];
	}
	
	public float getUpdateRate(){
		return updateRate;
	}
	
	public int getLength(){
		return length;
	}
	
}