using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardEffect: MonoBehaviour
{
	public Card card;
	public Board board;


	public abstract void Execute();

	public void GetCardBoard()
	{
		card = GetComponent<Card>();
		board = MemoryController.Instance.board;
	}


	public IEnumerator MoveCards(Card card, Card other, int[] tempCard, int[] tempOther)
	{
		card.move.Raise(other.cardHeight, MemoryController.Instance.cardRotationTime / 3);
		other.move.Raise(other.cardHeight, MemoryController.Instance.cardRotationTime / 3);
		yield return new WaitForSecondsRealtime(MemoryController.Instance.cardRotationTime / 2);
		card.move.MoveTo(tempOther[0], tempOther[1]);
		other.move.MoveTo(tempCard[0], tempCard[1]);
		yield return new WaitForSecondsRealtime(MemoryController.Instance.cardMoveTime * 1.5f);
		card.move.Lower(MemoryController.Instance.cardRotationTime / 3);
		other.move.Lower(MemoryController.Instance.cardRotationTime / 3);
		MemoryController.Instance.effectsDone = true;
		yield return new WaitForSecondsRealtime(MemoryController.Instance.cardRotationTime / 3);
		Camera.main.GetComponent<CameraShake>().Shake(0.3f, 0.02f);
	}

	public IEnumerator MoveCards(Card[] cards)
	{
		yield return null;
	}
}