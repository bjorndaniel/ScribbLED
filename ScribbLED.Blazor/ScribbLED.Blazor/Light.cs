using System.Linq;
using ScribbLED.Common;

namespace ScribbLED
    {
    public class Light
    {
        private string _color = "#000000";
        public string Color
        {
            get { return _color; }
            set
            {
                Style = Style.Replace(_color, value);
                _color = value;
            }
        }
        public int Row { get; set; }
        public int Column { get; set; }
        public string Style { get; set; } = $"width:50px;height:50px;background-color:#000000;border-radius:5px;";
        public override string ToString() =>
            $"{{\"Led\":\"{GetLedNumber()}\",\"Color\":\"{GetLedColor()}\"}}";
        public string GetLedColor() =>
            Color.Substring(1).ChunkSplit(2).Select(_ => $"0x{_}").Aggregate((a, b) => $"{a};{b}");
        public int GetLedNumber() =>
            Column * 7 + (Column % 2 == 0 ? Row : (6 - Row));
    }
 }