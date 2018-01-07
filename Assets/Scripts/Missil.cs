using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missil : MonoBehaviour {

	[SerializeField]
	private int dano;
	private GameObject alvo;

	[Range(0,20)]
	public float tempoDeVidaMissil = 10;

	[Range(0,20)]
	public float velocidade = 15;


	// Use this for initialization
	void Start () {
		DestroiAposTempoDeVida ();
	}
	
	// Update is called once per frame
	void Update () {
		Anda ();	
		segueInimigo ();
	}

	private void Anda(){
		//recupera a posicao atual do gameObject
		Vector3 posicaoAtual = transform.position;
		//calcula o descocamento Time.deltaTime(ajusta o calculo com base entra a velocidade do frame anterior e o atual) 
		Vector3 deslocamento = transform.forward * Time.deltaTime * velocidade;
		//soma o deslocamento na posicao atual do gameObject
		transform.position = posicaoAtual + deslocamento;
	}

	private void DestroiAposTempoDeVida(){
		Destroy (this.gameObject, tempoDeVidaMissil);
	}

	private void segueInimigo(){
		if(alvo){
			Vector3 posicaoAtualMissil = transform.position;
			Vector3 posicaoAtualInimigo = alvo.transform.position;
			Vector3 direcaoMissil = posicaoAtualInimigo - posicaoAtualMissil;
			//LookRotation aponta pra direção informada
			transform.rotation = Quaternion.LookRotation (direcaoMissil);
		}
	}

	public void DefineAlvo(GameObject alvo){
		if(alvo){
			this.alvo = alvo;
		}
	}

	//chama quando ocorre uma colisão
	void OnTriggerEnter(Collider itemColidico){
		if (itemColidico.CompareTag ("Inimigo")) {
			Destroy (this.gameObject);
			Inimigo inimigo = itemColidico.GetComponent<Inimigo> ();
			inimigo.RecebeDano (dano);
		} 
	}
}
