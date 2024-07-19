namespace SoulfulConversationsBot.Dto
{
    public class ImagesDto
    {
        public Dictionary<string, string>? Images { get; set; }

        public string this[Image key]
        {
            get
            {
                return Images![key.ToString()];
            }
        } 
    }

    public enum Image
    {
        Dice1 = 1,
        Dice2,
        Dice3,
        Dice4,
        Dice5,
        Dice6,
        CoinHead,
        CoinTail
    }
}
