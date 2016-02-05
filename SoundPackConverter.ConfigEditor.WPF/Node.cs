using System.Collections.Generic;

namespace SoundPackConverter.ConfigEditor.WPF
{
    public class Node
    {
        public string Value { get; set; }
        public List<Node> Nodes { get; set; } = new List<Node>();

        public Node(string value)
        {
            Value = value;
        }
    }
}