﻿// Copyright (c) 2010-2013 SharpDX - Alexandre Mutel
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using SharpDX.Serialization;

namespace SharpDX.Toolkit.Graphics
{
    /// <summary>The effect data class.</summary>
    public partial class EffectData
    {
        /// <summary>	
        /// <p>Describes a shader signature.</p>	
        /// </summary>	
        /// <remarks>	
        /// Describes an input or output signature, composed of <see cref="Semantic"/> descriptions.
        /// </remarks>	
        public sealed class Signature : IDataSerializable, IEquatable<Signature>
        {
            /// <summary>
            /// Gets or sets the semantics
            /// </summary>
            public Semantic[] Semantics;

            /// <summary>
            /// Gets the bytecode of this signature. This field is only valid for Input Vertex Shader.
            /// </summary>
            public byte[] Bytecode;

            /// <summary>
            /// Gets the hashcode associated with the signature bytecode.
            /// </summary>
            public int Hashcode;

            /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
            /// <param name="other">An object to compare with this object.</param>
            /// <returns>true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.</returns>
            public bool Equals(Signature other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;

                if (Semantics.Length != other.Semantics.Length)
                    return false;

                for (int i = 0; i < Semantics.Length; i++)
                    if (Semantics[i] != other.Semantics[i])
                        return false;

                return true;
            }

            /// <summary>Determines whether the specified <see cref="System.Object" /> is equal to this instance.</summary>
            /// <param name="obj">The <see cref="T:System.Object" /> to compare with the current <see cref="T:System.Object" />.</param>
            /// <returns><see langword="true" /> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <see langword="false" />.</returns>
            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((Signature) obj);
            }

            /// <summary>Returns a hash code for this instance.</summary>
            /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
            public override int GetHashCode()
            {
                return Semantics.Length;
            }

            /// <summary>Implements the ==.</summary>
            /// <param name="left">The left.</param>
            /// <param name="right">The right.</param>
            /// <returns>The result of the operator.</returns>
            public static bool operator ==(Signature left, Signature right)
            {
                return Equals(left, right);
            }

            /// <summary>Implements the !=.</summary>
            /// <param name="left">The left.</param>
            /// <param name="right">The right.</param>
            /// <returns>The result of the operator.</returns>
            public static bool operator !=(Signature left, Signature right)
            {
                return !Equals(left, right);
            }

            /// <inheritdoc/>
            void IDataSerializable.Serialize(BinarySerializer serializer)
            {
                serializer.Serialize(ref Semantics);
                serializer.Serialize(ref Bytecode, SerializeFlags.Nullable);
                serializer.Serialize(ref Hashcode);
            }
        }
    }
}