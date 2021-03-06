// Copyright (c) 2010-2013 SharpDX - Alexandre Mutel
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
namespace SharpDX.Toolkit.Diagnostics
{
    /// <summary>
    /// Describes a log message.
    /// </summary>
    public class LogMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogMessage" /> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="text">The text.</param>
        public LogMessage(LogMessageType type, string text)
        {
            Type = type;
            Text = text;
        }

        /// <summary>
        /// Type of message.
        /// </summary>
        public readonly LogMessageType Type;

        /// <summary>
        /// Text of the message.
        /// </summary>
        public readonly string Text;

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0} :{1}", Type, Text);
        }
    }

    /// <summary>The log message raw class.</summary>
    public class LogMessageRaw : LogMessage
    {
        /// <summary>Initializes a new instance of the <see cref="LogMessage" /> class.</summary>
        /// <param name="type">The type.</param>
        /// <param name="text">The text.</param>
        public LogMessageRaw(LogMessageType type, string text) : base(type, text)
        {
        }

        /// <summary>Returns a <see cref="System.String" /> that represents this instance.</summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return Text;
        }
    }
}