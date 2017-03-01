
using System.Collections.Generic;

public class Player
{
	private List<Card> deck;
	private List<Card> hand;
	private List<Card> discardPile;
	private CardTable cardTable;

	public Player(int deckSize, int handSize, CardTable cardTable, Board board)
	{
		deck = new List<Card>();
		hand = new List<Card>();
		discardPile = new List<Card>();
		this.cardTable = cardTable;

		for (int i = 0; i < deckSize; i++)
		{
			deck.Add(new Card(CardType.Archmage));
		}

		for (int i = 0; i < handSize; i++)
		{
			DrawCard(board);
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

	public void DrawCard(Board board)
	{
		Card card = GetNextCardFromDeck();
		if(card != null)
		{
			cardTable.HandleOnDraw(board, this, card);
			AddCardToHand(card);
		}
	}

	public List<Card> GetDeck()
	{
		return deck;
	}

	public List<Card> GetHand()
	{
		return hand;
	}

	public List<Card> GetDiscardPile()
	{
		return discardPile;
	}
}