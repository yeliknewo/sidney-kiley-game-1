using System.Collections.Generic;
using UnityEngine;

public class FirstController : MonoBehaviour
{
	private Board board;

	void Start()
	{
		board = new Board();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Player currentPlayer = board.GetCurrentPlayer();
			List<Card> deck = currentPlayer.GetDeck();
			List<Card> hand = currentPlayer.GetHand();
			List<Card> discardPile = currentPlayer.GetDiscardPile();
			Debug.Log("Deck");
			foreach(Card card in deck)
			{
				Debug.Log(card.GetCardType());
			}
			Debug.Log("Hand");
			foreach (Card card in hand)
			{
				Debug.Log(card.GetCardType());
			}
			Debug.Log("Discard");
			foreach (Card card in discardPile)
			{
				Debug.Log(card.GetCardType());
			}
			board.Turn();
		}
	}
}
