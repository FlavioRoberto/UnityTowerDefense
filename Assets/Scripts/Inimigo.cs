using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Inimigo : MonoBehaviour {

	[SerializeField] //permite a edição via interface do unity
	private int vida;

	// Use this for initialization
	void Start () {
		NavMeshAgent agent = GetComponent<NavMeshAgent> ();
		GameObject fimDoCaminho =  GameObject.Find ("FimDoCaminho");
		Vector3 posicaoFimDoCaminho = fimDoCaminho.transform.position; 
		agent.SetDestination(posicaoFimDoCaminho);
	}

	public void RecebeDano(int dano){
		vida -= dano;
		if (vida <= 0)
			Destroy (gameObject);
	}

}
