using UnityEngine;

public class Card
{
	public Card(CardType cardType)
	{
		SetCardType(cardType);
	}

	[SerializeField]
	private CardType cardType;

	public CardType GetCardType()
	{
		return cardType;
	}

	public void SetCardType(CardType cardType)
	{
		this.cardType = cardType;
	}
}

public enum CardType
{
	Archmage,
	Bahamut,
}
