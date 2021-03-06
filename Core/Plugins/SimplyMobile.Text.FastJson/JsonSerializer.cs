using System;
using System.Text.Json;

namespace SimplyMobile.Text.FastJson
{
	public class JsonSerializer : JsonParser, IJsonSerializer
	{
	    private IJsonSerializer serializer;

        public JsonSerializer(IJsonSerializer serializer)
        {
            this.serializer = serializer;
        }

		#region ITextSerializer implementation
		public Format Format 
		{
			get
			{
				return Format.Json;
			}
		}

		public string Serialize<T>(T obj)
        {

            return serializer.Serialize(obj);
        }

        //public string Serialize(object obj)
        //{
        //    return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        //}

		public T Deserialize<T> (string data)
		{
			return Parse<T> (data);
		}

		public object Deserialize(string data, Type type)
		{
			return serializer.Deserialize (data, type);
		}
		#endregion
	}
}

