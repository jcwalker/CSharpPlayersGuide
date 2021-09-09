using System;

CardColor[] colorList = new CardColor[] { CardColor.Red, CardColor.Green, CardColor.Blue };
CardRank[] rankList = new CardRank[] { CardRank.One,CardRank.Two, CardRank.Three, CardRank.Four, CardRank.Five, CardRank.Six, CardRank.Seven, CardRank.Eight, CardRank.Nine, CardRank.Ten, CardRank.Dollar, CardRank.Percent, CardRank.Caret, CardRank.Ampersand };

foreach (CardColor color in colorList)
{
    foreach (CardRank rank in rankList)
    {
        Card card = new Card(color, rank);
        Console.WriteLine($"The {card.Color} {card.Rank} is a type of {card.RankType}");
    }
}

public class Card
{
    public CardColor Color { get; }
    public CardRank Rank { get; }

    public string RankType { get; }

    public Card(CardColor c, CardRank r)
    {
        this.Color = c;
        this.Rank = r;
        this.RankType = GetRankType();
    }

    private string GetRankType()
    {
        if (this.Rank == CardRank.Dollar | this.Rank == CardRank.Percent | this.Rank == CardRank.Caret | this.Rank == CardRank.Ampersand)
        {
            return "Symbol";
        }

        return "Number";
    }
}

public enum CardColor { Red, Green, Blue };
public enum CardRank { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Dollar, Percent, Caret, Ampersand };
