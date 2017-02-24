using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField]
	private List<Card> deck;
	[SerializeField]
	private List<Card> hand;
	[SerializeField]
	private List<Card> discardPile;

	private void Start()
	{
		deck = new List<Card>();
		hand = new List<Card>();
		discardPile = new List<Card>();

		for (int i = 0; i < 10; i++)
		{
			deck.Add(new Card(CardType.Archmage));
		}

		for(int i = 0; i < 3; i++) 
		{
			DrawCard();
		}
	}

	public void Discard(Card card)
	{
		hand.Remove(card);
		discardPile.Add(card);
	}

	public Card GetNextCardFromDeck()
	{
		if (deck.Count == 0)
		{
			MoveDiscardToDeck();
			if (deck.Count == 0)
			{
				return null;
			}
		}
		Card card = deck[0];
		deck.Remove(card);
		return card;
	}

	public void MoveDiscardToDeck()
	{
		while (discardPile.Count > 0)
		{
			Card card = discardPile[0];
			discardPile.Remove(card);
			deck.Add(card);
		}
	}

	public void AddCardToHand(Card card)
	{
		hand.Add(card);
	}

	public void DrawCard()
	{
		AddCardToHand(GetNextCardFromDeck());
	}

	public List<Card> GetHand()
	{
		return hand;
	}
}