using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeInimigo : MonoBehaviour {

	[SerializeField]
	private GameObject inimigo;
	private float tempoGeracaoAnterior;
	[SerializeField]
	private float tempoDeGeracao = 2f;

	// Update is called once per frame
	void Update () {
		geraInimigo ();
	}

	private void geraInimigo(){
		float tempoAtual = Time.time;
		if(tempoAtual > tempoGeracaoAnterior + tempoDeGeracao){
			tempoGeracaoAnterior = tempoAtual;
			Vector3 posicaoDeGeracao = this.transform.position;
			Instantiate (inimigo,posicaoDeGeracao,Quaternion.identity);
		}
	}
}
