﻿////////////////////////////////////////////////////////////////////////////////////////
// The MIT License (MIT)
// 
// Copyright (c) 2014 Paul Louth
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
// 

using System;

namespace Monad.Parsec
{
    /// <summary>
    /// Represents a location in the source
    /// </summary>
    public class SrcLoc
    {
        private static SrcLoc unit = new SrcLoc(0, 0,"(location:null)");
        private static SrcLoc endOfSource = new SrcLoc(0, 0, "(end-of-source)");

        public readonly int Line;
        public readonly int Column;

        private SrcLoc(int line, int column, string displayTemplate)
        {
            Line = line;
            Column = column;
        }

        public static SrcLoc Return(int line, int column)
        {
            return new SrcLoc(line, column,"({0},{1})");
        }

        public static SrcLoc Null
        {
            get
            {
                return unit;
            }
        }

        public static SrcLoc EndOfSource
        {
            get
            {
                return endOfSource;
            }
        }

        public override string ToString()
        {
            return String.Format("({0},{1})", Line, Column);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Line << 16) | Column;
            }
        }
    }
}
