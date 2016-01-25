using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SoundPackConverter.ConfigEditor
{
    /// <summary>
    /// Maps a json file to a <![CDATA[ List<TreeNode> ]]> .
    /// </summary>
    public class SoundMappingTreeConverter : JsonConverter
    {
        public override bool CanWrite { get; } = false;
        public override bool CanRead { get; } = true;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new System.NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof (List<TreeNode>))
                return true;
            return false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var ret = new List<TreeNode>();
            
            var jobj = JObject.Load(reader);

            foreach (JProperty token in jobj.Properties())
            {
                switch (token.Value.Type)
                {
                    case JTokenType.Object:
                        ret.Add(HandleJObject(token.Value as JObject, token.Name));
                        break;
                    case JTokenType.Property:
                        ret.Add(HandleJProperty(token));
                        break;
                    case JTokenType.Array:
                        ret.Add(HandleJArray(token.Value as JArray, token.Name));
                        break;
                }
            }

            return ret;
        }

        private TreeNode HandleJProperty(JProperty jProperty)
        {
            var currentNode = new TreeNode(jProperty.Name);
            switch (jProperty.Value.Type)
            {
                case JTokenType.Object:
                    currentNode.Nodes.Add(HandleJObject(jProperty.Value as JObject, jProperty.Name));
                    break;
                case JTokenType.Property:
                    currentNode.Nodes.Add(HandleJProperty(jProperty.Value as JProperty));
                    break;
                case JTokenType.Array:
                    currentNode.Nodes.Add(HandleJArray(jProperty.Value as JArray, jProperty.Name));
                    break;
            }
            return currentNode;
        }

        private TreeNode HandleJObject(JObject jObject, string key)
        {
            var root = new TreeNode(key);
            foreach (JProperty token in jObject.Properties())
            {
                switch (token.Value.Type)
                {
                    case JTokenType.Object:
                        root.Nodes.Add(HandleJObject(token.Value as JObject, token.Name));
                        break;
                    case JTokenType.Property:
                        root.Nodes.Add(HandleJProperty(token));
                        break;
                    case JTokenType.Array:
                        root.Nodes.Add(HandleJArray(token.Value as JArray, token.Name));
                        break;
                }
            }
            return root;
        }

        private TreeNode HandleJArray(JArray jArray, string key)
        {
            var root = new TreeNode(key);
            foreach (JToken token in jArray)
            {
                if (token.Type == JTokenType.String)
                {
                    var jvalue = token as JValue;
                    if (jvalue == null)
                        continue;
                    root.Nodes.Add(new TreeNode(jvalue.Value<string>()));
                }
            }
            return root;
        }
    }
}