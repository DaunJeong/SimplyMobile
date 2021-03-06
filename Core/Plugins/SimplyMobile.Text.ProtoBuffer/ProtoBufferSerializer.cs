﻿// 
//  Copyright 2013, Sami M. Kallio
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//
using System.IO;
using System.Text;
using ProtoBuf.Meta;

namespace SimplyMobile.Text.ProtoBuffer
{
    /// <summary>
    /// The proto buffer serializer.
    /// </summary>
    public class ProtoBufferSerializer : IProtoBufSerializer
    {
        /// <summary>
        /// The model.
        /// </summary>
        private static RuntimeTypeModel model;

        /// <summary>
        /// Gets the model.
        /// </summary>
        private static RuntimeTypeModel Model
        {
            get { return model ?? (model = TypeModel.Create()); }
        }

        /// <summary>
        /// Gets the format.
        /// </summary>
        public Format Format
        {
            get { return Format.ProtoBuf; }
        }

        /// <summary>
        /// Serialize function.
        /// </summary>
        /// <param name="obj">
        /// The object to serialize.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
		public string Serialize<T>(T obj)
        {
            using (var memStream = new MemoryStream())
            {
                Model.Serialize(memStream, obj);
                var buffer = new byte[memStream.Length];
				memStream.Position = 0;
                var count = memStream.Read(buffer, 0, buffer.Length);
                return Encoding.UTF8.GetString(buffer, 0, count);
            }
        }

        /// <summary>
        /// Deserialize function.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public T Deserialize<T>(string data)
        {
            using (var memStream = new MemoryStream())
            {
                var bytes = Encoding.UTF8.GetBytes(data);
                memStream.Write(bytes, 0, bytes.Length);
				memStream.Position = 0;
                return (T)Model.Deserialize(memStream, null, typeof(T));
            }
        }
    }
}
